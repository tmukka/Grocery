using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery
{
    public interface IGroceryFacade
    {
        string GetLoggedUserInfo();
        List<Items> GetItemsBought();
        decimal GenerateBill(List<Items> items);
        void UpdateOrderTransactions(decimal amount, string employeeId);
        void UpdateInventory(List<Items> items);
        List<Items> SpecialDiscounts(List<Items> items);
        void TotalSales();
    }
}
