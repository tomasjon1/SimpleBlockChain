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

        public Block() { }
        public Block(string hash, string previousHash, DateTime timeStamp, string version, string merkleHash, int nonce, int difficulty, bool mined, bool transacted, List<Transaction> transactions)
        {
            Hash = hash;                    
            PreviousHash = previousHash;
            TimeStamp = timeStamp;
            Version = version;
            MerkleHash = merkleHash;
            Nonce = nonce;
            Difficulty = difficulty;
            Mined = mined;
            Transacted = transacted;
            Transactions = transactions;
        } // Sis gal ir nereikalingas  ARBA ne visi fieldai reikalingi
    }
}
