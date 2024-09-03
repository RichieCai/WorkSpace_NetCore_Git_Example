using FileApiEx.JsonModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http.Results;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace FileApiEx.Controllers
{
    //對應vue專案 D:\Example\WorkSpace_Vue\Vue3jsEx\WebApi\webapi2
    [ApiController]
    [Route("api/[controller]")]
    public class DownloadController : Controller
    {
        private readonly static Dictionary<string, string> _contentType = new Dictionary<string, string>()
        {
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg","image/jpeg"},
            {".gif", "image/gif"},
            {".doc", "application/vnd.ms-word"},
            {".docx","application/vnd.ms-word"},
            {".xls", "application/vnd.ms-excel"},
            {".xlsx","application/vnd.ms-excel"},
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".csv", "text/csv"},
            {".zip", "application/zip"}
        };
        private readonly string _folder;
        public DownloadController(IWebHostEnvironment env)
        {
            // 把下載目錄設為：wwwroot\Download
            //env.WebRootPath
            _folder = $@"{env.ContentRootPath}Download";
        }

        [HttpGet("DownloadForGet/{FileName}")]
        public async Task<IActionResult> DownloadForGet(string FileName)
        {
            var memory = DownloadForGetSingleFile("myFist.txt", "Download");
            return File(memory.ToArray(),"text/plain", "myFistOne.txt");
        }

        /// <summary>
        /// 使用WebClient和 DownloadData實現的檔案下載
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        private MemoryStream DownloadForGetSingleFile(string FileName,string FilePath)
        {
            var fileNamePath = Path.Combine(Directory.GetCurrentDirectory(), FilePath, FileName);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(fileNamePath))
            {
                var net = new WebClient();
                var data=net.DownloadData(fileNamePath);
                var cotnet = new MemoryStream(data);
                memory = cotnet;
            }
            memory.Position = 0;
            return memory;
        }

        [HttpGet("GetDownload/{FileName}")]
        public async Task<IActionResult> GetDownload(string FileName)
        {
            var fileNamePath = Path.Combine(_folder, FileName);

            var fileStreaml = new FileStream(fileNamePath, FileMode.Open);
            var newpath= Path.Combine(Directory.GetCurrentDirectory(), "", FileName);
            var content = new StreamContent(fileStreaml);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octect-stream");
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
            {
                FileName = FileName
            };
            return new FileStreamResult(fileStreaml, _contentType[Path.GetExtension(fileNamePath).ToLowerInvariant()]);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetDownload2/{FileName}")]
        public async Task<string> GetDownload2(string FileName)
        {
            var fileNamePath = Path.Combine(_folder, FileName);

            var fileStreaml = new FileStream(fileNamePath, FileMode.Open);
            var newpath = Path.Combine(Directory.GetCurrentDirectory(), "", FileName);
            fileStreaml.Close();

            byte[] bytes = System.IO.File.ReadAllBytes(fileNamePath);
            string sResult = Convert.ToBase64String(bytes, 0, bytes.Length);
            var vResult =new { data = sResult };
            var vjsonResult=  JsonConvert.SerializeObject(vResult);

            return vjsonResult;
        }




        [HttpPost("PostDownload")]
        public async Task<IActionResult> PostDownload(DownloadJson parm)
        {
            var fileNamePath = Path.Combine(_folder, parm.FileName);

            var fileStreaml = new FileStream(fileNamePath, FileMode.Open);
            var content = new StreamContent(fileStreaml);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octect-stream");
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachement")
            {
                FileName = parm.FileName
            };
            return new FileStreamResult(fileStreaml, _contentType[Path.GetExtension(fileNamePath).ToLowerInvariant()]);
        }

        [HttpGet("Image/{fileName}")]
        public async Task<IActionResult> GetImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }
            var path = $@"{_folder}\{fileName}";
            var memoryStream = new MemoryStream();
            using (var steam = new FileStream(path, FileMode.Open))
            {
                await steam.CopyToAsync(memoryStream);
            }
            memoryStream.Seek(0, SeekOrigin.Begin);

            // 回傳檔案到 Client 需要附上 Content Type，否則瀏覽器會解析失敗。
            return new FileStreamResult(memoryStream, _contentType[Path.GetExtension(path).ToLowerInvariant()]);

        }

        [HttpGet("test")]
        public async Task<IActionResult> GetMovice()
        {
            return Ok("test");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }



    }
}
