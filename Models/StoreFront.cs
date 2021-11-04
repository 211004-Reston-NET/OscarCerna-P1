using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Models
{
    public class StoreFront
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public virtual ICollection<Inventory> Inventories{ get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    
        public override string ToString()
        {
            return $"StoreID: {StoreId}\n Name: {StoreName}\nAddress: {StoreAddress}";
        }
    }
}