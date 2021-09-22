using CheckingEmployees_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheckingEmployees_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly FormAbsenceGetDataRepository _getDataRepository;
        private readonly FormAbsenceChangeDataRepository _changeDataRepository;

        public HomeController(FormAbsenceGetDataRepository getDataRepository
            , FormAbsenceChangeDataRepository changeDataRepository)
        {
            _getDataRepository = getDataRepository;
            _changeDataRepository = changeDataRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _getDataRepository.GetAllAsync();
            if (result.Count != 0)
                return View(result);
            return Content("Ничего нет");
        }

        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                FormAbsence form = new FormAbsence
                {
                    Reason = (Causes)model.Reason,
                    StartDate = model.StarDate,
                    Duration = model.Duration,
                    Discounted = model.Discounted,
                    Description = model.Description
                };
                var result = await _changeDataRepository.CreateDataAsync(form);
                if (result == null)
                    return Content("кажется не получилось");
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var model = await _getDataRepository.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(FormAbsence model)
        {
            if (ModelState.IsValid)
            {
                var result = await _changeDataRepository.UpdateDataAsync(model);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _getDataRepository.GetByIdAsync(id);
            var result = await _changeDataRepository.DeleteDataAsync(model);
            if (result != 0)
                return RedirectToAction("Index");
            return Content("result == 0");
        }
    }
}
