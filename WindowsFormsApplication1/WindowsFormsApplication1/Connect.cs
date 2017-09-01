using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;
using System.Data;

namespace WindowsFormsApplication1
{
    public class Connect
    {
        private static string oradb;
        public static string Oradb
        {
            get { return oradb; }
            set
            {
                if (value != null)
                {
                    oradb = value;
                }
            }
        }

        private static OracleConnection conn;
        public static OracleConnection Conn
        {
            get { return conn; }
            set
            {
                if (value != null)
                {
                    conn = value;
                }
            }
        }

        private static void InitConnnection()
        {
            if (conn == null)
            {
                string oradb = "Data Source=cmbtrndb02/app8sp2;User Id=ifsapp;Password=ifsapp;";
                conn = new OracleConnection(oradb);  // C#
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static OracleDataReader Search(string query)
        {
            InitConnnection();
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        ~Connect()
        {
            conn.Dispose();
        }
    }
}
