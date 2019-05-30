
namespace Model
{
    /// <summary>
    /// 义乌文件上传类
    /// </summary>
    public class ApplyFileInfo
    {
        private const string IMG_URL_PREFIX = "http://www.yiwuwater.com/upimg";

        public ApplyFileInfo() { }

        public int FileInfoId { get; set; }

        public string FilePath { get; set; }

        public string FileUrl
        {
            get
            {
                return IMG_URL_PREFIX + FilePath;

            }
            private set { }
        }

        public string FileName
        {
            get
            {
                string fileName = string.Empty;

                if (!string.IsNullOrEmpty(FilePath))
                {
                    fileName = FilePath.Substring(FilePath.LastIndexOf('/') + 1, FilePath.Length - FilePath.LastIndexOf('/') - 1);
                }

                return fileName;
            }
            private set { }
        }

        public byte[] FileByte { get; set; }
    }
}
