namespace WebApiFileEx.ViewModels
{
    public class UploadBigVM
    {
        public string lastModified { get; set; }

        public int Total { get; set; }

        public string? FileName { get; set; }
        public int Index { get; set; }
        public IFormFile FFile { get; set; }
    }
}
