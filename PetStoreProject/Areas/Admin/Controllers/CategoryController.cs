﻿using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Models;
using PetStoreProject.Repositories.Brand;
using PetStoreProject.Repositories.Category;

namespace PetStoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        private readonly IBrandRepository _brand;

        public CategoryController(ICategoryRepository category, IBrandRepository brand)
        {
            _category = category;
            _brand = brand;
        }
        [HttpGet]
        public IActionResult List()
        {
            var categories = _category.GetListCategory();
            ViewData["categories"] = categories;
            var brands = _brand.GetListBrand();
            ViewData["brands"] = brands;
            return View();
        }

        [HttpPost]
        public JsonResult Create(string CategoryName, string BrandName)
        {
            var cateId = _category.CreateCategory(CategoryName);
            return Json(new { cateId = cateId });
        }

    }
}

