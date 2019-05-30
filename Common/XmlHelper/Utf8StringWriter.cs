using System.IO;
using System.Text;

namespace Common.XmlHelper
{
    /// <summary>
    /// Use UTF-8 encoding
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return new UTF8Encoding(false);
            }
        }
    }
}
