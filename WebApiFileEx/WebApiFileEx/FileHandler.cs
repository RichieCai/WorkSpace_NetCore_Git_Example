using WebApiFileEx.ViewModels;

namespace WebApiFileEx
{
    public class FileHandler
    {
        public static async Task<bool> FileMerge(UploadBigVM uploadVM, string _path, string fileName,string temporary)
        {
            bool bResult = false;
            try
            {
                string fileExt = Path.GetExtension(fileName);//取得副檔名
                var files = Directory.GetFiles(temporary);//取得目錄下所有檔案
                var finalPath = Path.Combine(_path, fileName+"_"+ DateTime.Now.ToString("yyyyMMdd")+ fileExt);
                using (var fs = new FileStream(finalPath, FileMode.Create))
                {
                    foreach (var part in files.OrderBy(x => x.Length).ThenBy(x => x))
                    {
                        var bytes = File.ReadAllBytes(part);
                        await fs.WriteAsync(bytes, 0, bytes.Length);
                        bytes = null;
                        File.Delete(part);
                    }
                    fs.Close();
                }
                Directory.Delete(temporary);
                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bResult;
        }


        public static async Task<bool> FileMerge2(UploadBigVM uploadVM, string _path, string fileName, string temporary, int chunks)
        {
            bool bResult = false;
            //string sFileExt = Path.GetExtension(uploadVM.FileName);
            var finalFilePath = Path.Combine(_path, fileName);
            var NewFileNameWithoutExtensio = Path.GetFileNameWithoutExtension(fileName);
            using (var finalFileStream = new FileStream(finalFilePath, FileMode.Create))
            {
                for (int i = 0; i < chunks; i++)
                {
                    var chunkFilePath = Path.Combine(temporary, $"{NewFileNameWithoutExtensio}_{i}");
                    using (var chunkStream = new FileStream(chunkFilePath, FileMode.Open))
                    {
                        await chunkStream.CopyToAsync(finalFileStream);
                        chunkStream.Close();
                    }
                    System.IO.File.Delete(chunkFilePath); // 刪除已合併的分片
                }
                finalFileStream.Close();
                Directory.Delete(temporary);
            }
            return bResult;
        }
    }
}
