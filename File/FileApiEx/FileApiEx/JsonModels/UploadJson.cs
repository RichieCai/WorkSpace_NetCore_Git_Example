namespace FileApiEx.JsonModels
{
    public class UploadJson
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public IFormFile FFile { get; set; }
    }
}
