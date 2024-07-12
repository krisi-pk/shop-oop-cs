using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOOP
{
    internal class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        private int quantity;
        public int Quantity {
            get {
                return this.quantity;
            }
            set { 
                quantity = value;
            } 
        }
        public bool IsVip { get; private set; }

        public Product (int productId,string name,double price,int quantity,bool isVip) { 
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;
            IsVip = isVip;
        }
    }
}
