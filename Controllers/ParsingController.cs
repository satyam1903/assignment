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
namespace Server.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class ParsingController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        public ParsingController(ILogger<FileController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult JsonParser()
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                FileStream fileStream = new FileStream(@"C:\Users\kumarsa\Downloads\jobfile.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(fileStream);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Saves the worksheet to a JSON filestream, as schema by default
                FileStream stream = new FileStream("./Shared/Excel-Worksheet-To-JSON-filestream-as-schema-default.json", FileMode.Create, FileAccess.ReadWrite);
                workbook.SaveAsJson(stream, worksheet);

                //Saves the worksheet to a JSON filestream as schema
                //FileStream stream1 = new FileStream("Excel-Worksheet-To-JSON-filestream-as-schema.json", FileMode.Create, FileAccess.ReadWrite);
                //workbook.SaveAsJson(stream1, worksheet, true);

                stream.Dispose();
                //stream1.Dispose();
            }
            return Ok(true);
        }
    }
}
