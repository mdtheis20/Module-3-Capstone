using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO
    {
        private readonly string connecitonString;
        const decimal startingBalance = 1000;
        public AccountSqlDAO(string dbConnectionString)
        {
            connecitonString = dbConnectionString;
        }

        public AccountSqlDAO GetAccount(int accountId)
        {
            AccountSqlDAO obj = null;
        }
    }
}
