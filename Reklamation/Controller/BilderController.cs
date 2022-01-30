
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Reklamation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilderController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(int Rek_ID, string name)
        {
            try
            {
                var image = System.IO.File.OpenRead(@"C:\inetpub\wwwroot\050_Bilder\103_Reklamation\" + Rek_ID + @"\" + name);
                return File(image, "image/jpg");
            }catch(Exception ex)
            {
                Log.Error(Rek_ID + ": " + name + " couldn't found in the folder");
                var image = System.IO.File.OpenRead(@"C:\inetpub\wwwroot\103_Reklamation\wwwroot\images\download.png");
                return File(image, "image/jpg");
            }
                      
            
        }
    }
}
