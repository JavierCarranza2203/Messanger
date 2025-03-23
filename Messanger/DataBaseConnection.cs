using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger
{
    internal class DataBaseConnection
    {

        private string _strUserName;
        private string _strPassword;
        private string _strHost;
        private string _strPort;
        private string _strDataBaseName;

        public DataBaseConnection(string userName, string password, string host, string port, string dataBaseName)
        {
            this._strUserName = userName;
            this._strPassword = password;
            this._strHost = host;
            this._strPort = port;
            this._strDataBaseName = dataBaseName;
        }

        public string UserName { get { return this._strUserName; } }
        public string Password { get { return this._strPassword; } }
        public string Host { get { return this._strHost; } }
        public string Port { get { return this._strPort; } }
        public string DataBaseName { get { return this._strDataBaseName; } }
    }
}
