using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Models;

namespace BusinessLogic
{
    public class ProductBL
    {
        private IRepository _repo;
        public ProductBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Product AddProduct(Product p_product)
        {
            return _repo.AddProduct(p_product);
        }
        public List<Product> GetAllProduct()
        {
            List<Product> listOfProduct = _repo.GetAllProduct();
            return listOfProduct;
        }
        public Product GetProduct(int p_id)
        {
            Product searchCustomer = _repo.GetProduct(p_id);
            return searchCustomer;
        }
    }
}