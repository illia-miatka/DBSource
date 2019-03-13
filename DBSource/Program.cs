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
        public abstract void Close();
        public abstract ConnectionState State();
        public abstract void GetDBObjectTypes(DataTable ds);

        public abstract void GetDBObjectNames(DataTable dt, Filter filter,
            bool currentSchema, List<string> objectTypes = null);

        public abstract string GetDDL(DataSet.DbObjectsRow obj);

        public abstract string GetPath(string Type, string Name, bool ByFolders = false);
        public abstract string GetFileName(string Type, string Name, bool WithType = false);

    }

    public class Filter
    {
        public string Objects { get; }
        public string Date { get; }

        public Filter(string objects, string date)
        {
            Date = date;
            Objects = objects;
        }
    }


}
