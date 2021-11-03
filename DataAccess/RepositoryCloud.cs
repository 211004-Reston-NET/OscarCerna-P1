using System.Collections.Generic;
using System.Linq;
using Models;
using Entity = DataAccess.Entities;
using Model = Models;  

namespace DataAccess
{
    public class RepositoryCloud : IRepository
    {
    private Entity.StoreAppDatabaseContext _context;

    public RepositoryCloud(Entity.StoreAppDatabaseContext p_context)
    {
        _context = p_context;
    }
    public Model.Customer AddCustomer(Model.Customer p_cust)
        {
            _context.Customers.Add
            (
                new Entity.Customer()
                {
                    CustomerName = p_cust.Name,
                    CustomerAddress = p_cust.Address,
                    CustomerEmail = p_cust.Email,
                    CustomerPhone = p_cust.Phone,
                }
            );
            _context.SaveChanges();
            return p_cust;
        }
    public List<Model.Customer> GetAllCustomer()
        {
            return _context.Customers.Select(cust => new Model.Customer()
            {
                Name = cust.CustomerName,
                Address = cust.CustomerAddress,
                Email = cust.CustomerEmail,
                Phone = cust.CustomerPhone,
            }
            ).ToList();
        }
    public Model.Customer GetCustomer(int p_id)
        {
            Entity.Customer custToFind = _context.Customers.Find(p_id);
            return new Model.Customer()
            {
            CustomerId = custToFind.CustomerId,
            Name = custToFind.CustomerName,
            Address = custToFind.CustomerAddress,
            Email = custToFind.CustomerEmail,
            Phone = custToFind.CustomerPhone,
            
            Orders = custToFind.Orders.Select(order => new Model.Orders()
            {
                OrderID = order.OrderId,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
            }).ToList()

            };
        }
      
        public List<Model.StoreFront> GetAllStores()
        {
            return _context.StoreFronts.Select(store => new Model.StoreFront()
            {
                StoreID = store.StoreId,
                Name = store.StoreName,
                Address = store.StoreAddress,
            }
            ).ToList();
        }
        public Model.StoreFront GetStore(int p_id)
        {
            Entity.StoreFront storeToFind = _context.StoreFronts.Find(p_id);
            return new Model.StoreFront()
            {
                StoreID = storeToFind.StoreId,
                Name = storeToFind.StoreName,
                Address = storeToFind.StoreAddress, 
            };
        }
        public Model.Product AddProduct(Model.Product p_product)
        {
            _context.Products.Add
            (
                new Entity.Product()
                {
                    ProductName = p_product.Name,
                    ProductBrand = p_product.Brand,
                    ProductPrice = p_product.Price,
                    ProductDescription = p_product.Description,      
                }
            );
            _context.SaveChanges();
            return p_product;
        }
        public List<Model.Product> GetAllProduct()
        {
            return _context.Products.Select(prod => new Model.Product()
            {
                ProductID = prod.ProductId,
                Name = prod.ProductName,
                Brand = prod.ProductBrand,
                Price = prod.ProductPrice,
                Description = prod.ProductDescription,
            }
            ).ToList();
        }
        public Model.Product GetProduct(int p_id)
        {
            Entity.Product productToFind = _context.Products.Find(p_id);
            return new Model.Product()
            {
                ProductID = productToFind.ProductId,
                Name = productToFind.ProductName,
                Brand = productToFind.ProductBrand,
                Price = productToFind.ProductPrice,
                Description = productToFind.ProductDescription,
            };
        }
        public Model.Orders AddOrder(Model.Orders p_order)
        {
            _context.Orders.Add
            (
                new Entity.Order()
                {
                    CustomerId = p_order.CustomerID,
                    StoreId = p_order.StoreID,
                    TotalPrice = p_order.TotalPrice,
                    OrderDate = System.DateTime.Today,
                }
            );
           _context.SaveChanges();
           return p_order;
        }
         public List<Orders> GetAllOrders()
         {
            return _context.Orders.Select(order => new Model.Orders()
            {
                OrderID = order.OrderId,
                OrderDate = order.OrderDate,
            }
            ).ToList();
        }
        public List<Orders> GetAllOrdersById(int p_id)
        {
            return _context.Orders.Where(order => order.StoreId == p_id)
                    .Select(order => new Model.Orders(){
                        OrderID = order.OrderId,
                        StoreID = order.StoreId,
                        CustomerID = order.CustomerId,
                        TotalPrice = order.TotalPrice,
                        OrderDate = order.OrderDate,
                    }).ToList();
        }
        public Model.LineItems AddLineItems(Model.LineItems p_item)
        {
            _context.LineItems.Add
            (
                new Entity.LineItem()
                {
                    ProductId = p_item.ProductID,
                    OrderId = p_item.OrderID,
                    Quantity = p_item.Quantity,     
                }
            );
            _context.SaveChanges();
            return p_item;
        }

        public List<Model.LineItems> GetAllLineItems()
        {
            return _context.LineItems.Select(items => new Model.LineItems()
            {
                ProductID = items.ProductId,
                OrderID = items.OrderId,
                Quantity = items.Quantity,
            }
            ).ToList();
        }
            public List<LineItems> GetAllLineItems(int orderId)
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
                            Quantity = LineItems.Quantity,
                        }).ToList(); 

                List<Model.LineItems> listOfLineItems = new List<Model.LineItems>();
                foreach (var item in result)
                {
                    listOfLineItems.Add(new Model.LineItems()
                    {
                        OrderID = item.OrderId,
                        ProductID = item.ProductId,
                        Quantity = item.Quantity,
                    });
                }
                    return listOfLineItems;
        }
        public List<Model.Inventory> GetInventory(int storeid)
        {
            var result = (from product in _context.Products
                         join Inventory in _context.Inventories
                         on product.ProductId equals Inventory.ProductId
                         join storeFront in _context.StoreFronts 
                         on Inventory.StoreId equals storeFront.StoreId
                         where storeFront.StoreId == storeid
                         select new
                         {
                            StoreName = storeFront.StoreName,
                            ProductName = product.ProductName,
                            ProductBrand = product.ProductBrand,
                            StoreId = storeFront.StoreId,
                            ProductId = product.ProductId,
                            Price = product.ProductPrice,
                            Quantity = Inventory.Quantity,

                         }).ToList();
                        
            List<Model.Inventory> listOfInventory = new List<Model.Inventory>();
            foreach (var inventory in result)
            {   
                listOfInventory.Add(new Model.Inventory()
                {
                    ProductName = inventory.ProductName,
                    ProductBrand = inventory.ProductBrand,
                    StoreName = inventory.StoreName,
                    StoreId = inventory.StoreId,
                    ProductId = inventory.ProductId,
                    Quantity = inventory.Quantity,
                    Price = inventory.Price,
                });
            }
            return listOfInventory;
        }
    }
}