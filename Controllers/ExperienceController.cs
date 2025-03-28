using EugeneCV.Models;
using EugeneCV.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EugeneCV.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly ICVManagementService _cvManagementService;

        public ExperienceController(ICVManagementService cvManagementService)
        {
            _cvManagementService = cvManagementService;
        }


        // GET: ExperienceController
        [Authorize(Policy = "AdminOrUser")]
        public async Task<ActionResult> Index()
        {
            var experienceList = await _cvManagementService.GetExperienceListAsync();
            return View(experienceList);
        }

        // GET: ExperienceController/Details/5
        [Authorize(Policy = "AdminOrUser")]
        public async Task<ActionResult> Details(int id)
        {
            var experience = await _cvManagementService.GetExperienceByIdAsync(id);

            return View(experience);
        }

        // GET: ExperienceController/Create 
        [Authorize(Policy = "AdminOrUser")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperienceController/Create
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Experience exp)
        {
            
            ModelState.Remove("Descriptions.ExperienceId");

            if (ModelState.IsValid)
            {
                // Log the validation errors

                await _cvManagementService.AddExperienceAsync(exp);

                return RedirectToAction(nameof(Index));

            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    // Here you can log errors or break on them for debugging
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(exp);

        }


        [Authorize(Policy = "AdminOnly")]
        // GET: ExperienceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var experience = await _cvManagementService.GetExperienceByIdAsync(id);

            return View(experience);
        }

        [Authorize(Policy = "AdminOnly")]
        // POST: ExperienceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Experience exp)
        {

            ModelState.Remove("Descriptions.ExperienceId");
            if (ModelState.IsValid)
            {

                await _cvManagementService.UpdateExperienceAsync(exp);

                return RedirectToAction(nameof(Index));
            }
            return View(exp);
        }
        [Authorize(Policy = "AdminOnly")]
        // GET: ExperienceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExperienceController/Delete/5
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
