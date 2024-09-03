using Microsoft.AspNetCore.Mvc;
using ToDoListBS.ViewModels;
using WebApiFileEx.ViewModels;

namespace WebApiFileEx.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadBigDataController : Controller
    {
        private readonly string _folder;
        string _path = "";
        private const string TempFolderPath = "TempFiles";
        private readonly static Dictionary<string, string> _contentTypes = new Dictionary<string, string>
        {
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"}
        };
        public UploadBigDataController(IHostEnvironment env)
        {
            //_folder = $@"{env.ContentRootPath}\Upload";
            _path = $"{Directory.GetCurrentDirectory()}/wwwroot/Image";
        }

        [HttpPost("Upload2")]
        public async Task<IActionResult> UploadFile([FromForm] UploadBigVM uploadVM)
        {
            int index = uploadVM.Index;
            string lastModified = uploadVM.lastModified;
            int total = uploadVM.Total;
            string fileName = uploadVM.FileName;
            var data = uploadVM.FFile;
            string temporary = Path.Combine(_path, lastModified);
            try
            {
                //建立暫存用路徑
                if (!Directory.Exists(temporary))
                    Directory.CreateDirectory(temporary);
                string filePath = Path.Combine(temporary, index.ToString());
                if (!Convert.IsDBNull(data))
                {
                    await Task.Run(() =>
                    {
                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            data.CopyTo(fs);
                            fs.Close();
                        }
                    });
                }
                bool mergeOk = false;
                if ( index== total-1)
                {
                    FileHandler fh = new FileHandler();
                    mergeOk = await FileHandler.FileMerge( uploadVM, _path, fileName, temporary);
                }

                var result = new
                {
                    number = index,
                    mergeOk = mergeOk
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                Directory.Delete(temporary);
                throw ex;
            }
        }

        [HttpPost("Upload3")]
        public async Task<IActionResult> UploadFileChunk([FromForm] UploadBigVM uploadVM)
        {
            var file = uploadVM.FFile;
            int Totalchunks = uploadVM.Total;
            int chunkIndex = uploadVM.Index;
            var fileName = uploadVM.FileName;
            string lastModified = uploadVM.lastModified;
            bool bRresult = false;

            string temporary = Path.Combine(_path, lastModified);
            //建立暫存用路徑
            if (!Directory.Exists(temporary))
                Directory.CreateDirectory(temporary);
            if (file == null || file.Length <= 0)
                return BadRequest("沒有選擇檔案");
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            var NewFileName = Path.GetFileNameWithoutExtension(uploadVM.FileName);
            var filePath = Path.Combine(temporary, $"{NewFileName}_{chunkIndex}");

            using (var stream = new FileStream(filePath, chunkIndex == 0 ? FileMode.Create : FileMode.Append))
            {
                await file.CopyToAsync(stream);
                stream.Close();
            }

            // 如果是最後一個分片，則將所有分片合併為完整檔案
            if (chunkIndex == Totalchunks - 1)
            {
                bRresult = FileHandler.FileMerge2(uploadVM, _path, fileName, temporary, Totalchunks).Result;
                return Ok(new { bRresult });
            }
            bRresult = true;
            return Ok(new { bRresult });
        }

    }
}
