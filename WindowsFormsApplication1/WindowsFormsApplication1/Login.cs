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

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string uname = unameTextBox.Text;
            string pass = passwordTextBox.Text;

            OracleDataReader dr = Connect.Search("SELECT id_ FROM library_db_apeilk_user_tab WHERE uname = '" + uname + "' AND pass = '" + pass + "'");
            if (dr.Read())
            {
                for (int i = 1; i <= 10; i++)
                {
                    progressBar1.Increment(i * 10);
                    System.Threading.Thread.Sleep(200);
                }
                this.Hide();
                Form f1 = new Form1((int) dr.GetDecimal(0));
                f1.Closed += (s, args) => this.Close();
                f1.Show();
            }

        }

        
    }
}
