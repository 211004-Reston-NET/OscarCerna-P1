using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM(Inventory p_inv) 
        {
            this.InventoryId = p_inv.Inventory1;
            this.StoreId = p_inv.StoreId;
            this.ProductName = p_inv.ProductName;
            this.ProductBrand = p_inv.ProductBrand;
            this.ProductDescription = p_inv.ProductDescription;
            this.ProductPrice = p_inv.ProductPrice;
            this.Quantity = p_inv.Quantity;
            
        }

        [Key]
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
