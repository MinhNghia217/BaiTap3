using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class AccountList
    {
        private ArrayList accounts;

        // Constructor
        public AccountList()
        {
            accounts = new ArrayList();
        }


        // Thêm một account mới vào danh sách
        public void NewAccount(Account account)
        {
            accounts.Add(account);
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
                foreach (Account acc in accounts) {
                    //Lưu các thông tin của một account trên dòng, phân cách bằng dấu ;
                    writer.WriteLine("{0};{1};{2};{3}", acc.AccountID, acc.FirstName, acc.LastName, acc.Balance);
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

                        int accountID = int.Parse(list[0]);
                        string firstName = list[1];
                        string lastName = list[2];
                        decimal balance = decimal.Parse(list[3]);

                        Account account = new Account(accountID, firstName, lastName, balance);
                        accounts.Add(account);
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
            Console.WriteLine("Account Report:");
            foreach (Account account in accounts)
            {
                account.Query();
                Console.WriteLine("--------------------");
            }
        }

        // Xóa một account khỏi danh sách
        public void RemoveAccount(int accountID)
        {
            try
            {
                Account accountToFind = new Account(accountID);
                int index = accounts.BinarySearch(accountToFind, new AccountComparer());

                if (index >= 0)
                {
                    accounts.RemoveAt(index);
                    Console.WriteLine("Account with AccountID {0} removed successfully.", accountID);
                }
                else
                {
                    Console.WriteLine("Account with AccountID {0} not found.", accountID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing account: " + ex.Message);
            }
        }

        public void SortByID()
        {
            accounts.Sort(new AccountIDComparer());
        }

        public void SortByFirstName()
        {
            accounts.Sort(new FirstNameCompare());
        }

        public void SortByBalance()
        {
            accounts.Sort(new BalanceCompare());
        }

    }
}
