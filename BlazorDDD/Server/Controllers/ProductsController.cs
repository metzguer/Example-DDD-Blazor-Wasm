using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDDD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductApp _productApp;
        public ProductsController(IProductApp productApp)
        {
            _productApp = productApp;
        }

        [HttpGet]
        [Route("Getall")]
        public async Task<ActionResult> GetAll() {
            List<Product> products = await _productApp.AllItems();
            return Ok(products);
        }
        [HttpPost]
        [Route("SaveProduct")]
        public async Task<ActionResult> SaveProduct(Product product)
        {
            await _productApp.AddItem(product);
            return Ok();
        }
    }
}
