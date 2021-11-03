using System.Collections.Generic;
using DataAccess;
using Models;

namespace BusinessLogic
{
    public class OrderBL
    {
        private IRepository _repo;
        public OrderBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Orders AddOrder(Orders p_order)
        {
            return _repo.AddOrder(p_order);
        }
        public List<Orders> GetAllOrders()
        {
            List<Orders> listOfOrders = _repo.GetAllOrders();
            return listOfOrders;
        }
        public List<Orders> GetAllStoreOrdersById(int p_id)
        {
            return _repo.GetAllOrdersById(p_id);
         }
    }
}