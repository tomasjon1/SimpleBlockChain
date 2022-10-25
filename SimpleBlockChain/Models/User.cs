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
        private string name { get; set; }
        private string publicKey { get; set; }
        private double balance { get; set; }

        public User() { }

        public User(string name, string publicKey, double balance)
        {
            Name = name;
            PublicKey = publicKey;
            Balance = balance;
        }

        public string Name   
        {
            get { return name; }   
            set { name = value; }  
        } 
        public string PublicKey
        {
            get { return publicKey; }   
            set { publicKey = value; }  
        } 
        public double Balance
        {
            get { return balance; }   
            set { balance = value; }  
        }
    }
}
