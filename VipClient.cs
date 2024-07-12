using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOOP
{
    internal class VipClient : Customer
    {
        public VipClient(string username, string pass,string name, string lastName) :
            base(username, pass, name, lastName)
        {

        }

       
        public override double Descend(double totalSum) {
            double total = totalSum - ((5 * totalSum) / 100);
            return total;
        }

        public override void ShowAllProductsInShop(Dictionary<string, Product> products)
        {
            foreach (KeyValuePair<string, Product> p in products){
                Console.WriteLine(p.Value.Name + p.Value.Price + p.Value.Quantity);
            }
        }
        
    }
}
