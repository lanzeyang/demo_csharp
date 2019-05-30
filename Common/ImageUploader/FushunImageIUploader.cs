using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.ImageUploader
{
    public class FushunImageIUploader
    {
        private const string IMAGE_UPLOAD_URL = "http://172.16.50.114:8083/api/wap/v2/fs/upload";
        private const string IMAGE_FOLDER = @"D:\workspace\fushun\微信查询验证功能\照片汇总\汇总_2";
        private const string DEFAULT_FORM_NAME = "form";
        private const string FILE_FORMATTER = "{0}\\{1}";
        private static MySqlHelper sqlHelper = MySqlHelper.CreateInstance();

        public async void UploadImage()
        {
            DirectoryInfo di = new DirectoryInfo(IMAGE_FOLDER);
            FileInfo[] files = di.GetFiles();

            Dictionary<string, string> fileName2Path = files.ToDictionary(item => item.Name, item => string.Format(FILE_FORMATTER, item.DirectoryName, item.Name));

            foreach (var item in fileName2Path)
            {
                //get data by name,code
                DataSet data = QuryByNameOrCode(GetFileName(item.Key));

                if (data.Tables[0].Rows.Count == 0 || data.Tables[0].Rows[0]["AvatorHash"].ToString() != string.Empty)
                {
                    continue;
                }

                int id = (int)data.Tables[0].Rows[0]["ID"];

                using (FileStream fs = new FileStream(item.Value, FileMode.Open))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);

                    Console.WriteLine("上传图片中：id=" + id);
                    string result = await UploadImage(buffer, item.Key);

                    JToken fileResponse = JArray.Parse(result)[0];
                    string hash = fileResponse["fileHash"].ToString();
                    Console.WriteLine("上传成功,fileHash=" + hash);

                    UpdateAvatorHash(id, hash);
                }
            }
        }

        private DataSet QuryByNameOrCode(string nameOrCode)
        {
            StringBuilder sqlCommand = new StringBuilder(100);
            sqlCommand.Append("SELECT TOP 1 * FROM Base_Staff WHERE StaffName = '").Append(nameOrCode).Append("'");
            sqlCommand.Append(" OR StaffCode = '").Append(nameOrCode).Append("'");

            return sqlHelper.Query(sqlCommand.ToString());
        }

        private void UpdateAvatorHash(int id, string hash)
        {
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.Append("UPDATE Base_Staff SET AvatorHash = '").Append(hash).Append("'");
            sqlCommand.Append(" WHERE id = ").Append(id);

            sqlHelper.Update(sqlCommand.ToString());
        }

        private async Task<string> UploadImage(byte[] fileByte, string fileName)
        {
            HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                using (MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent())
                {
                    StreamContent imageContent = new StreamContent(new MemoryStream(fileByte));
                    //限制了Content-Type: image/png or image/jpeg
                    imageContent.Headers.ContentType = GetMediaTypeHeaderValue(GetFileExpandName(fileName));

                    fileName = HttpUtility.UrlEncode(fileName);

                    multipartFormDataContent.Add(imageContent, DEFAULT_FORM_NAME, fileName);

                    HttpResponseMessage result = await httpClient.PostAsync(IMAGE_UPLOAD_URL, multipartFormDataContent);
                    result.EnsureSuccessStatusCode();

                    return await result.Content.ReadAsStringAsync();
                }
            }
        }

        private MediaTypeHeaderValue GetMediaTypeHeaderValue(string fileExpandName)
        {
            string input = string.Empty;

            switch (fileExpandName.ToLower())
            {
                case "jpg":
                case "jpeg":
                    input = "image/jpeg";
                    break;
                case "png":
                    input = "image/png";
                    break;
                default:
                    break;
            }

            return MediaTypeHeaderValue.Parse(input);
        }

        private string GetFileExpandName(string fileName)
        {
            return fileName.Substring(fileName.IndexOf('.') + 1, fileName.Length - fileName.IndexOf('.') - 1);
        }

        private string GetFileName(string fileName)
        {
            return fileName.Substring(0, fileName.IndexOf('.'));
        }
    }
}
