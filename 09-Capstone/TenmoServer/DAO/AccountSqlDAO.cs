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
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;
        //const decimal startingBalance = 1000;
        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public Account GetAccount(string username)
        {
            Account obj = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from accounts a join users on users.user_id = a.user_id where username = @username", conn);
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

        //public Account GetAccountByName(string username)
        //{
        //    Account obj = null;
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand("select * from accounts a join users on users.user_id = a.user_id where username = @username", conn);
        //            cmd.Parameters.AddWithValue("@username", username);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows && reader.Read())
        //            {                     
        //                obj = RowToObject(reader);
        //            }
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }

        //    return obj;
        //}





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




