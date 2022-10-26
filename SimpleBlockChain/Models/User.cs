using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleBlockChain.Models
{
    class User
    {
        public string Name { get; set; }
        public string PublicKey { get; set; }
        public double Balance { get; set; }

        public User() { }

        public User(string name, string publicKey, double balance)
        {
            Name = name;
            PublicKey = publicKey;
            Balance = balance;
        }
    }
}
