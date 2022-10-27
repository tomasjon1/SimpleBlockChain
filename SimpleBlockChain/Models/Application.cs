using SimpleBlockChain.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly HashService hashService = new HashService();


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
                Console.WriteLine(transactionsPool.Transactions.Count);
                string previousHash = "";
                if (minedBlocks.Count == 0) previousHash = new string('0', 64);
                else                        previousHash = minedBlocks[minedBlocks.Count - 1].Hash;

                Block candidate = new Block(previousHash, DateTime.Now, "1", 1, transactionsPool.Transactions.GetRange(0, 100));
                Console.WriteLine("Block mining started!");

                candidate.mine();

                int transactionCount = 1;

                if (candidate.Mined)
                {
                    Console.WriteLine("Block mined!");
                    List<string> transactions = new List<string>();
                    List<string> failedTransactions = new List<string>();

                    foreach (Transaction t in candidate.Transactions)
                    {
                        int sender = usersPool.Users.FindIndex(x => x.PublicKey == t.Sender);
                        int receiver = usersPool.Users.FindIndex(x => x.PublicKey == t.Receiver);

                        if(hashService.ComputeSha256Hash(t.Sender + t.Receiver + t.Amount) == t.TransactionID && usersPool.Users[sender].Balance >= t.Amount)
                        {
                            usersPool.Users[receiver].Balance += t.Amount;
                            usersPool.Users[sender].Balance -= t.Amount;

                            transactionCount++;
                        }
                        else
                        {
                            failedTransactions.Add(t.TransactionID);
                        }
                        transactions.Add(t.TransactionID);
                    }
                    transactionsPool.Transactions.RemoveAll(x => transactions.Contains(x.TransactionID));
                    candidate.Transactions.RemoveAll(x => failedTransactions.Contains(x.TransactionID));
                }
                transactionCount--;
                minedBlocks.Add(candidate);
            }
        }
    }
}
