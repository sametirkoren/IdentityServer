using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>() { 
                new Product { Id = 1, Name = "Kalem", Price = 100, Stock = 500 } ,
                new Product { Id = 2, Name = "Silgi", Price = 200, Stock = 1000 },
                new Product { Id = 3, Name = "Defter", Price = 300, Stock = 600 },
                new Product { Id = 4, Name = "Kitap", Price = 400, Stock = 400 },
                new Product { Id = 5, Name = "Bant", Price = 500, Stock = 300 },
              
            };

            return Ok(productList);

        }
    }

  
}
