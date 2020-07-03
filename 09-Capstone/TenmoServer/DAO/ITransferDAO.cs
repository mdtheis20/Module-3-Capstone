using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
     public interface ITransferDAO
    {
        List<Transfer> GetTransfers(string username);
        Transfer CreateTransfer(Transfer transfer);
        // Transfer ReadTransfers(SqlDataReader reader);
        Transfer ShowTransferDetails(int transferId);


    }
}
