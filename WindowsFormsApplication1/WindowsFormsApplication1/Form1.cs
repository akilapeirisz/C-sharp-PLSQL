using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string[] arr;
        private int uid;

        public int Uid
        {
            get { return uid; }
        }

        public Form1()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            arr = new string[] { "dsa", "asda", "dda", "dss", "asdadd", "sada" };
            list_default_state();
        }

        public Form1(int uid) :this()
        {
            this.uid = uid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void list_default_state()
        {            
            listBox1.Items.Clear();
            listBox1.Height = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.GetItemText(listBox1.SelectedItem);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                this.ActiveControl = listBox1;
                listBox1.SetSelected(0, true);
            }
            else
            {
                list_default_state();
                string typed = textBox1.Text.Trim();
                if (typed.Length > 0)
                {
                    foreach (string ar_string in arr)
                    {
                        if (ar_string.StartsWith(typed))
                        {
                            listBox1.Items.Add(ar_string);
                            listBox1.Height = listBox1.Height + textBox1.Height;
                        }
                    }
                }
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBox1_KeyUp(sender, e);
                listBox1.Height = 0;
            }
            else if (e.KeyData == Keys.Back)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                this.ActiveControl = textBox1;
            }
            else if (e.KeyData == Keys.Up && listBox1.SelectedIndex == 0)
            {
                this.ActiveControl = textBox1;
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OracleDataReader dr = Connect.Search("SELECT name_, uname FROM library_db_apeilk_user_tab WHERE id_ = '" + uid + "'");
                if (dr.Read())
                {
                    label3.Text = "Welcome back " + dr.GetString(0) + "\nUsername : " + dr.GetString(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
