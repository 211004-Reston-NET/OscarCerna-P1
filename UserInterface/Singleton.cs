using Models;

namespace UserInterface
{
    public class Singleton
    {
        public static Customer customer = new Customer();
        public static StoreFront storeFront = new StoreFront();
        public static LineItem lineItems = new LineItem();
        public static Orders orders = new Orders();
        public static Product product = new Product();
        public static Inventory inventory = new Inventory();
 
    }
}