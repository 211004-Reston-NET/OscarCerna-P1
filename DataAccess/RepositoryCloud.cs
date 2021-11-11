using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DataAccess
{
    public class RepositoryCloud : IRepository
    {
    private StoreAppDatabaseContext _context;

    public RepositoryCloud(StoreAppDatabaseContext p_context)
    {
        _context = p_context;
    }
    public Customer AddCustomer(Customer p_cust)
        {
            _context.Customers.Add(p_cust);
            _ = _context.SaveChanges();
            return p_cust;
        }
    public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }
    public Customer GetCustomerByName(string p_name)
        {
            return _context.Customers.FirstOrDefault(s => s.Name.Contains(p_name));
        }
      
        public List<StoreFront> GetAllStores()
        {
            return _context.StoreFronts.ToList();
        }
        public StoreFront GetStore(int p_id)
        {
            return _context.StoreFronts.Find(p_id);
        }
        public Product AddProduct(Product p_product)
        {
            _context.Products.Add(p_product);
            _context.SaveChanges();
            return p_product;
        }
        public List<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }
        public Orders AddOrder(Orders p_order)
        {
            _context.Orders.Add(p_order);
           _context.SaveChanges();
           return p_order;
        }
         public List<Orders> GetAllOrders()
         {
            return _context.Orders.ToList();
        }
        public List<Orders> GetAllOrdersById(int p_id)
        {
            return _context.Orders.ToList();
        }
        public LineItem AddLineItems(LineItem p_item)
        {
            _context.LineItems.Add(p_item);
            _context.SaveChanges();
            return p_item;
        }

        public List<LineItem> GetAllLineItems()
        {
            return _context.LineItems.ToList();
        }
            public List<LineItem> GetAllLineItems(int orderId)
        {
            var result = (from Order in _context.Orders
                        join LineItems in _context.LineItems
                        on Order.OrderId equals LineItems.OrderId
                        join Product in _context.Products
                        on LineItems.ProductId equals Product.ProductId
                        where Order.OrderId == Order.OrderId
                        select new
                        {
                            OrderId = Order.OrderId,
                            ProductId = Product.ProductId,
                            Price = Product.ProductPrice,
                            Quantity = LineItems.Quantity,
                        }).ToList(); 

                List<LineItem> listOfLineItems = new List<LineItem>();
                foreach (var item in result)
                {
                    listOfLineItems.Add(new LineItem()
                    {
                        OrderId = item.OrderId,
                        ProductId = item.ProductId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                    });
                }
                    return listOfLineItems;
        }
        public List<Inventory> GetInventoryByStoreId(int p_Id)
        {
            var result = (from product in _context.Products
                         join Inventory in _context.Inventories
                         on product.ProductId equals Inventory.ProductId
                         join storeFront in _context.StoreFronts 
                         on Inventory.StoreId equals storeFront.StoreId
                         where storeFront.StoreId == p_Id
                         select new
                         {
                            StoreName = storeFront.StoreName,
                            ProductName = product.ProductName,
                            ProductBrand = product.ProductBrand,
                            ProductDescription = product.ProductDescription,
                            StoreId = storeFront.StoreId,
                            ProductId = product.ProductId,
                            Price = product.ProductPrice,
                            Quantity = Inventory.Quantity,

                         }).ToList();
                        
            List<Inventory> listOfInventory = new List<Inventory>();
            foreach (var inventory in result)
            {   
                listOfInventory.Add(new Inventory()
                {
                    StoreId = inventory.StoreId,
                    ProductId = inventory.ProductId,
                    Quantity = inventory.Quantity,
                    ProductName = inventory.ProductName,
                    ProductBrand = inventory.ProductBrand,
                    ProductDescription = inventory.ProductDescription,
                    ProductPrice = inventory.Price,

                });
            }
            return listOfInventory;
        }

    }
}