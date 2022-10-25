using SimpleBlockChain.Services;
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
        private readonly UtilytiService utilytiService = new UtilytiService();

        public TransactionsPool()
        {
            transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions
        {
            get { return transactions; }
        }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public void printAllTransactions()
        {
            foreach (var transaction in transactions)
                Console.WriteLine($"{transaction.TransactionID} {transaction.Sender} {transaction.Receiver} {transaction.Amount}");
        }

        public void generateTransactions(UsersPool users)
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
                transactions.Add(
                    new Transaction(
                        utilytiService.generateString(rnd.Next(2, 10)),                            // HASHING
                        users.Users[rnd.Next(10)].PublicKey,
                        users.Users[rnd.Next(10)].PublicKey,                            
                        Math.Round(rnd.NextDouble() * (1000000 - 100) + 100, 2))
                    );
        }
    }    
}
