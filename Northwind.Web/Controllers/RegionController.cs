using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using Northwind.Web.Models;
using Northwind.Web.Models.RegionModels;
using Northwind.Web.Results;
using Northwind.Web.Results.Region_Results;
using Northwind.Web.IServices;



namespace Northwind.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionServices _regionService;

        public RegionController(IRegionServices regionService)
        {
            _regionService = regionService;
        }

        // GET: RegionController
        public async Task<ActionResult> Index()
        {
            var regionGetListResult = await _regionService.GetRegionAsync();
            if (regionGetListResult != null && regionGetListResult.success)
            {
                return View(regionGetListResult.result);
            }

            ViewBag.Message = regionGetListResult?.message ?? "Error desconocido";
            return View();
        }

        // GET:RegionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var regionGetResult = await _regionService.GetRegionByIdAsync(id);
            if (regionGetResult != null && regionGetResult.success)
            {
                return View(regionGetResult.result);
            }

            ViewBag.Message = regionGetResult?.message ?? "Error desconocido";
            return View();
        }

        // GET: RegionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegionGetModel region)
        {
            var result = await _regionService.CreateRegionAsync(region);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(region);
        }


        // GET: RegionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var regionGetResult = await _regionService.GetRegionByIdAsync(id);
            if (regionGetResult != null && regionGetResult.success)
            {
                return View(regionGetResult.result);
            }

            ViewBag.Message = regionGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: RegionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RegionGetModel region)
        {
            var result = await _regionService.UpdateRegionAsync(id, region);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return View(region);
        }

        // GET: RegionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var regionGetResult = await _regionService.GetRegionByIdAsync(id);
            if (regionGetResult != null && regionGetResult.success)
            {
                return View(regionGetResult.result);
            }

            ViewBag.Message = regionGetResult?.message ?? "Error desconocido";
            return View();
        }

        // POST: RegionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var result = await _regionService.DeleteRegionAsync(id);
            if (result != null && result.success)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = result?.message ?? "Error desconocido";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
