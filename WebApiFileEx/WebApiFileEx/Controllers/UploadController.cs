using Microsoft.AspNetCore.Mvc;
using ToDoListBS.ViewModels;

namespace WebApiFileEx.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly static Dictionary<string, string> _contentTypes = new Dictionary<string, string>
        {
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"}
        };
        public UploadController(IHostEnvironment env)
        {
            _folder = $@"{env.ContentRootPath}\Upload";
        }
        private readonly string _folder;

        [HttpPost("Up1")]
        public async Task<IActionResult> PostExcel([FromForm] UploadVM uploadVM)
        {
            if (uploadVM == null || uploadVM.FFile.Length == 0)
                return BadRequest("No file uploaded");

            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);

            string sFileName = uploadVM.FFile.FileName;
            var path = Path.Combine(_folder, sFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await uploadVM.FFile.CopyToAsync(stream);
            }

            return Ok(new { result = "sunccess" });
        }
        //IFormFile 檔案上傳可用,多個用 List<IFormFile>
        [HttpPost("Image2")]
        public async Task<IActionResult> UploadImage2([FromForm] UploadVM uploadVM)
        {
            if (uploadVM == null || uploadVM.FFile.Length == 0)
                return BadRequest("No file uploaded");
            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);

            string sFileName = uploadVM.FFile.FileName;
            var path = Path.Combine(_folder, sFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await uploadVM.FFile.CopyToAsync(stream);
            }
            return Ok(new { result = "sunccess" });
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");
            if (file == null || file.Length == 0)
                return BadRequest("File is not selected");

            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var filePath = Path.Combine(uploadsFolderPath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok("File uploaded successfully");
        }

    }

}
