using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Windows.Forms;

namespace DBSource
{
    class DBConnectionMSSQl : DbConnection
    {
        private Server _server;
        private List<Database> _DBList = new List<Database>();
        private DataSet.DbObjectTypesDataTable _ObjectTypes = new DataSet.DbObjectTypesDataTable();
        private ConnectionState state = ConnectionState.Closed;

        public DBConnectionMSSQl(string type, Dictionary<string, string> par)
        {
            state = ConnectionState.Connecting;
            if (type == "direct")
            {
                var server = par["server"];
                _server = new Server(server);
            }
            else
            {
                var user = par["user"];
                var password = par["password"];
                var server = par["server"];
                var con = new ServerConnection(server, user, password);
                _server = new Server(con);
            }

            try
            {
                var testConn = _server.Version;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                state = ConnectionState.Closed;
                return;
            }
            foreach (Database db in _server.Databases)
            {
                if (db.IsSystemObject) continue;
                _DBList.Add(db);
                _ObjectTypes.AddDbObjectTypesRow(db.Name + ".StoredProcedure");
                _ObjectTypes.AddDbObjectTypesRow(db.Name + ".View");
                _ObjectTypes.AddDbObjectTypesRow(db.Name + ".Table");
                _ObjectTypes.AddDbObjectTypesRow(db.Name + ".UserDefinedFunction");
                _ObjectTypes.AddDbObjectTypesRow(db.Name + ".User");
            }

            _server.SetDefaultInitFields(typeof(StoredProcedure), true);
            _server.SetDefaultInitFields(typeof(Microsoft.SqlServer.Management.Smo.View), true);
            _server.SetDefaultInitFields(typeof(Table), true);
            _server.SetDefaultInitFields(typeof(UserDefinedFunction), true);
            _server.SetDefaultInitFields(typeof(User), true);

            state = ConnectionState.Open;
        }

        public override void Close()
        {
            _server = null;
            state = ConnectionState.Closed;
        }

