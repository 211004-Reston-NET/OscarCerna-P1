using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        //CUSTOMERS
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
        public Customer GetCustomerById(int p_id)
        {
            return _context.Customers.Find(p_id);
        }

        //STORES
        public List<StoreFront> GetAllStores()
        {
            return _context.StoreFronts.ToList();
        }
        public StoreFront GetStoreById(int p_id)
        {
            return _context.StoreFronts.Find(p_id);
        }

        //PRODUCTS

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

        public Product GetProductById(int p_id)
        {
            return _context.Products.Find(p_id);
        }

        //ORDER
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

        public List<Orders> GetCustomerOrders(int p_id)
        {
            return _context.Orders.Where(order => order.CustomerId == p_id)
                                  .ToList();
        }
        public List<Orders> GetStoreOrders(int p_id)
        {
            return _context.Orders.Where(order => order.StoreId == p_id)
                                   .ToList();
        }

        //LINEITEMS
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
        public List<LineItem> GetItemById(int p_id)
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
                              Name = Product.ProductName,
                              Brand = Product.ProductBrand,
                              Description = Product.ProductDescription,
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
                    Quantity = item.Quantity,
                });
            }
            return listOfLineItems;
        }

        //INVENTORY

        public Inventory AddInventory(Inventory p_inv)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetAllInventory()
        {
            var result = (from product in _context.Products
                          join Inventory in _context.Inventory
                          on product.ProductId equals Inventory.ProductId
                          join storeFront in _context.StoreFronts
                          on Inventory.StoreId equals storeFront.StoreId
                          select new
                          {
                              StoreId = storeFront.StoreId,
                              ProductId = product.ProductId,
                              Quantity = Inventory.Quantity,
                              StoreName = storeFront.StoreName,
                              ProductName = product.ProductName,
                              ProductBrand = product.ProductBrand,
                              ProductDescription = product.ProductDescription,
                              Price = product.ProductPrice,

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

        public List<Inventory> GetInventoryByStoreId(int p_id)
        {
            var result = (from product in _context.Products
                          join Inventory in _context.Inventory
                          on product.ProductId equals Inventory.ProductId
                          join storeFront in _context.StoreFronts
                          on Inventory.StoreId equals storeFront.StoreId
                          where storeFront.StoreId == p_id
                          select new
                          {
                              StoreId = storeFront.StoreId,
                              ProductId = product.ProductId,
                              Quantity = Inventory.Quantity,
                              StoreName = storeFront.StoreName,
                              ProductName = product.ProductName,
                              ProductBrand = product.ProductBrand,
                              ProductDescription = product.ProductDescription,
                              Price = product.ProductPrice,

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
        public Inventory GetInventoryById(int p_id)

        {
            return _context.Inventory.Where(inv => inv.InventoryId == p_id)
                                      .SingleOrDefault();
        }
        public Inventory GetInventoryByProductId(int p_id)
        {
            return _context.Inventory.Where(inv => inv.ProductId == p_id)
                                     .SingleOrDefault();
        }
        public Inventory UpdateInventory(Inventory p_inv)
        {
            _context.Inventory.Update(p_inv);
            _context.SaveChanges();
            return p_inv;
        }
    }
}