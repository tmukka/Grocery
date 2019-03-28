using Grocery.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery
{
    public class GroceryFacade : IGroceryFacade
    {
        public string GetLoggedUserInfo()
        {
            //var groceryDataMapper = new GroceryDataMapper();
            Console.WriteLine("Please Enter the login details");
            Console.WriteLine("Enter login id");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter Password ");
            var uPass = Console.ReadLine();
            string employeeId = GroceryDataMapper.ValidateUser(userName, uPass);
            if (!string.IsNullOrEmpty(employeeId))
            {
                Console.WriteLine("Welcome " + userName);
                return employeeId;
            }
            else
            {
                return "";
            }
        }
        public List<Items> GetItemsBought()
        {
           // var groceryDataMapper = new GroceryDataMapper();
            var itemsBought = new List<Items>();
            int choice;
            var inventory = GroceryDataMapper.GetInventory();
            do
            {
                Console.WriteLine("choose from the list ");
                foreach(Inventory i in inventory)
                {
                    Console.WriteLine(i.item_id + " " + i.item_description);
                }
                Console.WriteLine("Input 0 if you are done selecting items");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice != 0)
                {
                    Items item = new Items();
                    var itemChoosed = inventory.FirstOrDefault(i => i.item_id == choice);
                    item.ItemName = itemChoosed.item_description;
                    Console.WriteLine("Provide the quantity");
                    item.ItemCount = Convert.ToInt32(Console.ReadLine());
                    item.ItemCost = itemChoosed.cost;
                    item.CatId = itemChoosed.Category_id;
                    item.ItemId = itemChoosed.item_id;
                    itemsBought.Add(item);
                }
            }
            while (choice != 0);
            return itemsBought;
        }
        public decimal GenerateBill(List<Items> itemList)
        {
            decimal totalAmount = 0;
            Console.WriteLine("Need to give any special discounts. provide the percent");
            decimal percent = Convert.ToInt32(Console.ReadLine());

            foreach (Items i in itemList)
            {
                totalAmount = totalAmount + i.ItemCost * i.ItemCount;
            }

            foreach (Items i in itemList)
            {
                Console.WriteLine(i.ItemName + " - " + i.ItemCount + " - " + i.ItemCount * i.ItemCost);
            }
            totalAmount = totalAmount - percent * totalAmount / 100;
            Console.WriteLine("Total Amount " + totalAmount);
            return totalAmount;
        }
        public void UpdateOrderTransactions(decimal amount, string eid)
        {
            GroceryDataMapper.RecordOrderTransactions(amount, eid);
        }
        public void UpdateInventory(List<Items> itemList)
        {
            GroceryDataMapper.UpdateInventoryDetails(itemList);
        }
        public List<Items> SpecialDiscounts(List<Items> itemList)
        {
            return GroceryDataMapper.ApplyDiscountAvailable(itemList);
        }
        public void TotalSales()
        {
            var inventory = GroceryDataMapper.GetInventory();
            Console.WriteLine("Inventory list ");
            foreach (Inventory i in inventory)
            {
                Console.WriteLine(i.item_id + " " + i.item_description + " " + i.Quantity);
            }
        }
    }
}
