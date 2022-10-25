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
            UsersPool users = new UsersPool();
            users.generateUsers();
            users.printAllUsers();

            TransactionsPool transactions = new TransactionsPool();
            transactions.generateTransactions();
            transactions.printAllTransactions();
        }
    }
}
