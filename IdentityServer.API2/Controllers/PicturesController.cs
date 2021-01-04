using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>()
            {
                new Picture{Id = 1 , Name = "Doğa Resmi" , Url="dogaresmi.jpg" },
                new Picture{Id = 2 , Name = "Manzara Resmi" , Url="manzararesmi.jpg" },
                new Picture{Id = 3 , Name = "Gökyüzü Resmi" , Url="gokyuzuresmi.jpg" },
                new Picture{Id = 4 , Name = "Deniz Resmi" , Url="denizresmi.jpg" },
                new Picture{Id = 5 , Name = "Orman Resmi" , Url="ormanresmi.jpg" },
            };


            return Ok(pictures);
        }

    }
}
