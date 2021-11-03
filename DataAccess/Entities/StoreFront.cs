using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
