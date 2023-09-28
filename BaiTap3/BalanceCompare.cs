using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class BalanceCompare :IComparer
    {
        public int Compare(object? x, object? y)
        {
            Product account1 = (Product)x;
            Product account2 = (Product)y;

            // So sánh theo AccountID
            return account1.CountPD.CompareTo(account2.CountPD);
        }
    }
}
