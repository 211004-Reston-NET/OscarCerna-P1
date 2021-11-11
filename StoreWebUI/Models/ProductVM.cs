using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class ProductVM
    {
        public ProductVM(Product p_prod)
        {
            this.Name = p_prod.ProductName;
            this.Brand = p_prod.ProductBrand;
            this.Description = p_prod.ProductDescription;
            this.Price = p_prod.ProductPrice;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price  { get; set; }

    }
}
