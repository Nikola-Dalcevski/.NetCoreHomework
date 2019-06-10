using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models;

namespace PizzaHut.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> Employees;

        public EmployeeController()
        {
            Employees = new List<Employee>()
            {
                new Employee{ID = 1, FirstName = "Nikola", LastName = "Dalcevski", City="Skopje", HireDate=new DateTime(2017,02,10)},
                new Employee{ID = 2, FirstName = "Vukasin", LastName = "Obradovxc", City="Veles", HireDate=new DateTime(2016,04,11)},
                new Employee{ID = 2, FirstName = "Kristina", LastName = "Spaasovska", City="Skopje", HireDate=new DateTime(2016,04,11)},
                new Employee{ID = 2, FirstName = "Marija", LastName = "dadada", City="Skopje", HireDate=new DateTime(2016,04,11)},
                new Employee{ID = 3, FirstName = "Venko", LastName = "Venkovski", City="Gostivar", HireDate=new DateTime(2018,04,13)},
            };

        }


        public IActionResult Index()
        {
            var test = Employees.Where(emp => emp.City == "Gostivar").First().FirstName;
            ViewData["Gostivar"] = test;
            ViewBag.TotalEmployees = Employees.Count();
            return View(Employees);
        }

        public IActionResult Details(int id)
        {
            Employee employee = Employees.FirstOrDefault(x => x.ID == id);
            return View(employee);
        }

        public IActionResult Create(int id)
        {
            return View();
        }
    
    }
}