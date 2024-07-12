using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOOP
{
    internal class Clothes : Product
    {
        public string Color { get; set; }
        public string Size { get; set; }

        public Clothes(int productId, string name, double price, int quantity, bool isVip,string color,string size) : 
            base(productId, name, price, quantity, isVip)
        {
            Color = color;
            Size = size;
        }
    }
}
