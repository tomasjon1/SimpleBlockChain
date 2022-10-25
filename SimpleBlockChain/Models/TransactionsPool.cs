using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockChain.Models
{
    class TransactionsPool
    {
        private List<Transaction> transactions;

        public TransactionsPool()
        {
            transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions
        {
            get { return transactions; }
        }
        public void AddUser(Transaction transaction)
        {
            transactions.Add(transaction);
        }
    }    
}
