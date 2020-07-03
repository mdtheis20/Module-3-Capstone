using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Data
{


    public class Transfer
    {
        public int TransferId { get; set; }
        public int TransferTypeId = 2;
        public int TransferStatusId = 2;
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public decimal Amount { get; set; }
    }
    public class NewTransfer
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public decimal Amount { get; set; }
        //public TransferType TransferType { get; set; }
        
    }
    //public class TransferType
    //{
    //    public int Request = 1;
    //    public int Send = 2;
    //}
}
