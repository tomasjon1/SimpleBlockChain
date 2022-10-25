using SimpleBlockChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // test user
            User user = new User();
            user.Name = "TETSAS";
            Console.WriteLine(user.Name);

            // test usersPool
            //UsersPool users = new UsersPool();
            //users.generateUsers();
            //users.printAllUsers();

            // test transactionsPool
            TransactionsPool transactions = new TransactionsPool();
            transactions.generateTransactions();
            transactions.printAllTransactions();
        }
    }
}
