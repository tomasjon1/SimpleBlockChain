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

            if (!Directory.Exists(AppContext.BaseDirectory + @"Results\"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"Results\");
            }
            if (File.Exists(AppContext.BaseDirectory + @"Results\Transactions.txt"))
            {
                File.Delete(AppContext.BaseDirectory + @"Results\Transactions.txt");
            }
            if (File.Exists(AppContext.BaseDirectory + @"Results\Blocks.txt"))
            {
                File.Delete(AppContext.BaseDirectory + @"Results\Blocks.txt");
            }
            if (File.Exists(AppContext.BaseDirectory + @"Results\Users.txt"))
            {
                File.Delete(AppContext.BaseDirectory + @"Results\Users.txt");
            }

            usersPool.generateUsers();

            transactionsPool.generateTransactions(usersPool);

            minedBlocks = new List<Block>();

            while (transactionsPool.Transactions.Count > 0)
            {
                Console.WriteLine(transactionsPool.Transactions.Count);

                List<Block> candidates = new List<Block>();

                for (int i = 0; i < 5; i++)
                {
                    string previousHash = "";
                    if (minedBlocks.Count == 0) previousHash = new string('0', 64);
                    else previousHash = minedBlocks[minedBlocks.Count - 1].Hash;

                    candidates.Add(new Block(previousHash, DateTime.Now, "1", 4, transactionsPool.Transactions.GetRange(0, 100)));
                }

                Console.WriteLine("Block mining started!");

                Block minedBlock = new Block();

                Parallel.ForEach(candidates, (block, state) =>
                {
                    block.mine();

                    foreach (Block c in candidates)
                        if(c.Mined)
                        {
                            minedBlock = c;
                            state.Break();
                            break;
                        }    

                });

                int transactionCount = 1;

                if (minedBlock.Mined)
                {
                    Console.WriteLine("Block mined!");
                    List<string> transactions = new List<string>();
                    List<string> failedTransactions = new List<string>();

                    foreach (Transaction t in minedBlock.Transactions)
                    {
                        int sender = usersPool.Users.FindIndex(x => x.PublicKey == t.Sender);
                        int receiver = usersPool.Users.FindIndex(x => x.PublicKey == t.Receiver);

                        if(hashService.ComputeSha256Hash(t.Sender + t.Receiver + t.Amount) == t.TransactionID && usersPool.Users[sender].Balance >= t.Amount)
                        {
                            usersPool.Users[receiver].Balance += t.Amount;
                            usersPool.Users[sender].Balance -= t.Amount;

                            File.AppendAllText(AppContext.BaseDirectory + @"Results\Transactions.txt", $"#{transactionCount} Sender: {usersPool.Users[sender].PublicKey} Receiver: {usersPool.Users[receiver].PublicKey} Amount: {t.Amount} \n");

                            transactionCount++;
                        }
                        else
                        {
                            failedTransactions.Add(t.TransactionID);
                        }
                        transactions.Add(t.TransactionID);
                    }
                    transactionsPool.Transactions.RemoveAll(x => transactions.Contains(x.TransactionID));
                    minedBlock.Transactions.RemoveAll(x => failedTransactions.Contains(x.TransactionID));
                }
                transactionCount--;
                minedBlocks.Add(minedBlock);
                File.AppendAllText(AppContext.BaseDirectory + @"Results\Transactions.txt", $"\n");

                File.AppendAllText(AppContext.BaseDirectory + @"Results\Blocks.txt", $"Hash: {minedBlock.Hash} \nPrevious hash: {minedBlock.PreviousHash} \nTimestamp: {minedBlock.TimeStamp} \nHeight: {minedBlocks.Count} \nNumber of transactions: {minedBlock.Transactions.Count} \nDifficulty: {minedBlock.Difficulty}: \nMerkle root: {minedBlock.MerkleHash} \nVersion: {minedBlock.Version} \nNonce: {minedBlock.Nonce} \n\n");
            }
        }
    }
}
