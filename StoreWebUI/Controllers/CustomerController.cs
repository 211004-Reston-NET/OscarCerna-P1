using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerBL _custBL;
        public CustomerController(CustomerBL p_custBL)
        {
            _custBL = p_custBL;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(CustomerVM p_name)
        {
            return View(new CustomerVM(_custBL.GetCustomerByName(p_name.Name)));
        }

        // GET: CustomerController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerVM custVM)
        {
            if (ModelState.IsValid)
            {
                _custBL.AddCustomer(new Customer()
                {
                    Name = custVM.Name,
                    Address = custVM.Address,
                    Email = custVM.Email,
                    Phone = custVM.Phone,

                });

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
