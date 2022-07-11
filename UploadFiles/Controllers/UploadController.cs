using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadFiles.Models;

namespace UploadFiles.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult UploadFile()
        {
            var model = new FileModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(FileModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    var pathFolder = "wwwroot/UploadFiles/";
                    pathFolder += model.File.FileName;
                    var pathServer = Path.Combine(_env.ContentRootPath, pathFolder);
                    await model.File.CopyToAsync(new FileStream(pathServer, FileMode.Create));
                }
            }
            return View(model);
        }
    }
}
