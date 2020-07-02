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


        public Transfer CreateTransfer(Transfer transfer)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    const string QUERY = "Update accounts set balance = balance - @amount where account_id = @accountFrom Update accounts Set balance = balance + @amount where account_id = @accountTo insert into transfers(transfer_type_id, transfer_status_id, account_from, account_to, amount) values(@type, @status, @accountFrom, @accountTo, @amount) Select @@IDENTITY";

                        

                    SqlCommand cmd = new SqlCommand(QUERY, conn);
                    cmd.Parameters.AddWithValue("@accountFrom ", transfer.AccountFrom);
                    cmd.Parameters.AddWithValue("@accounTo ", transfer.AccountTo);
                    cmd.Parameters.AddWithValue("@amount ", transfer.Amount);
                    cmd.Parameters.AddWithValue("@type ", transfer.TransferTypeId);
                    cmd.Parameters.AddWithValue("@status ", transfer.TransferStatusId);
                    transfer.TransferId = Convert.ToInt32(cmd.ExecuteScalar());
                    return transfer;
                }
            }
            catch (SqlException)
            {
                throw;
            }


        }
    }
}
