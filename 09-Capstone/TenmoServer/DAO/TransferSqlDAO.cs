using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TenmoServer.Models;
using TenmoServer.Security.Models;
using TenmoServer.Security;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {

        private readonly string connectionString;

        public TransferSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public Transfer CreateTransfer
    }
}
