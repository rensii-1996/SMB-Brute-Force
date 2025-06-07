using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB.Models
{
    public class SMBResult
    {
        private string username;
        private string password;
        private string hostname;
        private bool status;
        private string err;
        private string port;
        private int tableIndex;

        public SMBResult(string username, string password, string hostname, string port, bool status, string err, int tableIndex)
        {
            this.username = username;
            this.password = password;
            this.hostname = hostname;
            this.port = port;
            this.status = status;
            this.err = err;
            this.tableIndex = tableIndex;
        }

        public string Username { get { return username; } }
        public string Password { get { return password; } }
        public string Hostname { get { return hostname; } }
        public string Port { get { return port; } }
        public bool Status { get { return status; } }
        public string Error { get { return err; } }
        public int TableIndex { get { return tableIndex; } }

    }
}
