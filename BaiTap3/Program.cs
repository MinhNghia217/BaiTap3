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
            AccountList accountList = new AccountList();
            Account foundAccount;
            bool exit = false;
            bool sort = false;
            bool find = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("||\u001b[33m          ACCOUNT MENU       \u001b[0m||");
                Console.WriteLine("=================================");
                Console.WriteLine("||  \u001b[36m1. Add Account\u001b[0m             ||");
                Console.WriteLine("||  \u001b[36m2. Save Accounts\u001b[0m           ||");
                Console.WriteLine("||  \u001b[36m3. Load Accounts\u001b[0m           ||");
                Console.WriteLine("||  \u001b[36m4. Generate Report\u001b[0m         ||");
                Console.WriteLine("||  \u001b[36m5. Remove Account\u001b[0m          ||");
                Console.WriteLine("||  \u001b[36m6. Sort Account List\u001b[0m       ||");
                Console.WriteLine("||  \u001b[36m7. Find Account List\u001b[0m       ||");
                Console.WriteLine("||  \u001b[36m8. Exit\u001b[0m                    ||");
                Console.WriteLine("=================================");
                Console.Write("Enter your choice (1-8): ");

                string choice = Console.ReadLine();
                string filePath = "C:\\Baitap3\\Data\\accounts.txt";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("=================================");
                        Account newacc = new Account();
                        newacc.FillInfo();
                        accountList.NewAccount(newacc);
                        break;
                    case "2":
                        Console.WriteLine("=================================");
                        accountList.SaveFile(filePath);
                        break;
                    case "3":
                        Console.WriteLine("=================================");
                        accountList.LoadFile(filePath);
                        break;
                    case "4":
                        Console.WriteLine("=================================");
                        accountList.Report();
                        break;
                    case "5":
                        Console.WriteLine("=================================");
                        Console.Write("Enter id account to remove: ");
                        string accountId = Console.ReadLine();
                        accountList.RemoveAccount(int.Parse(accountId));
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
                    Console.WriteLine("||\u001b[33m       SORT ACCOUNT LIST     \u001b[0m||");
                    Console.WriteLine("=================================");
                    Console.WriteLine("||  \u001b[36m1. Sort By Account ID\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m2. Sort By First Name\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m3. Sort By Balance\u001b[0m         ||");
                    Console.WriteLine("||  \u001b[36m4. Exit\u001b[0m                    ||");
                    Console.WriteLine("=================================");
                    Console.Write("Enter your choice (1-4): ");
                    string choiceSort = Console.ReadLine();

                    switch(choiceSort)
                    {
                        case "1":
                            Console.WriteLine("=================================");
                            accountList.SortByID();
                            accountList.Report();
                            break;
                        case "2":
                            Console.WriteLine("=================================");
                            accountList.SortByFirstName();
                            accountList.Report();
                            break;
                        case "3":
                            Console.WriteLine("=================================");
                            accountList.SortByBalance();
                            accountList.Report();
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
                    Console.WriteLine("||  \u001b[36m1. Find By Account ID\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m2. Find By First Name\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m3. Find By Lirst Name\u001b[0m      ||");
                    Console.WriteLine("||  \u001b[36m4. Find By Balance\u001b[0m         ||");
                    Console.WriteLine("||  \u001b[36m5. Exit\u001b[0m                    ||");
                    Console.WriteLine("=================================");
                    Console.Write("Enter your choice (1-4): ");
                    string choiceFind = Console.ReadLine();

                    switch (choiceFind)
                    {
                        case "1":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter ID:");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            foundAccount = accountList.FindByID(ID);
                            if (foundAccount == null)
                            {
                                Console.WriteLine("ID is not valid");
                            }
                            else
                            {
                                foundAccount.Query();
                            }
                            break;
                        case "2":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter first name:");
                            string FirstName = Console.ReadLine();
                            foundAccount = accountList.FindByFirstName(FirstName);
                            if (foundAccount == null)
                            {
                                Console.WriteLine("First name is not valid");
                            }
                            else
                            {
                                foundAccount.Query();
                            }
                            break;
                        case "3":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter last name:");
                            string LastName = Console.ReadLine();
                            foundAccount = accountList.FindByLastName(LastName);
                            if (foundAccount == null)
                            {
                                Console.WriteLine("Last name is not valid");
                            }
                            else
                            {
                                foundAccount.Query();
                            }
                            break;
                        case "4":
                            Console.WriteLine("=================================");
                            Console.WriteLine("Enter Balance:");
                            string temp = Console.ReadLine();
                            decimal Balance = decimal.Parse(temp);
                            foundAccount = accountList.FindByBalance(Balance);
                            if (foundAccount == null)
                            {
                                Console.WriteLine("Balance is not valid");
                            }
                            else
                            {
                                foundAccount.Query();
                            }
                            break;
                        case "5":
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
