using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM()
        {

        }
        public InventoryVM(Inventory inv)
        {
            this.InventoryId = inv.InventoryId;
            this.ProductId = inv.ProductId;
            this.StoreId = inv.StoreId;
            this.Quantity = inv.Quantity;
            this.ProductName = inv.ProductName;
            this.Price = inv.ProductPrice;
        }
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
