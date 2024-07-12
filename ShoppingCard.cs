using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOOP
{
    internal class ShoppingCard
    {
        private List<Product> productsInShoppingList;
        public ShoppingCard() {
            productsInShoppingList = new List<Product>();
        }

        private void Add(Product product) {
            productsInShoppingList.Add(product);
        }
        public void AddToUserCard(Dictionary<string, Customer> customers,Dictionary<string, Product> products,string product,int quantity,string user) {
            if (products.ContainsKey(product) && quantity != 0 && quantity < products[product].Quantity){
                for (int i = 0; i < quantity; i++){
                    customers[user].productsInShoppingList.Add(products[product]);
                }
                int newQuantity = products[product].Quantity - quantity;
                products[product].Quantity = newQuantity;
                Console.WriteLine("You added " + product);
            }
            else{
                Console.WriteLine("Invalid product or quantity");
            }                      
        }

        public void RemoveFromCard(Product product){
            productsInShoppingList.Remove(product);
            Console.WriteLine("You removed " + product.Name);
        }

        public double CalculatePrice() {
            double totalPrice = 0;
            for (int i = 0; i < productsInShoppingList.Count; i++)
            {
                totalPrice = totalPrice + productsInShoppingList[i].Price;
            }
            return totalPrice;
        }
        public void ShowWishList(){
            if (productsInShoppingList.Count == 0){
                Console.WriteLine("Your wish list is empty");
            }
            else{
                for (int i = 0; i < productsInShoppingList.Count; i++)
                {
                    Console.WriteLine(productsInShoppingList[i].Name);
                }
            }
        }

    }
}
