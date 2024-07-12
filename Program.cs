using OnlineShopOOP;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShopOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            Product food1 = new Food(1, "Bread", 1.20, 10, false, 500);
            products.Add("Bread", food1);
            Product food2 = new Food(2, "Butter", 5, 20, false, 200);
            products.Add("Butter", food2);
            Product food3 = new Food(3, "Milk", 2.20, 2, false, 250);
            products.Add("Milk", food3);
            Product food4 = new Food(4, "Ice cream", 5.10, 3, true, 800);
            products.Add("Ice cream", food4);
            Product product = new Product(5, "Lipstick", 3.20, 10, false);
            products.Add("Lipstick", product);
            Product clothes1 = new Clothes(6, "Dress", 20.5, 10, false, "pink", "M");
            products.Add("Dress", clothes1);
            Product clothes2 = new Clothes(7, "Jeans", 15.5, 5, false, "light blue", "S");
            products.Add("Jeans", clothes2);
            Product clothes3 = new Clothes(8, "Skirt", 15, 10, true, "blue", "L");
            products.Add("Skirt", clothes3);


            Console.WriteLine("L for login, R for register and 0 for restart");
            string chosen = Console.ReadLine();
            if (chosen.Equals("L")) {
                string username = ValidLogInUsername(customers);
                LogIn(customers, username);
                ShowMenu(customers, products, username);
                Console.WriteLine("Press 0 to logout");
                //start
            }
            else if (chosen.Equals("R")) {
                Register(customers);
                string username = ValidLogInUsername(customers);
                LogIn(customers, username);
                ShowMenu(customers, products, username);
                Console.WriteLine("Press 0 to logout");
                //start
            }
            else {
                Console.WriteLine("Incorrect input");
                //start
            }

            Console.WriteLine();

        }

        public static string ValidLogInUsername(Dictionary<string, Customer> customers) {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            bool isCorrect = customers.ContainsKey(username);
            while (isCorrect == false) {
                Console.WriteLine("This username doesn't exist");
                Console.WriteLine("Username: ");
                username = Console.ReadLine();
                isCorrect = customers.ContainsKey(username);
            }
            return username;
        }

        public static void LogIn(Dictionary<string, Customer> customers, string username) {
            Console.WriteLine("Pass: ");
            string password = Console.ReadLine();
            bool isValid = customers[username].Pass.Equals(password);
            while (isValid == false) {
                Console.WriteLine("Incorrect password");
                Console.WriteLine("Pass: ");
                password = Console.ReadLine();
                isValid = customers[username].Pass.Equals(password);
            }
            Console.WriteLine("Welcome, " + username);
        }



        public static void Register(Dictionary<string, Customer> customers) {
            bool isCorrect = false;
            while (isCorrect == false) {
                Console.WriteLine("Username (up to 10 symbols):");
                string username = Console.ReadLine();
                if (customers.ContainsKey(username)) {
                    Console.WriteLine("This username is taken");
                    continue;
                }
                Console.WriteLine("Pass:");
                string pass = Console.ReadLine();
                Console.WriteLine("First name:");
                string fname = Console.ReadLine();
                Console.WriteLine("Last name:");
                string sname = Console.ReadLine();

                try {
                    Customer customer;
                    if (username.Contains("VIP")) {
                        customer = new VipClient(username, pass, fname, sname);
                        customers.Add(username, customer);
                    }
                    else {
                        customer = new Customer(username, pass, fname, sname);
                        customers.Add(username, customer);
                    }
                    Console.WriteLine("You created your account");
                    Console.WriteLine("You can login with your registration");
                    isCorrect = true;
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public static void ShowMenu(Dictionary<string, Customer> customers, Dictionary<string, Product> products, string user) {
            Console.WriteLine("Type 'view products' to view all products in shop");
            Console.WriteLine("Type 'add' to start adding products in your wish list");
            Console.WriteLine("Type 'wish list' to view your products in wish list");
            Console.WriteLine("Type 'order' to order products");
            Console.WriteLine("Type 'exit' to log out");
            string option = Console.ReadLine(); 
            while(!option.Equals("exit")){
                if (option.Equals("view products"))
                {
                    customers[user].ShowAllProductsInShop(products);
                }
                else if (option.Equals("add")) {
                    Console.WriteLine("Type NameOfProduct Quantity and 'stop' when you're ready");
                    string[] command = Console.ReadLine().Split(' ').ToArray();
                    while (!command[0].Equals("stop")){
                        if (products.ContainsKey(command[0])){
                            string product = command[0];
                            int quantity = Int32.Parse(command[1]);
                            customers[user].productsInShoppingList.AddToUserCard(customers, products, product, quantity, user);
                        }
                        else{
                            Console.WriteLine("Incorrect input");
                        }
                        command = Console.ReadLine().Split(' ').ToArray();
                    }
                }
                else if (option.Equals("wish list")){
                    customers[user].productsInShoppingList.ShowWishList();
                }
                else if (option.Equals("order")){
                    double price = customers[user].productsInShoppingList.CalculatePrice();
                    Console.WriteLine("Your order cost " + price);
                }
                else{
                    Console.WriteLine("Incorrect input");
                }
                option = Console.ReadLine();
            }
        }

    
    }
 }

