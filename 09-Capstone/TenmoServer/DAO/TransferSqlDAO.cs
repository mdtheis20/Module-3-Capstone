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


        public void CreateTransfer(int accountFromId, int accountToId, decimal amount)
        {
            Account obj = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into transfers(transfer_type_id, transfer_status_id, account_from, account_to, amount) values(2, 2, @account_from, @account_to, @amount)", conn);
                    cmd.Parameters.AddWithValue("@account_from ", accountFromId);
                    cmd.Parameters.AddWithValue("@account_to ", accountToId);
                    cmd.Parameters.AddWithValue("@amount ", amount);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cmd.ExecuteNonQuery();

                   cmd = new SqlCommand()

                   
                }
            }
            catch (SqlException)
            {
                throw;
            }

            //return obj;
            //    
        }
    }
}
