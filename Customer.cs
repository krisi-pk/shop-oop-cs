using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOOP
{
    internal class Customer  
    {
        private string username;
        public ShoppingCard productsInShoppingList;

        public string Username {
            get{
                return this.username;
            }
            private set{
                if (string.IsNullOrEmpty(value) || value.Length > 10)
                {
                    throw new ArgumentException("Invalid username");
                }
            } 
         }
        public string Pass { get; set; }

        private string name;
        public string Name{
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentException("Name cannot be null");
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get{
                return this.lastName;
            }
            private set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentException("Last name cannot be null");
                }
            }
        }

        public Customer(string username,string pass, string name,string lastName) {
            Username = username;
            Pass = pass;
            Name = name;
            LastName = lastName;
            productsInShoppingList = new ShoppingCard();
        }

        public virtual double Descend(double totalSum)
        {
            double total = totalSum - ((5 * totalSum) / 100);
            return total;
        }

        public virtual void ShowAllProductsInShop(Dictionary<string, Product> products){
            foreach (KeyValuePair<string, Product> p in products){
                if (p.Value.IsVip == true){
                    continue;
                } 
                Console.WriteLine(p.Value.Name + " " + p.Value.Price + " " + p.Value.Quantity);
            }
        }
    }
}
