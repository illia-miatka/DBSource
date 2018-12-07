using System;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;


namespace DBSource
{
    class DBConnection
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

        public DBConnection(string User, string Password, string TNS)
        {
            this._tns = TNS;
            this._user = User;
            this._password = Password;

            InitializeConnection();
        }
        public DBConnection(string User, string Password, string Protocol, string Host, int Port, string SID)
        {
            this._user = User;
            this._password = Password;
            this._protocol = Protocol;
            this._host = Host;
            this._port = Port;
            this._sid = SID;
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
            if(State() != ConnectionState.Closed)
            _connection.Close();
        }

        public ConnectionState State()
        {
            return _connection.State;
        }

    }
}
