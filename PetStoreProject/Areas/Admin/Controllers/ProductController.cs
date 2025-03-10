﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetStoreProject.Areas.Admin.Service.Cloudinary;
using PetStoreProject.Areas.Admin.ViewModels;
using PetStoreProject.Repositories.Attribute;
using PetStoreProject.Repositories.Brand;
using PetStoreProject.Repositories.Category;
using PetStoreProject.Repositories.Product;
using PetStoreProject.Repositories.ProductCategory;
using PetStoreProject.Repositories.Size;
using System.Linq;

namespace PetStoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly IProductCategoryRepository _productCategory;
        private readonly ICloudinaryService _cloudinary;
        private readonly IAttributeRepository _attribute;
        private readonly ISizeRepository _size;
        private readonly IBrandRepository _brand;

        public ProductController(IProductRepository product, ICategoryRepository category,
            IProductCategoryRepository productCategory, ICloudinaryService cloudinary,
            IBrandRepository brand, IAttributeRepository attribute, ISizeRepository size)
        {
            _product = product;
            _category = category;
            _productCategory = productCategory;
            _cloudinary = cloudinary;
            _brand = brand;
            _attribute = attribute;
            _size = size;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> fetchProduct(int? categoryId, int? productCateId, string? key,
            bool? sortPrice, bool? sortSoldQuantity, bool? isInStock, bool? isDelete,
            int pageNumber = 1, int pageSize = 10)
        {
            var categories = _category.GetCategories();

            categoryId = categoryId == 0 ? null : categoryId;

            var productCategories = _productCategory.GetProductCategories(categoryId);

            pageSize = Math.Min(pageSize, 30);

            ListProductForAdmin listProductForAdmin = await _product.productViewForAdmins(pageNumber, pageSize, categoryId, productCateId,
                                                                                key, sortPrice, sortSoldQuantity, isInStock, isDelete);

            var products = listProductForAdmin.products;
            var totalProduct = listProductForAdmin.totalProducts;

            var totalPageNumber = totalProduct / pageSize + 1;

            return Json(new
            {
                products = products,
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalPageNumber = totalPageNumber,
                categories = categories,
                productCategories = productCategories,
                key = key
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _category.GetCategories();
            var productCategories = _productCategory.GetProductCategories(null);
            var attributes = _attribute.GetAttributes();
            var sizes = _size.GetSizes();
            var brands = _brand.GetBrands();
            ViewData["categories"] = categories;
            ViewData["productCategories"] = productCategories;
            ViewData["attributes"] = attributes;
            ViewData["sizes"] = sizes;
            ViewData["brands"] = brands;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateRequest(string product)
        {
            try
            {
                var productCreateRequest = JsonConvert.DeserializeObject<ProductCreateRequestViewModel>(product);

                var result = await _product.CreateProduct(productCreateRequest);

                return Json(new
                {
                    result = result.Trim()
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    result = e.Message
                });
            }
        }

        [HttpGet]
        public IActionResult Detail(int productId)
        {
            var product = _product.GetProductDetailForAdmin(productId);
            if (product != null && product.ProductOptions != null && product.ProductOptions[0].Attribute.AttributeId != 1)
            {
                var uniqueAttributes = new HashSet<int>();
                var attributes = (from option in product.ProductOptions
                                  where option.Attribute != null && uniqueAttributes.Add(option.Attribute.AttributeId)
                                  select option.Attribute).ToList();
                ViewData["attributes"] = attributes;
            }
            ViewData["product"] = product;
            return View();
        }

        [HttpGet]
        public ActionResult Update(int productId)
        {
            var product = _product.GetProductDetailForAdmin(productId);
            var categories = _category.GetCategories();
            var productCategories = _productCategory.GetProductCategories(null);
            var attributes = _attribute.GetAttributes();
            var sizes = _size.GetSizes();
            var brands = _brand.GetBrands();
            HashSet<int> uniqueImages = new HashSet<int>();
            List<Models.Image> images = (from option in product.ProductOptions
                                         where option.Image != null && uniqueImages.Add(option.Image.ImageId)
                                         select new Models.Image
                                         {
                                             ImageId = option.Image.ImageId,
                                             /*ImageUrl = await _cloudinary.GetBase64Image(option.Image.ImageUrl.Trim())*/
                                             ImageUrl = option.Image.ImageUrl.Trim()
                                         }).ToList();
            ViewData["images"] = images;
            ViewData["categories"] = categories;
            ViewData["productCategories"] = productCategories;
            ViewData["attributes"] = attributes;
            ViewData["sizes"] = sizes;
            ViewData["brands"] = brands;
            ViewData["product"] = product;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UpdateRequest(string updateProductRequest)
        {

            try
            {
                var productUpdateRequest = JsonConvert.DeserializeObject<ProductDetailForAdmin>(updateProductRequest);
                var result = await _product.UpdateProduct(productUpdateRequest);
                return Json(new
                {
                    result = result
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    result = "CLGT" + e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Delete(int productId)
        {
            _product.DeleteProduct(productId);
            return Json(new
            {
                result = "ok"
            });
        }

    }

}
