using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class Program
    {
        static void Main(string[] args)
        {

            ProductList productList = new ProductList();
            ProductList findProductList = new ProductList();
            Product findProduct;
            bool exit = false;
            bool sort = false;
            bool find = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("||\u001b[33m          PRODUCT MENU       \u001b[0m||");
                Console.WriteLine("=================================");
                Console.WriteLine("||  \u001b[36m1. Add Product\u001b[0m             ||");
                Console.WriteLine("||  \u001b[36m2. Save Products\u001b[0m           ||");
                Console.WriteLine("||  \u001b[36m3. Load Products\u001b[0m           ||");
                Console.WriteLine("||  \u001b[36m4. Generate Report\u001b[0m         ||");
                Console.WriteLine("||  \u001b[36m5. Remove Product\u001b[0m          ||");
                Console.WriteLine("||  \u001b[36m6. Sort Product List\u001b[0m       ||");
                Console.WriteLine("||  \u001b[36m7. Find Product\u001b[0m            ||");
                Console.WriteLine("||  \u001b[36m8. Exit\u001b[0m                    ||");
                Console.WriteLine("=================================");
                Console.Write("Enter your choice (1-8): ");

                string choice = Console.ReadLine();
                string filePath = "D:\\a Tập\\C#\\BaiTap3\\BaiTap3\\products.txt";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("=================================");
                        Product newacc = new Product();
                        newacc.FillInfo();
                        productList.NewProduct(newacc);
                        break;
                    case "2":
                        Console.WriteLine("=================================");
                        productList.SaveFile(filePath);
                        break;
                    case "3":
                        Console.WriteLine("=================================");
                        productList.LoadFile(filePath);
                        break;
                    case "4":
                        Console.WriteLine("=================================");
                        productList.Report();
                        break;
                    case "5":
                        Console.WriteLine("=================================");
                        Console.Write("Enter id Product to remove: ");
                        string productID = Console.ReadLine();
                        productList.RemoveProduct(int.Parse(productID));
                        break;
                    case "6":
                        Console.WriteLine("=================================");
                        sort = true;
                        break;
                    case "7":
                        Console.WriteLine("=================================");
                        find = true;
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }


                while(sort)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("||\u001b[33m       SORT PRODUCT LIST     \u001b[0m||");
                    Console.WriteLine("=================================");
                    Console.WriteLine("||  \u001b[36m1. Sort By Product ID\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m2. Sort By Product name\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m3. Sort By Count\u001b[0m         ||");
                    Console.WriteLine("||  \u001b[36m4. Exit\u001b[0m                    ||");
                    Console.WriteLine("=================================");
                    Console.Write("Enter your choice (1-4): ");
                    string choiceSort = Console.ReadLine();

                    switch(choiceSort)
                    {
                        case "1":
                            Console.WriteLine("=================================");
                            productList.SortByID();
                            productList.Report();
                            break;
                        case "2":
                            Console.WriteLine("=================================");
                            productList.SortByFirstName();
                            productList.Report();
                            break;
                        case "3":
                            Console.WriteLine("=================================");
                            productList.SortByCount();
                            productList.Report();
                            break;
                        case "4":
                            sort = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }

                while (find)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("||\u001b[33m       FIND ACCOUNT LIST     \u001b[0m||");
                    Console.WriteLine("=================================");
                    Console.WriteLine("||  \u001b[36m1. Find By Product ID\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m2. Find By Name\u001b[0m            ||");
                    Console.WriteLine("||  \u001b[36m4. Exit\u001b[0m                    ||");
                    Console.WriteLine("=================================");
                    Console.Write("Enter your choice (1-3): ");
                    string choiceFind = Console.ReadLine();

                    switch (choiceFind)
                    {
                        case "1":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter ID:");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            findProduct = productList.FindByID(ID);
                            if (findProduct == null)
                            {
                                Console.WriteLine("Product ID is not valid");
                            }
                            else
                            {
                                findProduct.Query();
                            }
                            break;
                        case "2":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter Name Product:");
                            string Name = Console.ReadLine();
                            findProduct = productList.FindByName(Name);
                            if (findProduct == null)
                            {
                                Console.WriteLine("Product is not valid");
                            }
                            else
                            {
                                findProduct.Query();
                            }
                            break;
                        case "4":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter Type Product:");
                            string Name = Console.ReadLine();
                            findProductList = productList.FindByType(type);
                            if (findProductList.countProductList()==0)
                            {
                                Console.WriteLine("Product is not valid");
                            }
                            else
                            {
                                findProductList.Report();
                            }
                            break;
                        case "3":
                            find = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
