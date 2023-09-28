using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class AccountIDComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Product account1 = (Product)x;
            Product account2 = (Product)y;

            // So sánh theo AccountID
            return account1.ProductID.CompareTo(account2.ProductID);
        }
    }
}
