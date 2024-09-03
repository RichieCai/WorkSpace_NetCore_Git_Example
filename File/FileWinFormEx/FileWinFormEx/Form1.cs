namespace FileWinFormEx
{
    public partial class Form1 : Form
    {
        string RootUrl = "";
        public Form1()
        {
            InitializeComponent();
            RootUrl = "http://localhost";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadExce2();
            label1.Text = "งนฆจ";
        }

        public void DownloadExcel()
        {
            //var fileName = "ฝdจา1.xlsx";
            //var url = $"api/file/download?fileName={fileName}";
            //
            //var response = s_client.GetAsync(url).Result;
            //response.EnsureSuccessStatusCode();
            //var fileBytes = response.Content.ReadAsByteArrayAsync().Result;
        }
        public async void DownloadExce2()
        {
            string sSaveDir = @".\Download\";
            if (Directory.Exists(sSaveDir))
            {
                Directory.CreateDirectory(sSaveDir);
            }
            string sSaveFileName = "test1.xlsx";

            var fileName = "ฝdจา1.xlsx";
            string RootUrl = "";
            var url= $"{RootUrl}/api/download?fileName={fileName}";

            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            using (var httpstream = await response.Content.ReadAsStreamAsync())
            {
                // var timestamped= FormatTimestampedString(symbol, true);
                var filePath = Path.Combine(sSaveDir, sSaveFileName);
                using (var fileStream = File.Create(filePath))
                {
                    await fileStream.CopyToAsync(fileStream);
                }
            }
        }
    }
}