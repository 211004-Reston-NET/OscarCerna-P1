using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            LineItems = new HashSet<LineItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
