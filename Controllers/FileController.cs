using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Server.Models;
using Syncfusion.XlsIO;
using System.IO;
using System.Text.Json;

namespace Server.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost("ParseFile")]
        //[ProducesResponseType(typeof(FormData), StatusCodes.Status200OK)]
        // ,string filePath, DateTime timeStamp,string timeZone
        public IActionResult ParseFile([FromBody] FormData data,string fileName)
        {
            Console.WriteLine(data.FileData[0].JobID);
            fileName = Path.GetFileNameWithoutExtension(fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<FormData>(data,options);
            Console.WriteLine(strJson);
            System.IO.File.WriteAllText($"./shared/{fileName}.json", strJson);



            return Ok(data);
        }

        [HttpGet("GetJsonData")]
 
        public async Task<IActionResult> GetJsonDataAsync()
        { 

            string fileName = "./Shared/output.json";
            using FileStream openStream = System.IO.File.OpenRead(fileName);
            FormData? JsonData =await JsonSerializer.DeserializeAsync<FormData>(openStream);

            Console.WriteLine("Json data is "+JsonData);

            return Ok(JsonData);
        }
    }
}
