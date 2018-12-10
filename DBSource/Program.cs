using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DBSource
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }

    internal abstract class DbConnection
    {
        protected DbConnection(string type, Dictionary<string, string> par)
        {
        }
        protected DbConnection()
        {
        }

        public abstract bool GetQueryResult(string query, DataTable dt, bool clear = true);
        public abstract void Close();
        public abstract ConnectionState State();
    }
}
