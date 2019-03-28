using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery
{
    public class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemCost { get; set; }
        public int CatId { get; set; }
    }

}
