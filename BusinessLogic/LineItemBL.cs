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
        public LineItems AddLineItems(LineItems p_item)
        {
            return _repo.AddLineItems(p_item);
        }
        public List<LineItems> GetAllLineItems()
        {
            List<LineItems> listOfLineItems = _repo.GetAllLineItems();
            return listOfLineItems;
        }
    } 
}