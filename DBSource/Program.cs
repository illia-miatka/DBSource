using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace DBSource
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }

    internal abstract class DbConnection
    {
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
