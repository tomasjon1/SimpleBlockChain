using SimpleBlockChain.Services;
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
        public string TransactionID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public double Amount { get; set; }

        private readonly HashService hashService = new HashService();

        public Transaction() { }
        public Transaction(string sender, string receiver, double amount)
        {
            TransactionID = hashService.ComputeSha256Hash(sender + receiver + amount.ToString());
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
        }
    }
}
