using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Grocery
{
    public class Program
    {
        private readonly IGroceryFacade facade;
        public Program(IGroceryFacade _facade)
        {
            facade = _facade;
        }
        static void Main(string[] args)
        {
            //Dependency Injection via Unity
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IGroceryFacade, GroceryFacade>();

            Program startUp = unityContainer.Resolve<Program>();
            bool login = false;
            decimal totalAmount;
            string employeeId;
            //login functionality
            do
            {
                employeeId = startUp.facade.GetLoggedUserInfo();
                if (!string.IsNullOrEmpty(employeeId)) login = true;
            }
            while (login == false);
            var itemslist = startUp.facade.GetItemsBought();

            itemslist = startUp.facade.SpecialDiscounts(itemslist);
            totalAmount = startUp.facade.GenerateBill(itemslist);
            startUp.facade.UpdateOrderTransactions(totalAmount, employeeId);
            startUp.facade.UpdateInventory(itemslist);
            Console.WriteLine("To check Available items in inventory. Press 1");

            if(Convert.ToInt32(Console.ReadLine()) == 1)
            {
                startUp.facade.TotalSales();
            }
            Console.ReadKey();


        }
    }
}
