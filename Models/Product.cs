

using System;

namespace Models
{
    public class Product
    {
        private string brand;
        private string name;
        private decimal price;
        private string description;
        public int ProductID { get; set; }
        public string Brand { get{return brand;} set {brand = value;} }
        public string Name { get{return name;} set {name = value;} }
        public decimal Price { get{return price;} set {price = value;} }
        public string Description { get{return description;} set {description = value;} }

         public override string ToString()
        {
            return $"ProductID: {ProductID}\nBrand: {Brand}\nName: {Name}\nPrice: {Price}\nDescription: {Description}";
        }
    }
}