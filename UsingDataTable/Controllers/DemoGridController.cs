using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingDataTable.Models.Context;
using UsingDataTable.Models.Entities;
using UsingDataTable.Models.Repositories.Abstract;

namespace UsingDataTable.Controllers
{
    public class DemoGridController : Controller
    {
        private ICustomerRepository _customerRepository;
        public DemoGridController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowGrid() => View(_customerRepository.CustomerTB);
        
        
        [HttpGet]
        public IActionResult AddEntity() => View();
        [HttpPost]
        public IActionResult AddEntity(CustomerTB customer)
        {
            _customerRepository.InsertCustomer(customer);
            
            return RedirectToAction("ShowGrid","DemoGrid");
        }

        [HttpGet]
        public IActionResult Update(int id) => View(_customerRepository.GetByID(id));
        [HttpPost]
        public IActionResult Update(CustomerTB customer)
        {
            _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("ShowGrid", "DemoGrid");
        }

        public IActionResult Delete(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction("ShowGrid", "DemoGrid");
        }

    }
}
