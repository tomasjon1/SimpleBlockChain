using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockChain.Models
{
    class Application
    {
        public UsersPool users { get; set; }
        public TransactionsPool transactions { get; set; }

        public Application()
        {
            users = new UsersPool();
            transactions = new TransactionsPool();
        }

        public void run ()
        {
            users.generateUsers();
            users.printAllUsers();

            Console.WriteLine();

            transactions.generateTransactions(users);
            transactions.printAllTransactions();
        }
    }
}
