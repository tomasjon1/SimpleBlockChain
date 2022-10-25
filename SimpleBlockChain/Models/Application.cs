using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockChain.Models
{
    class Application
    {
        public UsersPool usersPool { get; set; }
        public TransactionsPool transactionsPool { get; set; }

        public Application()
        {
            usersPool = new UsersPool();
            transactionsPool = new TransactionsPool();
        }

        public void run ()
        {
            usersPool.generateUsers();
            usersPool.printAllUsers();

            Console.WriteLine();

            transactionsPool.generateTransactions(usersPool);
            transactionsPool.printAllTransactions();
        }
    }
}
