// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Text.Json;
// using Models;

// namespace DataAccess
// {
//     public class Repository : IRepository
//     {
//         private const string _filepath = "./../DataAccess/Database/";
//         private string jsonString;
//         public Customer AddCustomer(Customer p_cust)
//         {
//             List<Customer> listOfCustomers = GetAllCustomer();
//             listOfCustomers.Add(p_cust);

//             jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented=true});
//             File.WriteAllText(_filepath+"CustomerData.json",jsonString);

//             return p_cust;
//         }
//         public List<Customer> GetAllCustomer()
//         {
//             jsonString = File.ReadAllText(_filepath+"CustomerData.json");
//             return JsonSerializer.Deserialize<List<Customer>>(jsonString);
//         }
//                 public List<Customer> GetCustomer()
//         {        
//             try
//             {
//                 jsonString = File.ReadAllText(_filepath+"CustomerData.json");
//             }
//             catch (System.IO.FileNotFoundException)
//             {    
//                 Console.WriteLine("Customer Not Found");
//             }
//             return JsonSerializer.Deserialize<List<Customer>>(jsonString);      
//         }
//         public StoreFront AddStore(StoreFront p_store)
//         {
//             List<StoreFront> listOfStores = GetAllStores();
//             listOfStores.Add(p_store);

//             jsonString = JsonSerializer.Serialize(listOfStores, new JsonSerializerOptions{WriteIndented=true});
//             File.WriteAllText(_filepath+"StoreData.json",jsonString);

//             return p_store;
//         }
//         public List<StoreFront> GetAllStores()
//         {
//             jsonString = File.ReadAllText(_filepath+"StoreData.json");
//             return JsonSerializer.Deserialize<List<StoreFront>>(jsonString);
//         }
//         public List<StoreFront> GetStore()
//         {
//             try
//             {
//                 jsonString = File.ReadAllText(_filepath+"StoreData.json");    
//             }
//             catch (System.IO.FileNotFoundException)
//             {
//                 Console.WriteLine("Store Not Found");
//             }
//             return JsonSerializer.Deserialize<List<StoreFront>>(jsonString);
//         }
//         public Product AddProduct(Product p_product)
//         {
//             List<Product> listOfProduct = GetAllProduct();
//             listOfProduct.Add(p_product);

//             jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions{WriteIndented=true});
//             File.WriteAllText(_filepath+"ProductData.json",jsonString);

//             return p_product;
//         }
//         public List<Product> GetAllProduct()
//         {
//             jsonString = File.ReadAllText(_filepath+"ProductData.json");
//             return JsonSerializer.Deserialize<List<Product>>(jsonString);
//         }
//         public List<Product> GetProduct()
//         {
//             try
//             {
//                 jsonString = File.ReadAllText(_filepath+"ProductData.json");    
//             }
//             catch (System.IO.FileNotFoundException)
//             {
//                 Console.WriteLine("Product Not Found");
//             }
//             return JsonSerializer.Deserialize<List<Product>>(jsonString);
//         }
//         public Orders AddOrder(Orders p_orders)
//         {
//             List<Orders> listOfOrders = GetAllOrders();
//             listOfOrders.Add(p_orders);

//             jsonString = JsonSerializer.Serialize(listOfOrders, new JsonSerializerOptions{WriteIndented=true});
//             File.WriteAllText(_filepath+"Orders.json",jsonString);

//             return p_orders;
//         }
//         public List<Orders> GetAllOrders()
//         {
//             jsonString = File.ReadAllText(_filepath+"Orders.json");
//             return JsonSerializer.Deserialize<List<Orders>>(jsonString);
//         }
//         public List<Orders> GetOrders()
//         {
//             jsonString = File.ReadAllText(_filepath+"Orders.json");
//             return JsonSerializer.Deserialize<List<Orders>>(jsonString);
//         }
//         public LineItems AddLineItems(LineItems p_items)
//         {
//             List<LineItems> listOfLineItems = GetAllLineItems();
//             listOfLineItems.Add(p_items);

//             jsonString = JsonSerializer.Serialize(listOfLineItems, new JsonSerializerOptions{WriteIndented=true});
//             File.WriteAllText(_filepath+"Products.json",jsonString);

//             return p_items;
//         }
//         public List<LineItems> GetAllLineItems()
//         {
//             jsonString = File.ReadAllText(_filepath+"ProductData.json");
//             return JsonSerializer.Deserialize<List<LineItems>>(jsonString);
//         }
//         public ShoppingCart AddToCart(ShoppingCart p_cart)
//         {
//             return p_cart;
//         }

//         public List<ShoppingCart> GetCart()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }