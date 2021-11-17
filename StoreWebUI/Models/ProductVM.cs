using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class ProductVM
    {
        public ProductVM()
        {

        }
        public ProductVM(Product product)
        {
            this.ProductId = product.ProductId;
            this.Name = product.ProductName;
            this.Brand = product.ProductBrand;
            this.Price = product.ProductPrice;
            this.Description = product.ProductDescription;
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
