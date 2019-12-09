﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompileError.Model.Model;
using CompilerError.Models;

using AutoMapper;
using CompileError.Manager.Manager;


namespace CompilerError.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
      
        [HttpGet]
        public ActionResult Add()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
           
            string message = "";
            if (ModelState.IsValid)
            {

                Customer customer = Mapper.Map < Customer > (customerViewModel);
              
                if (_customerManager.Add(customer))
                {
                    message = "save";

                }
                else
                {
                    message = "not saved";
                }
            
            }

            customerViewModel.Customers = _customerManager.GetAll();
            ViewBag.Message = message;
            return View(customerViewModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Search(CustomerViewModel customerViewModel)
        {
            var customers = _customerManager.GetAll();
            if (customerViewModel.Code != null)
            {
                customers = customers.Where(c => c.Code.Contains(customerViewModel.Code.ToLower())).ToList();
            }
            if (customerViewModel.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(customerViewModel.Name.ToLower())).ToList();
            }
            customerViewModel.Customers = customers;

            return View(customerViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
           _customerManager.Delete(id);
            return RedirectToAction("Add");

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(_customerManager.Search(id));
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);

        }
        [HttpPost]
        public ActionResult Update(CustomerViewModel customerViewModel)
        {
            Customer customer = Mapper.Map<Customer>(customerViewModel);
            _customerManager.Update(customer);
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
           // return RedirectToAction("Add");

        }

    }
}