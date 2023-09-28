using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class Product
    {
        public int ProductID { get; set; }
        public string NamePD { get; set; } //NameProduct
        public string TypePD { get; set; }
        public decimal CountPD { get; set; }

        // Constructor mặc định (không tham số)
        public Product()
        {
        }

        public Product(int productID)
        {
            ProductID = productID;
        }

        // Constructor với tham số
        public Product(int productID, string namePD, string typePD, decimal countPD)
        {
            ProductID = productID;
            NamePD = namePD;
            TypePD = typePD;
            CountPD = countPD;
        }

        // Phương thức nhập thông tin tài khoản từ bàn phím
        public void FillInfo()
        {
            try
            {
                Console.WriteLine("Enter Product ID: ");
                ProductID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Name Product: ");
                NamePD = Console.ReadLine();

                Console.WriteLine("Enter Type Product: ");
                TypePD = Console.ReadLine();

                Console.WriteLine("Enter Count of product: ");
                CountPD = Convert.ToDecimal(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid value.");
            }      
        }

        // Phương thức hiển thị thông tin của tài khoản
        public void Query()
        {
            Console.WriteLine("Product ID: " + ProductID);
            Console.WriteLine("Name Product: " + NamePD);
            Console.WriteLine("Name Type: " + TypePD);
            Console.WriteLine("Count: " + CountPD);
        }

        //public int Compare(object x, object y)
        //{
        //    Account account1 = (Account)x;
        //    Account account2 = (Account)y;

        //    // So sánh theo ProductID
        //    return account1.ProductID.CompareTo(account2.ProductID);
        //}
    }
}
