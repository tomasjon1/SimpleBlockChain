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
                    generateString(rnd.Next(2,10)), 
                    generateString(rnd.Next(10, 20)),                            // HASHING
                    Math.Round(rnd.NextDouble() * (1000000 - 100) + 100, 2)));
        }

        public string generateString(int size)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
