using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        Account GetAccount(string username);
        //Account GetAccountByName(string username);
        
        
    }
}
