//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Grocery.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventory
    {
        public int item_id { get; set; }
        public string item_description { get; set; }
        public decimal cost { get; set; }
        public int Quantity { get; set; }
        public int Category_id { get; set; }
        public Nullable<decimal> Discounts { get; set; }
    
        public virtual Category Category1 { get; set; }
    }
}
