using ECommerce.Business.Abstract;
using ECommerce.Entities.Models;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        bool s = false;

        // GET: ProductController
        public async Task<ActionResult> Index(int page = 1, int category = 0)
        {
            var products = await _productService.GetAllByCategory(category);

            int pageSize = 10;

            ProductListViewModel model;

            if (s)
            {
                model = new ProductListViewModel
                {
                    Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    CurrentCategory = category,
                    PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize)),
                    PageSize = pageSize,
                    CurrentPage = page
                };
            }
            else
            {
                model = new ProductListViewModel
                {
                    Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    CurrentCategory = category,
                    PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize)),
                    PageSize = pageSize,
                    CurrentPage = page
                };
            }
            return View(model);
        }

        //public async Task<ActionResult> Index2()
        //{
        //    List<Product> products;
        //    if (productss.Count > 0)
        //    {
        //        products = productss;
        //    }
        //    else
        //    {
        //        products = await _productService.GetAllByCategory(category);
        //    }

        //    int pageSize = 10;

        //    var model = new ProductListViewModel
        //    {
        //        Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
        //        CurrentCategory = category,
        //        PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize)),
        //        PageSize = pageSize,
        //        CurrentPage = page
        //    };
        //    return View(model);
        //}

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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

        public async Task<IActionResult> ProductOrderBy(int page = 1, int category = 0)
        {
            int pageSize = 10;

            var allProduct = await _productService.GetAllByCategory(category);

            var data = allProduct.OrderBy(x => x.ProductName).ToList();

            var viewModel = new ProductListViewModel
            {
                Products = data.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentCategory = category,
                PageCount = ((int)Math.Ceiling(data.Count / (double)pageSize)),
                PageSize = pageSize,
                CurrentPage = page
                //Products = data
            };

            return View("Index", viewModel);
        }
    }

    //public IActionResult ProductOrderByDecending()
    //{

    //}
}
