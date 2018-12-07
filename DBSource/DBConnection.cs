using System;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;


namespace DBSource
{
    internal class DBConnection
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
        private readonly int _port;
        private readonly string _sid;

        public DBConnection(string user, string password, string tns)
        {
            _tns = tns;
            _user = user;
            _password = password;

            InitializeConnection();
        }

        public DBConnection(string user, string password, string protocol, string host, int port, string sid)
        {
            _user = user;
            _password = password;
            _protocol = protocol;
            _host = host;
            _port = port;
            _sid = sid;
            _isDirect = true;

            InitializeConnection();
        }

        public void InitializeConnection()
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

        public bool GetQueryResult(string query, DataTable dt, bool clear = true)
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

        public void Close()
        {
            if (State() != ConnectionState.Closed)
                _connection.Close();
        }

        public ConnectionState State()
        {
            return _connection.State;
        }

    }
}