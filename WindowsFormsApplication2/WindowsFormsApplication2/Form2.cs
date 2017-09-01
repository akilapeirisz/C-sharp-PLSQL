using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Debug Information-Product Starting ");

            OracleDataReader dr = Connect.Search("SELECT num FROM library_db_apeilk_address_tab");
            dr.Read();
            label1.Text = dr.GetString(0);
            Console.WriteLine(dr.GetString(0));

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = Connect.Conn;

            cmd.CommandText = "lib_db_apeilk_address_create_";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("num_", OracleDbType.Int32).Value = numTextBox.Text;
            cmd.Parameters.Add("street", OracleDbType.Varchar2, 30).Value = streetTextBox.Text;
            cmd.Parameters.Add("city", OracleDbType.Varchar2, 30).Value = cityTextBox.Text;
            cmd.Parameters.Add("country", OracleDbType.Varchar2, 30).Value = countryTextBox.Text;

            cmd.ExecuteNonQuery();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string yourReturnedValue = Microsoft.VisualBasic.Interaction.InputBox("Enter ID to update", "Enter ID", "0", -1, -1);
            if (yourReturnedValue != null)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Connect.Conn;

                cmd.CommandText = "lib_db_apeilk_address_update_";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("up_id_", OracleDbType.Int32).Value = yourReturnedValue;
                cmd.Parameters.Add("up_num_", OracleDbType.Int32).Value = numTextBox.Text;
                cmd.Parameters.Add("up_street", OracleDbType.Varchar2, 30).Value = streetTextBox.Text;
                cmd.Parameters.Add("up_city", OracleDbType.Varchar2, 30).Value = cityTextBox.Text;
                cmd.Parameters.Add("up_country", OracleDbType.Varchar2, 30).Value = countryTextBox.Text;

                Console.WriteLine( cmd.ExecuteNonQuery() + 1);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string yourReturnedValue = Microsoft.VisualBasic.Interaction.InputBox("Enter ID to update", "Enter ID", "0", -1, -1);
            if (yourReturnedValue != null)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Connect.Conn;

                cmd.CommandText = "lib_db_apeilk_address_delete_";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("del_id_", OracleDbType.Int32).Value = yourReturnedValue;

                Console.WriteLine( cmd.ExecuteNonQuery());
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            string yourReturnedValue = Microsoft.VisualBasic.Interaction.InputBox("Enter ID to search", "Enter ID", "0", -1, -1);
            if (yourReturnedValue != null)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = Connect.Conn;

                cmd.CommandText = "lib_db_apeilk_address_search_";
                cmd.CommandType = CommandType.StoredProcedure;
                
                
                OracleParameter para1 = new OracleParameter();
                para1.ParameterName = "se_id_";
                para1.OracleDbType = OracleDbType.Int32;
                para1.Direction = ParameterDirection.Input;
                para1.Value = Convert.ToInt32(yourReturnedValue);
                
                OracleParameter para2 = new OracleParameter();
                para2.ParameterName = "country";
                para2.OracleDbType = OracleDbType.Varchar2;
                para2.Size = 30;
                para2.Direction = ParameterDirection.Output;

                OracleParameter[] para_col = new OracleParameter[] { para1, para2 };

                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(para_col);
                cmd.ExecuteNonQuery();

                object country = cmd.Parameters["country"].Value;
                cmd.Parameters.Clear();
                if (country != null)
                {
                    label6.Text = Convert.ToString(country);
                }
            }
        }

    }
}
