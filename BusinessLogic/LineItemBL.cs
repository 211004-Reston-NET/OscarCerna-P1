using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Models;

namespace BusinessLogic
{
    public class LineItemBL
    {
        private IRepository _repo;
        public LineItemBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public LineItem AddLineItems(LineItem p_item)
        {
            return _repo.AddLineItems(p_item);
        }
        public List<LineItem> GetAllLineItems()
        {
            List<LineItem> listOfLineItems = _repo.GetAllLineItems();
            return listOfLineItems;
        }
    } 
}