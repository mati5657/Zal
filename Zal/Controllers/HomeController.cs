using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Zal.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IFileProvider _fileProvider;

        public HomeController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var file = _fileProvider.GetFileInfo("/Home/index.html");
            if (file.Exists)
            {
                return File(file.CreateReadStream(), "text/html");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
