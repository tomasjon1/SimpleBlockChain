using SimpleBlockChain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockChain.Models
{
    class Block
    {
        public string Hash { get; set; }
        public string PreviousHash { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Version { get; set; }
        public string MerkleHash { get; }
        public int Nonce { get; set; } = 0;
        public int Difficulty { get; set; }
        public bool Mined { get; set; } = false;
        public bool Transacted { get; set; } = false;
        public List<Transaction> Transactions { get; set; }

        private readonly HashService hashService = new HashService();

        public Block() { }
        public Block(string previousHash, DateTime timeStamp, string version, int difficulty, List<Transaction> transactions)
        {
            PreviousHash = previousHash;
            TimeStamp = timeStamp;
            Version = version;
            Difficulty = difficulty;

            Transactions = transactions;

            MerkleHash = createMerkleHash();
            Hash = hashService.ComputeSha256Hash((PreviousHash + TimeStamp + MerkleHash) + Nonce);
        }

        public string createMerkleHash()
        {
            StringBuilder sum = new StringBuilder();

            foreach (var transaction in Transactions)
                sum.Append(transaction.TransactionID);

            Console.WriteLine(hashService.ComputeSha256Hash(sum.ToString()));
            return hashService.ComputeSha256Hash(sum.ToString());
        }

        public void mine()
        {
            int nonce = 0;
            string guessHash = hashService.ComputeSha256Hash(hashService.ComputeSha256Hash(PreviousHash + TimeStamp + MerkleHash) + nonce);

            StringBuilder rebuiltHash = new StringBuilder(Hash);
            for (int x = 0; x < Difficulty; x++) rebuiltHash[x] = '0';
            string rebuildedHash = rebuiltHash.ToString();

            if (guessHash.CompareTo(rebuildedHash) > 0)
            {
                nonce++;
                guessHash = hashService.ComputeSha256Hash(hashService.ComputeSha256Hash(PreviousHash + TimeStamp + MerkleHash) + nonce);
            }
            else
            {
                Mined = true;
                Nonce = nonce;
            }
        }
    }
}
