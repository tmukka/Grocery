//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Grocery
//{
//    class Customer
//    {
//        public string name;
//        public string phone;

//        public void GetCustomerInfo()
//        {
//            Console.WriteLine("Please Enter the Name and Phone number");
//            name = Console.ReadLine();
//            phone = Console.ReadLine();
//        }

//        public List<Items> GetItemsBought()
//        {
//            var itemsBought = new List<Items>();
//            //var inventoryMetadata = Inventory.ItemDescriptionMetadata();
//            int choice;
//            do
//            {
//                Console.WriteLine("choose from the list 1.Chips 2.Biscuits 3. Done");
//                choice = Convert.ToInt32(Console.ReadLine());
//                if(choice == 1 )
//                {
//                    Items i = new Items();
//                    Console.WriteLine("Type the item name 1. Lays 2. Bingo");
//                    i.ItemName = Console.ReadLine();
//                    Console.WriteLine("Provide the quantity");
//                    i.ItemCount = Convert.ToInt32(Console.ReadLine());
//                    i.ItemCost = inventoryMetadata.First(a => a.itemName == i.ItemName).cost;
//                    itemsBought.Add(i);
//                }
//                else if(choice == 2)
//                {
//                    Items i = new Items();
//                    Console.WriteLine("1. Oreo 2. ParleG");
//                    i.ItemName = Console.ReadLine();
//                    Console.WriteLine("Provide the quantity");
//                    i.ItemCount = Convert.ToInt32(Console.ReadLine());
//                    i.ItemCost = inventoryMetadata.First(a => a.itemName == i.ItemName).cost;
//                    itemsBought.Add(i);
//                }
//            }
//            while (choice != 3);
//            return itemsBought;
//        }
//    }
//}
