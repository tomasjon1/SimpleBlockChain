using SimpleBlockChain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockChain.Models
{
    class UsersPool
    {
        private List<User> users { get; set; }
        private readonly UtilytiService utilytiService = new UtilytiService();
        private readonly HashService hashService = new HashService();


        public UsersPool() 
        {
            users = new List<User>();
        }

        // Setters and Getters
        public List<User> Users 
        { 
            get { return users; }  
        }
        public void AddUser(User user)
        { 
            users.Add(user); 
        }

        // General functions
        public void printAllUsers()
        {
            foreach (var user in users)
                Console.WriteLine($"{user.Name} {user.PublicKey} {user.Balance}" );
        }

        public void generateUsers()
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
                users.Add(new User(
                    utilytiService.generateString(rnd.Next(2,10)),
                    hashService.ComputeSha256Hash(utilytiService.generateString(rnd.Next(10, 20))),  
                    Math.Round(rnd.NextDouble() * (1000000 - 100) + 100, 2)));
        }
    }
}
