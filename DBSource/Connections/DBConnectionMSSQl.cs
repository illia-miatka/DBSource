using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
                if ((from StoredProcedure p in db.StoredProcedures
                    select p).Any())
                _ObjectTypes.AddDbObjectTypesRow(db.Name + ".StoredProcedure");
                if ((from Microsoft.SqlServer.Management.Smo.View p in db.Views
                    select p).Any())
                    _ObjectTypes.AddDbObjectTypesRow(db.Name + ".View");
                if ((from Table p in db.Tables
                    select p).Any())
                    _ObjectTypes.AddDbObjectTypesRow(db.Name + ".Table");
                if ((from UserDefinedFunction p in db.UserDefinedFunctions
                    select p).Any())
                    _ObjectTypes.AddDbObjectTypesRow(db.Name + ".UserDefinedFunction");
                if ((from User p in db.Users
                     select p).Any())
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


        private string GetTypeMS(string type)
        {
            switch (type)
            {
                case "StoredProcedure":
                    type = "SQL_STORED_PROCEDURE";
                    break;
                case "View":
                    type = "VIEW";
                    break;
                case "Table":
                    type = "USER_TABLE";
                    break;
                case "UserDefinedFunction":
                    type = "SQL_TABLE_VALUED_FUNCTION','SQL_SCALAR_FUNCTION','SQL_INLINE_TABLE_VALUED_FUNCTION";
                    break;
                case "User":
                    break;
            }

            return type;
        }

        public override void GetDBObjectNames(DataTable dataTable, Filter filter, bool currentSchema, List<string> objectTypes = null)
        {
            dataTable.Clear();
            var dTab = new DataSet.DbObjectsDataTable();
            var vDbList = new List<Database>();

            if (objectTypes == null)
            {
                objectTypes = (from t in _ObjectTypes select Helpers.GetFromOrEmpty(t.NAME, ".")).Distinct().ToList();
                vDbList = (from row in _DBList
                    select row).ToList();
            }
            else
            {
                var dbList = (from dbName in objectTypes select Helpers.GetUntilOrEmpty(dbName, ".")).Distinct().ToList();
                vDbList = (from row in _DBList
                    where dbList.Exists(p => p == row.Name)
                    select row).ToList();
                objectTypes = (from type in objectTypes select Helpers.GetFromOrEmpty(type, ".")).Distinct().ToList();
            }

            foreach (var database in vDbList)
            {
                var q = @"SELECT DB_NAME() + '.' + SCHEMA_NAME(schema_id) + '.' + name as FullName, name as Name ";
                q += @" FROM sys.objects ";
                q += @" WHERE type <> 'S' ";
                q += filter.Objects != "" ? @" and name like ('%" + filter.Objects + @"%') " : "";
                q += filter.Date != "" ? @" and modify_date >= CAST(CONVERT(varchar,'" + filter.Date + @"',120) as datetime) " : "";
                q +=
                    @" and type_desc in ('$type$') ";
                q += @" and is_ms_shipped = 0 ";
                q += @" UNION ";
                q += @" SELECT DB_NAME() + '..' + name as FullName, name as Name  FROM sys.sysusers ";
                q += @" WHERE gid=0 and sid is not null ";
                q += @" and name not in ('dbo', 'public', 'guest') ";
                q += filter.Objects != "" ? @" and name like ('%" + filter.Objects + @"%') " : "";
                q += filter.Date != "" ? @" and updatedate >= CAST(CONVERT(varchar,'" + filter.Date + @"',120) as datetime) " : "";
                q += @" and 'User' in ('$type$')";

                foreach (var type in objectTypes)
                {
                    var dt = database.ExecuteWithResults(q.Replace("$type$", GetTypeMS(type)));
                    var table = dt.Tables[0];
                    var rows = table.Rows;
                    foreach (DataRow row in rows)
                    {
                        var fullname = row["FullName"].ToString();
                        var name = row["Name"].ToString();
                        dTab.AddDbObjectsRow(fullname, name, type);
                    }
                }
            }

            foreach ( var row in (from p in dTab select p))
            {
                dataTable.ImportRow(row);
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

            if (dbObj == null) return "";
            Scripter scr = new Scripter(_server);
            scr.Options.NoCommandTerminator = false;
            scr.Options.ScriptBatchTerminator = true;
            scr.Options.IncludeDatabaseContext = true;
            SqlSmoObject[] sso = new SqlSmoObject[1];
            sso[0] = dbObj;
            var sc = scr.Script(sso);
            string[] strArray = new string[sc.Count];
            sc.CopyTo(strArray, 0);
            string text = string.Join("\nGO\n", strArray) + "\nGO\n";
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
            if (proc.IsSystemObject) proc = null;
            return proc;
        }

        private Microsoft.SqlServer.Management.Smo.View GetView(Database db, string name)
        {

            var view = (from Microsoft.SqlServer.Management.Smo.View p in db.Views
                where p.Name == name
                select p).FirstOrDefault();
            if (view.IsSystemObject) view = null;
            return view;
        }

        private UserDefinedFunction GetUserDefinedFunction(Database db, string name)
        {

            var func = (from UserDefinedFunction p in db.UserDefinedFunctions
                        where p.Name == name
                select p).FirstOrDefault();
            if (func.IsSystemObject) func = null;
            return func;
        }

        private User GetUser(Database db, string name)
        {

            var user = (from User p in db.Users
                where p.Name == name
                select p).FirstOrDefault();
            if (user.IsSystemObject) user = null;
            return user;
        }

        private Table GetTable(Database db, string name)
        {

            var tbl = (from Table p in db.Tables
                where p.Name == name
                select p).FirstOrDefault();
            if (tbl.IsSystemObject) tbl = null;
            return tbl;
        }

        public override string GetPath(string type, string name, bool byFolders = false)
        {
            string path = @"\" + Helpers.GetUntilOrEmpty(name,".") + @"\";
            if (byFolders)
            {
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
            }

            return path;
        }

        public override string GetFileName(string type, string name, bool withType = false)
        {
            var val = Helpers.GetFromOrEmpty(name, ".");
            if (withType) val += @"." + type;
            val += @".sql";
            return val;
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
