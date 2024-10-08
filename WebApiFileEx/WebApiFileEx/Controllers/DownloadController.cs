﻿using Microsoft.AspNetCore.Mvc;

namespace WebApiFileEx.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DownloadController : Controller
    {
        private readonly static Dictionary<string, string> _contentType = new Dictionary<string, string>()
        {
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg","image/jpeg"},
            {".gif", "image/gif"}
        };
        private readonly string _folder;

        public DownloadController(IHostEnvironment env)
        {
            // 把下載目錄設為：wwwroot\Download
            _folder = $@"{env.ContentRootPath}\Download";
        }

        [HttpGet("txt")]
        public async Task<IActionResult> GetText()
        {
            return Ok();
        }

        [HttpGet("Excel")]
        public async Task<IActionResult> GetExcel()
        {
            return Ok();
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


        [HttpGet("download2/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Download", fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/octet-stream", fileName);
        }

        [HttpGet("Movice")]
        public async Task<IActionResult> GetMovice()
        {
            return Ok();
        }
    }
}
