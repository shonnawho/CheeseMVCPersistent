using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.ViewModels;
using CheeseMVC.Models;
using CheeseMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{ 

    public class Category1Controller : Controller
    {
        public IActionResult Index()
        {
            List<CheeseCategory> categories = context.Categories.ToList();
            return View(categories);
        
        }

        private readonly CheeseDbContext context;

        public Category1Controller(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name
                    
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category1");
            }

            return View(addCategoryViewModel);
        }

    }
}