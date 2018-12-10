using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;


namespace DBSource
{
    internal class DbConnectionOracle : DbConnection //: Program.IConnection
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

        public override bool GetQueryResult(string query, DataTable dt, bool clear = true)
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
    }
}