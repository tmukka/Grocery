using Grocery.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery
{
    public static class GroceryDataMapper
    {
     
        public static string ValidateUser(string uName, string uPass)
        {
            using (var context = new GroceryEntities())
            {
                var userLogged = context.Employees.FirstOrDefault(i => i.Employee_Name == uName && i.Password == uPass );
                if(userLogged != null)
                {
                    return userLogged.Employee_id;
                }
                else
                {
                    return "";
                }
            }
        }

        public static List<Inventory> GetInventory()
        {
            using (var context = new GroceryEntities())
            {
                return context.Inventories.ToList();
            }
        }

        public static List<Items> ApplyDiscountAvailable(List<Items> itemList)
        {
            using (var context = new GroceryEntities())
            {
                foreach (Items item in itemList)
                {
                    var discountOnItem = context.Inventories.FirstOrDefault(i => i.item_id == item.ItemId);
                    item.ItemCost = item.ItemCost - (discountOnItem.Discounts.HasValue ? discountOnItem.Discounts.Value * item.ItemCost / 100 : 0);
                }
            }
            return itemList;
        }

        public static void UpdateInventoryDetails(List<Items> itemList)
        {
            using (var context = new GroceryEntities())
            {
                foreach (Items item in itemList)
                {
                    var discountOnItem = context.Inventories.FirstOrDefault(i => i.item_id == item.ItemId);
                    discountOnItem.Quantity = discountOnItem.Quantity - item.ItemCount;
                }
                context.SaveChanges();
            }
        }

        public static void RecordOrderTransactions(decimal amount, string eid)
        {
            using (var context = new GroceryEntities())
            {
                var maxID = context.ORDERS.Any() ? context.ORDERS.OrderByDescending(x => x.ORD_NUM).First().ORD_NUM : 0;
                var order = context.ORDERS.Add(context.ORDERS.Create());
                maxID = maxID + 1;
                order.ORD_NUM = maxID;
                order.Employee_id = eid;
                order.ORD_DATE = DateTime.Now;
                order.ORD_AMOUNT = amount;
                context.SaveChanges();
            }
        }
    }
}
