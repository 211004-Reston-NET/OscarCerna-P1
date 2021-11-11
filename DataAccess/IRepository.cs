using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IRepository
    {
//CUSTOMER
        /// It will add a Customer in our database
        /// </summary>
        /// <param name="p_cust">This is the Customer we will be adding to the database</param>
        /// <returns>It will just return the Customer we are adding</returns>
        Customer AddCustomer(Customer p_cust);

        /// This will return a list of Customers stored in the database
        /// </summary>
        /// <returns>It will return a list of Customers</returns>
        List<Customer> GetAllCustomer();

        /// <summary>
        /// This will search for Customer in database 
        /// </summary>
        /// <param name="p_name"> Will locate the customer by name</param>
        /// <returns></returns>
        Customer GetCustomerByName(string p_name);

//STORE FRONTS

        /// This will return a list of Stores stored in the database
        /// </summary>
        /// <returns>It will return a Store </returns>
        List<StoreFront> GetAllStores();

        /// This will return a Store stored in the database
        /// </summary>
        /// <returns>It will return a Store </returns>
        StoreFront GetStore(int p_id);

//PRODUCTS
        /// It will add an Product in our database
        /// </summary>
        /// <param name="p_product">This is the Product we will be adding to the database</param>
        /// <returns>It will just return the product we are adding</returns>
        Product AddProduct(Product p_product);

        /// <summary>
        ///  This will return a list of products from the db.
        /// </summary>
        /// <returns> will return a list of products. </returns>
        List<Product> GetAllProduct();
        
    
//ORDERS
        /// It will add an Order in our database
        /// </summary>
        /// <param name="p_orders">This is the Order we will be adding to the database</param>
        /// <returns>It will just return the Order we are adding</returns>
        Orders AddOrder(Orders p_newOrder);
        List<Orders> GetAllOrders();
        List<Orders> GetAllOrdersById(int p_id);
    
//LINE ITEMS

        LineItem AddLineItems(LineItem p_item);
        /// <summary>
        ///  This will return a list of products from the db.
        /// </summary>
        /// <returns> will return a list of products. </returns>
        List<LineItem> GetAllLineItems();
        List<LineItem> GetAllLineItems(int orderId);

//INVENTORY
        /// <summary>
        /// Will give Inventory List for a specific store
        /// </summary>
        /// <param name="p_Id">This is the store id</param>
        /// <returns> Returns the list of products associated to that store </returns>
        List<Inventory> GetInventoryByStoreId(int p_id);

    }
}