        public override void GetDBObjectNames(DataTable dt, string filterObjects, bool currentSchema, List<string> objectTypes = null)
        {
            dt.Clear();
            var dTab = new DataSet.DbObjectsDataTable();

            if (objectTypes == null)
            {
                objectTypes = (from ot in _ObjectTypes select ot.NAME).Distinct().ToList();
            }

            foreach (var type in objectTypes)
            {
                var vDb = (from row in _DBList
                         where row.Name == Helpers.GetUntilOrEmpty(type, ".")
                         select row).FirstOrDefault();
                var vType = Helpers.GetFromOrEmpty(type, ".");

                try
                {
                    switch (vType)
                    {
                        case "StoredProcedure":
                            foreach (StoredProcedure obj in vDb.StoredProcedures)
                                if ((currentSchema && obj.Schema != "sys") || (!currentSchema))
                                {
                                    if (obj.IsSystemObject) continue;
                                    dTab.AddDbObjectsRow(vDb.Name + '.' + obj.Schema + '.' + obj.Name, obj.Name, vType);
                                }
                            break;
                        case "View":
                            foreach (Microsoft.SqlServer.Management.Smo.View obj in vDb.Views)
                                if ((currentSchema && obj.Schema != "sys") || (!currentSchema))
                                {
                                    if (obj.IsSystemObject) continue;
                                    dTab.AddDbObjectsRow(vDb.Name + '.' + obj.Schema + '.' + obj.Name, obj.Name, vType);
                                }
                            break;
                        case "Table":
                            foreach (Table obj in vDb.Tables)
                                if ((currentSchema && obj.Schema != "sys") || (!currentSchema))
                                {
                                    if (obj.IsSystemObject) continue;
                                    dTab.AddDbObjectsRow(vDb.Name + '.' + obj.Schema + '.' + obj.Name, obj.Name, vType);
                                }
                            break;
                        case "UserDefinedFunction":
                            foreach (UserDefinedFunction obj in vDb.UserDefinedFunctions)
                                if ((currentSchema && obj.Schema != "sys") || (!currentSchema))
                                {
                                    if (obj.IsSystemObject) continue;
                                    dTab.AddDbObjectsRow(vDb.Name + '.' + obj.Schema + '.' + obj.Name, obj.Name, vType);
                                }
                            break;
                        case "User":
                            foreach (User obj in vDb.Users)
                            {
                                if (obj.IsSystemObject) continue;
                                dTab.AddDbObjectsRow(vDb.Name + '.' + '.' + obj.Name, obj.Name, vType);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    var frm = MessageBox.Show("Continue? \n" + ex.Message, @"Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (frm == DialogResult.Yes)
                    {
                        continue;
                    }
                    else return;
                }

            }
            foreach( var row in (from p in dTab select p))
            {
                dt.ImportRow(row);
            }
        }

        public override string GetDDL(DataSet.DbObjectsRow obj)
        {
            var db = GetDatabase(Helpers.GetUntilOrEmpty(obj.NAME, "."));

            SqlSmoObject dbObj = null;
            switch (obj.OBJECT_TYPE)
            {
                case "StoredProcedure":
                    dbObj = GetStoredProcedure(db, obj.OBJECT_NAME);
                    break;
                case "View":
                    dbObj = GetView(db, obj.OBJECT_NAME);
                    break;
                case "Table":
                    dbObj = GetTable(db, obj.OBJECT_NAME);
                    break;
                case "UserDefinedFunction":
                    dbObj = GetUserDefinedFunction(db, obj.OBJECT_NAME);
                    break;
                case "User":
                    dbObj = GetUser(db, obj.OBJECT_NAME);
                    break;
            }
            
            Scripter scr = new Scripter(_server);
            SqlSmoObject[] sso = new SqlSmoObject[1];
            sso[0] = dbObj;
            var sc = scr.Script(sso);
            string[] strArray = new string[sc.Count];
            sc.CopyTo(strArray, 0);
            string text = string.Join("\n", strArray);
            return text;
        }

        private Database GetDatabase(string name)
        {
            return (from d in _DBList
                where d.Name == name
                select d).FirstOrDefault();
        }

        private StoredProcedure GetStoredProcedure(Database db, string name)
        {

            var proc = (from StoredProcedure p in db.StoredProcedures
                where p.Name == name
                        select p).FirstOrDefault();
            return proc;
        }

        private Microsoft.SqlServer.Management.Smo.View GetView(Database db, string name)
        {

            var view = (from Microsoft.SqlServer.Management.Smo.View p in db.Views
                where p.Name == name
                select p).FirstOrDefault();
            return view;
        }

        private UserDefinedFunction GetUserDefinedFunction(Database db, string name)
        {

            var func = (from UserDefinedFunction p in db.UserDefinedFunctions
                        where p.Name == name
                select p).FirstOrDefault();
            return func;
        }

        private User GetUser(Database db, string name)
        {

            var user = (from User p in db.Users
                where p.Name == name
                select p).FirstOrDefault();
            return user;
        }

        private Table GetTable(Database db, string name)
        {

            var tbl = (from Table p in db.Tables
                where p.Name == name
                select p).FirstOrDefault();
            return tbl;
        }

        public override string GetPath(string type, string name)
        {
            string path = @"\" + Helpers.GetUntilOrEmpty(name,".") + @"\";
            switch (type)
            {
                case "StoredProcedure":
                    path += @"Stored Procedures";
                    break;
                case "View":
                    path += @"Views";
                    break;
                case "Table":
                    path += @"Tables";
                    break;
                case "UserDefinedFunction":
                    path += @"Functions";
                    break;
                case "User":
                    path += @"Security\Users";
                    break;
            }

            path += @"\";
            return path;
        }

        public override string GetFileName(string type, string name)
        {
            return Helpers.GetFromOrEmpty(name, ".") + @".sql";
        }

        public override void GetDBObjectTypes(DataTable ds)
        {
            ds.Clear();
            var q = from row in _ObjectTypes
                    select row;
            foreach (var row in q)
            {
                ds.ImportRow(row);
            }

        }

        public override ConnectionState State()
        {
            return state;
        }
    }
}
