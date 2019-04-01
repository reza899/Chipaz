using Microsoft.AspNetCore.Mvc;
using CookingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CookingDatabase.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HomeController:Controller
    {
        const int PageSize = 10;
        private readonly CookingDbContext context;

        public HomeController(CookingDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string search="",OrderType order=OrderType.Name,
            SortType sort= SortType.Asc,MadenType maden= MadenType.None,int PageNumber=1)
        {
            IEnumerable<Food> data;
            if (string.IsNullOrWhiteSpace(search))
            {
                data = context.Foods;
            }
            else
            {
                 data = context.Foods.Where(x => x.Name.Contains(search));
            }

            switch (order)  
            {
                case OrderType.Name:
                    data = data.OrderBy(k => k.Name);
                    break;
                case OrderType.Id:
                    data = data.OrderBy(k => k.Id);
                    break;
                default:
                    break;
            }

            if(sort==SortType.Desc)
            {
                data = data.Reverse();
                sort = SortType.Asc;
            }
            else
            {
                sort = SortType.Desc;
            }

            if(maden!=MadenType.None)
            {
                data = data.Where(x => x.Maden == maden);
            }
            var count = data.Count();
           data= data.Skip((PageNumber - 1) * PageSize).Take(PageSize);

            var vm = new FoodIndexModel()
            {
                Foods = data,
                Maden = maden,
                Sort=sort,
                Search=search,
                PageNumber=PageNumber,
                PageSize=PageSize,
                PageCount=count/PageSize+1,
                Order=order
            };
            return View(vm);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            context.Foods.Add(food);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var food = context.Foods.Find(id);
            return View(food);
        }

        public IActionResult Edit(int id)
        {
            var food = context.Foods.Find(id);
            return View(food);
        }
        [HttpPost]
        public IActionResult Edit(Food food)
        {
            //var fd = context.Foods.Find(food.Id);
            //fd.Name = food.Name;
            //fd.Description = food.Description;
            context.Entry(food).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var food = context.Foods.Find(id);
            return View(food);
        }
        [HttpPost]
        public IActionResult Delete(Food food)
        {
            //context.Foods.Remove(food);
            context.Entry(food).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
