using CookingDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingDatabase.ViewComponents
{
    public class CookingListViewComponent : ViewComponent
    {
        private readonly CookingDbContext context;

        public CookingListViewComponent(CookingDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ff = await context.Foods.Take(4).ToListAsync();
             return  View(ff);
        }
    }
}
