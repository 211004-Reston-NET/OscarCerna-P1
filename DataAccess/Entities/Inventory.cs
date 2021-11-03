using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class Inventory
    {
        public int Inventory1 { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreFront Store { get; set; }
    }
}
