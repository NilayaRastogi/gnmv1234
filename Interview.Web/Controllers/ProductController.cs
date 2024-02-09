using Interview.Web.Models;
using Interview.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // NOTE: Sample Action
        //[HttpGet]
        //public Task<IActionResult> GetAllProducts()
        //{
        //    return Task.FromResult((IActionResult)Ok(new object[] { }));
        //}

        [HttpGet]
        public Task<IActionResult> GetProducts(string sku)
        {
            
            return Task.FromResult((IActionResult)Ok(_productRepository.GetProductBySku(sku)));
        }

        [HttpPost]
        public Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
                return Task.FromResult((IActionResult)BadRequest(ModelState));

            var product = _productRepository.GetAll().Where(c => c.Name == newProduct.Name).FirstOrDefault();

            if(product != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return Task.FromResult((IActionResult)StatusCode(422,ModelState));
            }
            _productRepository.Insert(newProduct);
            _productRepository.save();
            return Task.FromResult((IActionResult)Ok(new object[] { }));
        }
    }
}
