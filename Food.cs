using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOOP
{
    internal class Food : Product
    {
        public int Grams { get; set; }
        public Food(int productId, string name, double price, int quantity,bool isVip,int grams) :
            base(productId, name, price, quantity, isVip)
        {
            Grams = grams;
        }
    }
}
