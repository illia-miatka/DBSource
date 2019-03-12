using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Windows.Forms;


namespace DBSource
{
    internal class DbConnectionOracle : DbConnection
    {
        //Connection
        private OracleConnection _connection;

        //Connection Params
        private readonly string _tns;
        private readonly string _user;
        private readonly string _password;

        private readonly bool _isDirect;

        //Direct Connection Params
        private readonly string _protocol;
        private readonly string _host;
        private readonly string _port;
        private readonly string _sid;

        private const string _cmdObjectType = "SELECT DISTINCT OBJECT_TYPE AS NAME FROM ALL_OBJECTS WHERE OBJECT_TYPE<>'LOB' " +
                                                "UNION " +
                                                "SELECT DISTINCT OBJECT_TYPE FROM USER_OBJECTS WHERE OBJECT_TYPE<>'LOB' ";


        public DbConnectionOracle(string type, Dictionary<string,string> par) 
        {
            try
            {
                _user = par["user"];
                _password = par["password"];

                switch (type)
                {
                    case "direct":
                        _protocol = par["protocol"];
                        _host = par["host"];
                        _port = par["port"];
                        _sid = par["sid"];
                        _isDirect = true;
                        break;
                    case "notdirect":
                    default:
                        _tns = par["tns"];
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            InitializeConnection();
        }

        public DbConnectionOracle(string user, string password, string tns)
        {
            _tns = tns;
            _user = user;
            _password = password;

            InitializeConnection();
        }

        public DbConnectionOracle(string user, string password, string protocol, string host, int port, string sid)
        {
            _user = user;
            _password = password;
            _protocol = protocol;
            _host = host;
            _port = port.ToString();
            _sid = sid;
            _isDirect = true;

            InitializeConnection();
        }

        private void InitializeConnection()
        {
            //string ConString = "Data Source=DATASOURCE;User Id=USERNAME;Password=PWD; ";
            string conString;
            if (_isDirect)
            {
                conString = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + _protocol +
                            ")(HOST=" + _host +
                            ")(PORT=" + _port +
                            ")))(CONNECT_DATA =(SERVICE_NAME=" + _sid +
                            ")));User ID=" + _user +
                            ";Password=" + _password + ";";
                //";Unicode=True";
            }
            else
            {
                conString = "Data Source=" + _tns + ";User Id=" + _user + ";Password = " + _password + ";";
            }

            _connection = new OracleConnection(conString);
        }

        private bool GetQueryResult(string query, DataTable dt, bool clear = true)
        {
            try
            {
                var cmd = new OracleCommand(query, _connection);
                var oda = new OracleDataAdapter(cmd);
                if (clear) dt.Clear();
                oda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            return true;
        }

        public override void Close()
        {
            if (State() != ConnectionState.Closed)
                _connection.Close();
        }

        public override ConnectionState State()
        {
            return _connection.State;
        }

        public override void GetDBObjectTypes(DataTable dt)
        {
            GetQueryResult(_cmdObjectType, dt);
        }

        public override void GetDBObjectNames(DataTable dt, string filterObjects, bool currentSchema, List<string> objectTypes)
        {
            string stringCmd =
                "SELECT DISTINCT '[' || OBJECT_TYPE || ']' || OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                "FROM ( " +
                "SELECT DISTINCT OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                "FROM ALL_OBJECTS ";
            if (currentSchema)
            {
                stringCmd += "WHERE OWNER = SYS_CONTEXT('USERENV', 'CURRENT_SCHEMA') ";
            }

            stringCmd += "UNION " +
                         "SELECT DISTINCT OBJECT_NAME AS NAME, OBJECT_NAME, OBJECT_TYPE " +
                         "FROM USER_OBJECTS" +
                         ") t  WHERE 1=1 ";
            if (objectTypes != null)
            {
                stringCmd += "AND OBJECT_TYPE IN(";

                if (objectTypes.Count == 1)
                    stringCmd = stringCmd.Replace("'[' || OBJECT_TYPE || ']' ||", "");

                foreach (var type in objectTypes)
                {
                    stringCmd += "'" + type + "',";
                }

                stringCmd = stringCmd.Remove(stringCmd.Length - 1);
                stringCmd += ") ";
            }

            stringCmd += filterObjects != "" ? "AND OBJECT_NAME LIKE ('%" + filterObjects + "%') " : "";
            stringCmd += "ORDER BY 1";

            GetQueryResult(stringCmd, dt);
        }

        public override string GetDDL(DataSet.DbObjectsRow obj)
        {
            var stringCmd = GetCmd(obj.OBJECT_TYPE, obj.OBJECT_NAME);
            DataSet.OBJDataTable _ddl = new DataSet.OBJDataTable();
            GetQueryResult(stringCmd, _ddl);
            var ddl = (from d in _ddl
                select d).First();
            return ddl.DDL;
        }

        private string GetCmd(string Type, string Name)
        {
           return "SELECT dbms_metadata.get_ddl('" +
                Get_type(Type).Replace(' ', '_') +
                "', '" + Name + "') AS DDL, '" + Name +
                "' as OBJECT_NAME, '" + Type + "' as OBJECT_TYPE  FROM DUAL";
        }

        public override string GetPath(string Type, string Name)
        {
            var path = @"\" +
                   (Type == "PACKAGE BODY" ? "PACKAGE" : Type) + @"S\";
            return path;
        }

        public override string GetFileName(string Type, string Name)
        {
            return Name + get_object_file_type(Type);
        }

        private static string Get_type(string objectType)
        {
            if (objectType == "PACKAGE") objectType = "PACKAGE_SPEC";
            if (objectType == "JOB" || objectType == "SCHEDULE") objectType = "PROCOBJ";
            if (objectType == "LOB") objectType = "TABLE";
            if (objectType == "DATABASE LINK") objectType = "DB_LINK";
            return objectType;
        }

        private static string get_object_file_type(string objTypeName)
        {
            var val = ".sql";
            switch (objTypeName)
            {
                case "PROCEDURE":
                    val = ".prc";
                    break;
                case "VIEW":
                    val = ".vw";
                    break;
                case "PACKAGE_SPEC":
                case "PACKAGE":
                    val = ".pks";
                    break;
                case "PACKAGE BODY":
                    val = ".pkb";
                    break;
                case "TRIGGER":
                    val = ".trg";
                    break;
            }

            return val;
        }

    }
}