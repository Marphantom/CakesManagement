using CakesManagement.Entities;
using CakesManagement.Models.CakeModel;
using CakesManagement.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakesManagement.Controllers
{
    public class CakesController : Controller
    {
        private readonly ICakeService cakeService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private static Category category = new Category();

        public CakesController(ICakeService cakeService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            this.cakeService = cakeService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Route("/Cakes/Index/{catId}")]
        public IActionResult Index(int catId)
        {
            category = categoryService.Get(catId);
            ViewBag.Category = category;
            return View(cakeService.GetProductByCategoryId(catId));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                var cakes = new Cakes()
                {
                    CategoryId = model.CategoryId,
                    CakeName = model.CakeName,
                    Intingredient = model.Intingredient,
                    Expiry = model.Expiry,
                    DateOfManufacture = DateTime.Now,
                    Price = model.Price,
                    Delete = model.Delete,

                };
                if (cakeService.Create(cakes))
                {
                    return RedirectToAction("index", new { catId = category.CategoryId });
                }
            }
            ViewBag.Category = category;
            return View(model);
        }

        [HttpGet]
        [Route("Cakes/Edit/{cakeId}")]
        public IActionResult Edit(int cakeId)
        {
            var cake = cakeService.Get(cakeId);
            var editcake = new Edit()
            {
                CategoryId = cake.CategoryId,
                CakeName = cake.CakeName,
                Intingredient = cake.Intingredient,
                Expiry = cake.Expiry,
                DateOfManufacture = cake.DateOfManufacture,
                Price = cake.Price,
                Delete = cake.Delete,
            };
            ViewBag.Category = category;
            return View(editcake);
        }

        [HttpPost]
        public IActionResult Edit(Edit model)
        {
            if (ModelState.IsValid)
            {
                if (cakeService.Edit(model))
                {
                    return RedirectToAction("Index", "Cakes", new { catId = category.CategoryId });
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("Cakes/Detail/{cakeId}")]
        public IActionResult Detail(int cakeId)
        {
            var cake = cakeService.Get(cakeId);
            var detailCake = new Detail()
            {
                CategoryId = cake.CategoryId,
                CakeName = cake.CakeName,
                Intingredient = cake.Intingredient,
                Expiry = cake.Expiry,
                DateOfManufacture = cake.DateOfManufacture,
                Price = cake.Price,
                Delete = cake.Delete,
                CakeId = cake.CakeId
            };
            ViewBag.Category = category;
            return View(detailCake);
        }

        [HttpGet]
        [Route("Cakes/Remove/{cakeId}")]
        public IActionResult Remove(int cakeId)
        {
            if (cakeService.Remove(cakeId))
            {
                return RedirectToAction("Index", "Cakes", new { catId = category.CategoryId });
            }
            return RedirectToAction("Index", "Detail", new { cakeId = cakeId });
        }
    }
}
