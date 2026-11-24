using GymMangementSystem.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymMangementSystem.Controllers
{
    public class PlanControllercs : Controller
    {
        private GymDbContext DbContext = new GymDbContext();
        public async Task<IActionResult> Index()
        {
            var plans = await DbContext.Plans.ToListAsync();
            return View(plans);
        }
    }
}
