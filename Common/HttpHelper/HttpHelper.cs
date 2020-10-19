using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpHelper
{
    public sealed class HttpHelper
    {
        #region Fields
        private static HttpHelper instance = null;
        private static readonly object lockHelper = new object();
        private const char DOT = '.';
        private const char COLON = ':';
        private const string CONTENT_TYPE_FORM_DATA = "multipart/form-data";
        private const string DEFAULT_FORM_NAME = "form";
        private const string HEX_FORMAT = "{0:X2}";
        #endregion

        #region Constructors
        private HttpHelper() { }
        #endregion

        #region Public Methods
        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static HttpHelper CreateInstance()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new HttpHelper();
                    }
                }
            }

            return instance;
        }

        public async Task<String> UploadFileByFormData(string url, List<ApplyFileInfo> files)
        {
            HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                using (MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent())
                {
                    foreach (ApplyFileInfo file in files)
                    {
                        StreamContent imageContent = new StreamContent(new MemoryStream(file.FileByte));
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(CONTENT_TYPE_FORM_DATA);

                        multipartFormDataContent.Add(imageContent, DEFAULT_FORM_NAME, ParseFileName(file.FileName));
                    }

                    HttpResponseMessage result = await httpClient.PostAsync(url, multipartFormDataContent);
                    result.EnsureSuccessStatusCode();

                    return await result.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<String> UploadFileByFormData(string url, string fileName, byte[] fileByte)
        {
            HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                using (MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent())
                {
                    multipartFormDataContent.Add(new StringContent("bf257785-6ae4-41b6-8a4a-a1b53a06ff55"), "serialNo");
                    multipartFormDataContent.Add(new StringContent("0"), "serialNoType");
                    multipartFormDataContent.Add(new StringContent("0"), "person");

                    var imageContent = new ByteArrayContent(fileByte);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

                    multipartFormDataContent.Add(imageContent, DEFAULT_FORM_NAME, fileName);

                    HttpResponseMessage result = await httpClient.PostAsync(url, multipartFormDataContent);
                    result.EnsureSuccessStatusCode();

                    return await result.Content.ReadAsStringAsync();
                }
            }
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="method">方法（post或get）</param>
        /// <param name="method">数据类型</param>
        /// <param name="requestData">数据</param>
        public string SendPostHttpRequest(string url, string contentType, string requestData)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (v1, v2, v3, v4) => { return true; };
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            byte[] postBytes = null;
            request.ContentType = contentType;
            postBytes = Encoding.UTF8.GetBytes(requestData);
            request.ContentLength = postBytes.Length;
            using (Stream outstream = request.GetRequestStream())
            {
                outstream.Write(postBytes, 0, postBytes.Length);
            }
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }

                }
            }
            return result;
        }

        public async Task<byte[]> DoGetByte(string url)
        {
            HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (HttpClient http = new HttpClient(handler))
            {
                HttpResponseMessage response = await http.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsByteArrayAsync();
            }
        }

        /// <summary>
        /// 文件名转码
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ParseFileName(string fileName)
        {
            string fileNamePrefix = fileName.Substring(0, fileName.IndexOf(DOT));
            string fileNameSuffix = fileName.Substring(fileName.IndexOf(DOT), fileName.Length - fileNamePrefix.Length);
            string hexedFileName = Byte2Hex(Encoding.UTF8.GetBytes(fileNamePrefix));

            return hexedFileName + fileNameSuffix;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 将byte数组转换为16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string Byte2Hex(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            if (bytes != null && bytes.Length > 0)
            {
                foreach (byte item in bytes)
                {
                    builder.Append(String.Format(HEX_FORMAT, item));
                }
            }

            return builder.ToString().TrimEnd(COLON);
        }
        #endregion
    }
}
