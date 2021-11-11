namespace Models
{
    public class Inventory 
    {
        public int Inventory1 { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreFront Store { get; set; }

        public override string ToString()
        {
            return $"ProductID: {ProductId}\n StoreID: {StoreId}\nQuantity: {Quantity}";
        }
    }
}