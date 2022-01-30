using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowloadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public DowloadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var filePath = Path.Combine(_env.WebRootPath, "files", "newbook.core.xlsx");

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", "newbook.core.xlsx");

        }
    }
}
