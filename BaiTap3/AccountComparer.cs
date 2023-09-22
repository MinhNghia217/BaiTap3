using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class AccountComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Account account1 = (Account)x;
            Account account2 = (Account)y;

            // So sánh theo AccountID
            return account1.AccountID.CompareTo(account2.AccountID);
        }
    }
}
