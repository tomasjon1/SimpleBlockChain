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
        public List<Block> minedBlocks { get; set; }

        public Application()
        {
            usersPool = new UsersPool();
            transactionsPool = new TransactionsPool();
        }

        public void run()
        {
            usersPool.generateUsers();
            usersPool.printAllUsers();

            Console.WriteLine();

            transactionsPool.generateTransactions(usersPool);
            transactionsPool.printAllTransactions();

            Console.WriteLine();

            minedBlocks = new List<Block>();

            while (transactionsPool.Transactions.Count > 0)
            {
                string previousHash = "";
                if (minedBlocks.Count == 0) previousHash = new string('0', 64);
                else                        previousHash = minedBlocks[minedBlocks.Count - 1].Hash;

                Block candidate = new Block(previousHash, DateTime.Now, "1", 1, transactionsPool.Transactions.GetRange(0, 100));
                //canditate.mine();
            }
        }
    }
}
