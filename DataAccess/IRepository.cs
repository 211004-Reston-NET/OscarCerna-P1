using System.Collections.Generic;
using Models;

namespace DataAccess
{
    public interface IRepository
    {
    //CUSTOMER

        /// <summary>
        /// Method will add new Customer to the db
        /// </summary>
        /// <param name="p_cust"> This is the Customer being added </param>
        /// <returns> Return the Customer being added </returns>
        Customer AddCustomer(Customer p_cust);

        /// <summary>
        /// Method returns a list of Customers in the db
        /// </summary>
        /// <returns> Returns a list of Customers </returns>
  
        List<Customer> GetAllCustomer();

        /// <summary>
        /// Method will retrieve a Customer the db
        /// </summary>
        /// <param name="p_name"> This is the Customer being searched </param>
        /// <returns> Return the Customer being search for </returns>
        Customer GetCustomerByName(string p_name);

        /// <summary>
        /// Method will retrieve a Customer the db
        /// </summary>
        /// <param name="p_id"> This is the Customer being searched </param>
        /// <returns> Return the Customer being search for </returns>
        Customer GetCustomerById(int p_id);

    //STORE FRONTS

        /// </summary>
        /// This will return a list of Stores stored in the database
        /// <returns>It will return a Store </returns>
        List<StoreFront> GetAllStores();

        /// <summary>
        /// Method will retrieve a Store the db
        /// </summary>
        /// <param name="p_id"> This is the Store being searched </param>
        /// <returns> Return the Store being search for </returns>
        StoreFront GetStoreById(int p_id);

    //PRODUCTS
        /// <summary>
        /// Method will add new Product to the db
        /// </summary>
        /// <param name="p_prod"> This is the Product being added </param>
        /// <returns> Return the Customer being added </returns>
        Product AddProduct(Product p_prod);

        /// <summary>
        ///  This will return a list of Products from the db.
        /// <returns> will return a list of Products. </returns>
        List<Product> GetAllProduct();

        /// <summary>
        /// Method will retrieve a Product the db
        /// </summary>
        /// <param name="p_id"> This is the Product being searched </param>
        /// <returns> Return the Product being search for </returns>
        Product GetProductById(int p_id);

    //ORDERS
        /// <summary>
        /// Method will add new Order to the db
        /// </summary>
        /// <param name="p_order"> This is the Order being added </param>
        /// <returns> Return the Order being added </returns>
        Orders AddOrder(Orders p_order);

        /// <summary>
        ///  This will return a list of Orders from the db.
        /// <returns> will return a list of Orders. </returns>
        List<Orders> GetAllOrders();

        /// <summary>
        /// Method will retrieve an Customer Order from the db
        /// </summary>
        /// <param name="p_id"> This is the Customer Id being searched </param>
        /// <returns> Return the Order being search for </returns>
        List<Orders> GetStoreOrders(int p_id);
        List<Orders> GetCustomerOrders(int p_id);




        //LINE ITEMS

        /// <summary>
        /// Method will add new Item to the db
        /// </summary>
        /// <param name="p_item"> This is the Item being added </param>
        /// <returns> Return the Item being added </returns>
        LineItem AddLineItems(LineItem p_item);

        /// <summary>
        ///  This will return a list of Items from the db.
        /// <returns> will return a list of Items. </returns>
        List<LineItem> GetAllLineItems();

        /// <summary>
        /// Method will retrieve an Item the db
        /// </summary>
        /// <param name="p_id"> This is the Item being searched </param>
        /// <returns> Return the Item being search for </returns>
        List<LineItem> GetItemById(int p_id);


        //INVENTORY

        /// <summary>
        /// Method will add new Inventory to the db
        /// </summary>
        /// <param name="p_inv"> This is the Inventory being added </param>
        /// <returns> Return the Invent being added </returns>
        Inventory AddInventory(Inventory p_inv);


        /// <summary>
        ///  This will return a list of Inventory from the db.
        /// <returns> will return a list of Inventory. </returns>
        List<Inventory> GetAllInventory();

        /// <summary>
        /// Method will retrieve an Inventory Item the db by Store Id
        /// </summary>
        /// <param name="p_id"> This is the Inventory Item being searched </param>
        /// <returns> Return the Inventory Item being search for </returns>
        List<Inventory> GetInventoryByStoreId(int p_id);

        /// <summary>
        /// Method will retrieve an Inventory Item the db by Store Id
        /// </summary>
        /// <param name="p_id"> This is the Inventory Item being searched </param>
        /// <returns> Return the Inventory Item being search for </returns>
        Inventory GetInventoryByProductId(int p_id);

        /// <summary>
        /// Method will retrieve an Inventory Item the db by Id
        /// </summary>
        /// <param name="p_id"> This is the Inventory Item being searched </param>
        /// <returns> Return the Inventory Item being search for </returns>
        Inventory GetInventoryById(int p_id);


        /// <summary>
        /// This will update the quantity of Inventory
        /// </summary>
        /// <param name="p_inv">This is Inventory that needs updating</param>
        /// <returns>Returns the updated Inventory</returns
        Inventory UpdateInventory(Inventory p_inv);
    }
}