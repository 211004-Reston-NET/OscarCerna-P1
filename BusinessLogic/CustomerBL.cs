using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Models;

namespace BusinessLogic
{
    public class CustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer p_cust)
        {
            return _repo.AddCustomer(p_cust);
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> listOfCustomer = _repo.GetAllCustomer();
            return listOfCustomer;
        }
        public Customer GetCustomerByName(string p_name)
        {
                Customer searchResult = _repo.GetCustomerByName(p_name);

                if (searchResult == null)
                {
                    throw new Exception("Customer was not found!");
                }    
                return searchResult;
        }
    }
}