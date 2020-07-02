using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Data
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }



        public Account()
        {

        }
    }


}
