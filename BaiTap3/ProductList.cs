using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class ProductList
    {
        private ArrayList products;

        // Constructor
        public ProductList()
        {
            products = new ArrayList();
        }


        // Thêm một san pham mới vào danh sách
        public void NewProduct(Product product)
        {
            products.Add(product);
        }

        // Lưu danh sách account vào file
        public void SaveFile(string filePath)
        {
            // Xóa tệp tin cũ nếu tồn tại
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            //Đọc file
            try
            {
                //Tạo luồng truy cập file
                FileStream output = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);

                //Thiết lập writer
                StreamWriter writer = new StreamWriter(output);

                //Duyệt qua từng đối tượng trong Accounts
                foreach (Product acc in products) {
                    //Lưu các thông tin của một account trên dòng, phân cách bằng dấu ;
                    writer.WriteLine("{0};{1};{2};{3}", acc.ProductID, acc.NamePD, acc.TypePD, acc.CountPD);
                } 
                //Đóng kết nối
                writer.Close();
                output.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Lấy danh sách account từ file vào danh sách
        public void LoadFile(string filePath)
        {
            try
            {
                //Tạo luồng đọc file
                FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                //Thiết lập reader
                StreamReader reader = new StreamReader(input);

                string str;

                while (!reader.EndOfStream)
                {
                    try
                    {
                        str = reader.ReadLine();

                        string[] list = str.Split(';');

                        int productID = int.Parse(list[0]);
                        string NamePD = list[1];
                        string TypePD = list[2];
                        decimal count = decimal.Parse(list[3]);

                        Product product = new Product(productID, NamePD, TypePD, count);
                        products.Add(product);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid data format in file: " + ex.Message);
                    }
                }

                Console.WriteLine("Accounts loaded from file successfully.");
                //Đóng kết nối
                reader.Close();
                input.Close();
            }               
            catch (IOException ex)
            {
                Console.WriteLine("Error loading accounts from file: " + ex.Message);
            }
        }

        // Xuất ra màn hình tất cả danh sách các account
        public void Report()
        {
            Console.WriteLine("Product Report:");
            foreach (Product product in products)
            {
                product.Query();
                Console.WriteLine("--------------------");
            }
        }

        // Xóa một account khỏi danh sách
        public void RemoveProduct(int productID)
        {
            try
            {
                Product productToFind = new Product(productID);
                int index = products.BinarySearch(productToFind, new AccountComparer());

                if (index >= 0)
                {
                    products.RemoveAt(index);
                    Console.WriteLine("Account with ProductID {0} removed successfully.", productID);
                }
                else
                {
                    Console.WriteLine("Account with ProductID {0} not found.", productID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing account: " + ex.Message);
            }
        }

        public void SortByID()
        {
            products.Sort(new AccountIDComparer());
        }

        public void SortByFirstName()
        {
            products.Sort(new FirstNameCompare());
        }

        public void SortByCount()
        {
            products.Sort(new BalanceCompare());
        }
<<<<<<< HEAD:BaiTap3/ProductList.cs

        public Product FindByID(int productID)
        {
            foreach (Product product in products)
            {
                if (product.ProductID == productID)
                {
                    return product;
=======
        
        public Account FindByID(int accountID)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountID == accountID)
                {
                    return account;
>>>>>>> 4fac511e0d01a67a23e3752699e38d981619e04d:BaiTap3/AccountList.cs
                }
            }
            return null;
        }
<<<<<<< HEAD:BaiTap3/ProductList.cs
        public Product FindByName(string NamePd)
        {
            foreach (Product product in products)
            {
                if (product.NamePD == NamePd)
                {
                    return product;
=======
        public Account FindByFirstName(string firstname)
        {
            foreach (Account account in accounts)
            {
                if (account.FirstName == firstname)
                {
                    return account;
                }
            }
            return null;
        }
        public Account FindByLastName(string lastname)
        {
            foreach (Account account in accounts)
            {
                if (account.LastName == lastname)
                {
                    return account;
                }
            }
            return null;
        }
        public Account FindByBalance(decimal balance)
        {
            foreach (Account account in accounts)
            {
                if (account.Balance == balance)
                {
                    return account;
>>>>>>> 4fac511e0d01a67a23e3752699e38d981619e04d:BaiTap3/AccountList.cs
                }
            }
            return null;
        }
    }
}
