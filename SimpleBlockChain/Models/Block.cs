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
        public List<Transaction> Transactions { get; set; }
    }
}
