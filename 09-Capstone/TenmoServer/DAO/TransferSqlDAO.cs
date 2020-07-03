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

        const int startingTransferStatus = 2;
        const decimal startingTransferType = 2;
        public Transfer CreateTransfer(Transfer transfer)
        {
            Transfer newTransfer = new Transfer();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    const string QUERY = "Update accounts set balance = balance - @amount where account_id = @accountFrom Update accounts Set balance = balance + @amount where account_id = @accountTo Insert into transfers(transfer_type_id, transfer_status_id, account_from, account_to, amount) values(@type, @status, @accountFrom, @accountTo, @amount) Select @@IDENTITY";

                        

                    SqlCommand cmd = new SqlCommand(QUERY, conn);
                    cmd.Parameters.AddWithValue("@accountFrom ", transfer.AccountFrom);
                    cmd.Parameters.AddWithValue("@accountTo ", transfer.AccountTo);
                    cmd.Parameters.AddWithValue("@amount ", transfer.Amount);
                    cmd.Parameters.AddWithValue("@type ", startingTransferType);
                    cmd.Parameters.AddWithValue("@status ", startingTransferStatus);
                    transfer.TransferId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newTransfer;
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }
        public List<Transfer> GetTransfers(string username)
        {
            List<Transfer> transfers = new List<Transfer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    const string QUERY = @"select uTO.username user_to, t.*, uFROM.username user_from FROM transfers t JOIN accounts aTO ON aTO.account_id = aTO.user_id JOIN accounts aFROM ON aFROM.account_id = t.account_from JOIN users uFROM ON uFROM.user_id = aFROM.user_id WHERE uTO.username = @userName OR uFROM.username = @userName";
                        //"transfers t JOIN accounts aTO ON aTO.account_id = aTO.user_id JOIN accounts aFROM ON a FROM.account_id = t.account_from" +
                        //"JOIN users uFROM ON uFROM.user_id = aFROM.user_id WHERE uTO.username = @userName OR uFROM.username = @userName";
                    SqlCommand cmd = new SqlCommand(QUERY, conn);
                    cmd.Parameters.AddWithValue("@userName", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Transfer transfer = ReadFromTransfers(reader);
                        transfers.Add(transfer);
                    }
                    return transfers;
                }
            }
            catch
            {
                throw;
            }
            
        }
        private Transfer ReadFromTransfers(SqlDataReader reader)
        {
            Transfer t = new Transfer();
            t.TransferId = Convert.ToInt32(reader["transfer_id"]);
            t.TransferTypeId = 2;
            t.TransferStatusId = 2;
            t.AccountFrom = Convert.ToInt32(reader["account_from"]);
            t.AccountTo = Convert.ToInt32(reader["account_to"]);
            t.Amount = Convert.ToDecimal(reader["amount"]);
            return t;
            
        }
    }
}
