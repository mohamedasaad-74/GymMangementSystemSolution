
using GymMangementSystem.Context;
using GymMangementSystem.Entities;
using GymMangementSystem.Repositores.Classes;
using GymMangementSystem.Repositores.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymMangementSystem.Controllers
{
    public class PlanController : Controller
    {
        private IPlanRepository _planRepository;

        private readonly IMemberShipRepository _memberShipRepository;

        public PlanController(IPlanRepository planRepository , IMemberShipRepository memberShipRepository)
        {
          _planRepository = planRepository;
            _memberShipRepository = memberShipRepository;
        }
        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetAllAsync();
            ViewData["Hamada"] = "Hamada at route : )";
            ViewBag.Age = 30;
            return View(plans);
        }
        [HttpGet]
        public async Task <IActionResult> Edit(int id , CancellationToken ct)
        {
            var plan =await _planRepository.GetPlanByIdAsync(id);

            if(plan is null ||!plan.IsActive)
            {
                //  return NotFound();
                TempData["ErrorMessage"] = "This Plan can't be Edited";
                return RedirectToAction(nameof(Index));
            }
            var hasCurrentMemberShipsAsync = await _memberShipRepository.AnyAsync(m => m.PlanId == id && m.EndDate> DateTime.Now,ct);

            if(hasCurrentMemberShipsAsync)
            {
                //return BadRequest();
                TempData["ErrorMessage"] = "This Plan has memberships";
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
        public async Task<IActionResult> Edit([FromRoute] int id,Plan UpdatedPlan, CancellationToken ct)
        {
            if (!ModelState.IsValid) return View(UpdatedPlan);
            var plan = await _planRepository.GetPlanByIdAsync(id);
            if (plan is null || !plan.IsActive)
            {
                
                TempData["ErrorMessage"] = "This Plan can't be Edited";
                return RedirectToAction(nameof(Index));
            }
            var hasCurrentMemberShipsAsync = await _memberShipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);

            if (hasCurrentMemberShipsAsync)
            {
               
                TempData["ErrorMessage"] = "This Plan has memberships";
                return RedirectToAction(nameof(Index));
            }
            plan.DurationDays = UpdatedPlan.DurationDays;
            plan.Price= UpdatedPlan.Price;
            plan.Description= UpdatedPlan.Description;
            var result = await _planRepository.UpdateAsync(ct);
            if(result ==0)
            {
                TempData["ErrorMessage"] = "Plan Failed to update";
                return RedirectToAction(nameof(Index));

            }
            TempData["SuccessMessage"] = "Plan updated successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
