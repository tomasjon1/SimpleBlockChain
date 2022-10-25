using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleBlockChain.Models
{
    class Transaction
    {
        private string transactionID { get; set }
        private string sender { get; set; }
        private string receiver { get; set; }
        private double amount { get; set; }

        public Transaction() { }

        public Transaction(string transactionID, string sender, string receiver, double amount)
        {
            TransactionID = transactionID; // HASH of other fields
            Sender = transactionID;
            Receiver = receiver;
            Amount = amount;
        }


        public string TransactionID
        {
            get { return transactionID; }
            set { transactionID = value; }
        }
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

    }
}
