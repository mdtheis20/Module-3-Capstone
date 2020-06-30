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
    public class AccountSqlDAO
    {
        private readonly string connectionStrings;
        const decimal startingBalance = 1000;
        public AccountSqlDAO(string dbConnectionString)
        {
            connectionStrings = dbConnectionString;
        }

        public Account GetAccount(int accountId)
        {
            Account obj = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionStrings))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select account_id accounts a join users on users.user_id = a.user_id where account_id = @account_id", conn);
                    cmd.Parameters.AddWithValue("@account_id", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                      
                        obj = RowToObject(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return obj;
        }

        public Account GetBalanceByAccount(string username)
        {
            Account obj = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionStrings))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select balance from accounts a join users on users.user_id = a.user_id where username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {                     
                        obj = RowToObject(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return obj;
        }





        private static Account RowToObject(SqlDataReader reader)
        {
            Account a = new Account();
            a.UserId = Convert.ToInt32(reader["user_id"]);
            a.Balance = Convert.ToDecimal(reader["balance"]);
            a.AccountId = Convert.ToInt32(reader["account_id"]);

            return a;
        }
        
    }
    
}




