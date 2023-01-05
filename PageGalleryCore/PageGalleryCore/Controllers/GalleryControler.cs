using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PageGalleryCore.Models;
using PageGalleryCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageGalleryCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryControler : ControllerBase
    {

        [HttpGet]
        [Route("getGallery")]
        public Response getGallery(string artist, string name, string attribute, string year, int page)
        {
            //string name,string author,string century,string attribute
            ServiceProvider service = new ServiceProvider();
            return service.selectResult(artist, name, attribute, year, page);
        }
        [HttpGet]
        [Route("HelloWorld")]
        public String Hello()
        {
            return "Hello";
        }
    }
}
