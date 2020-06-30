using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        Account GetAccount(int accountId);
        Account GetAccountByName(string username);
        
        
    }
}
