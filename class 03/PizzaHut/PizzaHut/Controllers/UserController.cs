using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models;
using PizzaHut.Models.IRepositories;
using PizzaHut.Models.ViewModels;

namespace PizzaHut.Controllers
{
    public class UserController : Controller
    {

        private IUserRepository users;
        public UserController(IUserRepository repository)
        {
            users = repository;
        }
        public IActionResult Index()
        {
            var model = users.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = users.Get(id);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = model.Name;
                user.Email = model.Email;
                user.City = model.City;
                user.Address = model.Address;
                user.Phone = model.Phone;
                users.Add(user);

                return RedirectToAction("index");
            }
            
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = users.Get(id);
            if (user == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = id.ToString()
                };
            return View("Error", errorViewModel);

            }

            EditUserViewModel editUserViewModel = new EditUserViewModel
            {
                ID = user.ID,
                Name = user.Name,
                Address = user.Address,
                City = user.City,
                Phone = user.Phone,
                Email = user.Email,

            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel model)
        {
            User user = users.Get(model.ID);
            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Address = model.Address;
                user.City = model.City;
                user.Email = model.Email;
                user.Phone = model.Phone;

                users.Update(user);
                return View("Details", user);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            User user = users.Get(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            users.Delete(user.ID);
            return RedirectToAction("Index");
        }
    }
}