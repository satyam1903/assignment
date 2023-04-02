using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Syncfusion.EJ2.Navigations;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using Server.Models;
using Microsoft.AspNetCore.Hosting;
namespace Server.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class AllFilesJsonController : ControllerBase
    {


        private IHostingEnvironment Environment;

        public AllFilesJsonController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        [HttpPost]
        public IActionResult ShowAllFiles()
        {
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.ContentRootPath, "Shared/"));

            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return Ok(files);

            //return Ok(true);
        }
    }
}
