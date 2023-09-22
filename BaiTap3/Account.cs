using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class Account
    {
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }

        // Constructor mặc định (không tham số)
        public Account()
        {
        }

        public Account(int accountID)
        {
            AccountID = accountID;
        }

        // Constructor với tham số
        public Account(int accountID, string firstName, string lastName, decimal balance)
        {
            AccountID = accountID;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        // Phương thức nhập thông tin tài khoản từ bàn phím
        public void FillInfo()
        {
            try
            {
                Console.WriteLine("Enter Account ID: ");
                AccountID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter First Name: ");
                FirstName = Console.ReadLine();

                Console.WriteLine("Enter Last Name: ");
                LastName = Console.ReadLine();

                Console.WriteLine("Enter Balance: ");
                Balance = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid value.");
            }      
        }

        // Phương thức hiển thị thông tin của tài khoản
        public void Query()
        {
            Console.WriteLine("Account ID: " + AccountID);
            Console.WriteLine("First Name: " + FirstName);
            Console.WriteLine("Last Name: " + LastName);
            Console.WriteLine("Balance: " + Balance);
        }

        //public int Compare(object x, object y)
        //{
        //    Account account1 = (Account)x;
        //    Account account2 = (Account)y;

        //    // So sánh theo AccountID
        //    return account1.AccountID.CompareTo(account2.AccountID);
        //}
    }
}
