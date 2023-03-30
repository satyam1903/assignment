using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Server.Models;
using Syncfusion.XlsIO;
using System.IO;

namespace Server.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost("ParseFile")]
        //[ProducesResponseType(typeof(FormData), StatusCodes.Status200OK)]
        // ,string filePath, DateTime timeStamp,string timeZone
        public IActionResult ParseFile([FromBody] FormData data)
        {
            Console.WriteLine(data.Filepath);
            string filepath=data.Filepath;
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(fileStream);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Saves the worksheet to a JSON filestream, as schema by default
                FileStream stream = new FileStream("Excel-Worksheet-To-JSON-filestream-as-schema-default.json", FileMode.Create, FileAccess.ReadWrite);
                workbook.SaveAsJson(stream, worksheet);

                //Saves the worksheet to a JSON filestream as schema
                //FileStream stream1 = new FileStream("Excel-Worksheet-To-JSON-filestream-as-schema.json", FileMode.Create, FileAccess.ReadWrite);
                //workbook.SaveAsJson(stream1, worksheet, true);

                stream.Dispose();
                //stream1.Dispose();
            }
            return Ok(data);
        }
    }
}
