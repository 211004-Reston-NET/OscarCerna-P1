using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomerBL _custBL;
        private readonly StoreBL _storeBL;
        private readonly ProductBL _prodBL;
        private readonly LineItemBL _itemBL;

        private readonly OrderBL _orderBL;

        public OrderController(OrderBL p_orderBL, CustomerBL p_custBL, StoreBL p_storeBL, ProductBL p_prodBL, LineItemBL p_itemBL)
        {
            _orderBL = p_orderBL;
            _custBL = p_custBL;
            _storeBL = p_storeBL;
            _prodBL = p_prodBL;
            _itemBL = p_itemBL;
        }
        // GET: OrderController
        public ActionResult Index(int p_id)
        {
            return View();
        }

        public ActionResult GetCustomerOrders(int p_id)
        {
            return View(_orderBL.GetCustomerOrders(p_id)
                        .Select(ord => new OrderVM(ord))
                        .ToList());
        }
        public ActionResult GetStoreOrders(int p_id)
        {
            return View(_orderBL.GetStoreOrders(p_id)
                        .Select(ord => new OrderVM(ord))
                        .ToList());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var customers = _custBL.GetAllCustomer();
            var stores = _storeBL.GetAllStores();

            ViewData["customer"] = customers;
            ViewData["store"] = stores;

            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM order)
        {
            if (ModelState.IsValid)
            {
                _orderBL.AddOrder(new Orders()
                {
                   CustomerId = order.CustomerId,
                   StoreId = order.StoreId,
                   OrderDate = System.DateTime.Now,
                   TotalPrice = order.TotalPrice,

                });

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
