using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookingDatabase.Controllers
{
    public class FoodController : Controller
    {
        private readonly CookingDbContext context;

        public FoodController(CookingDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var foods = context.Foods;
            return View(foods);
        }
    }
}