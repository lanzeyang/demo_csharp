using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.HashHelper
{
    public sealed class HashHelper
    {
        #region Fields
        private const string HEX_FORMAT = "{0:X2}";
        private const char COLON = ':';
        private static readonly object lockHelper = new object();
        private static HashHelper instance = null;
        #endregion

        #region Constructors
        private HashHelper() { }
        #endregion

        public static HashHelper CreateInstance()
        {
            if (null == instance) 
            {
                lock (lockHelper)
                {
                    if (null == instance)
                    {
                        instance = new HashHelper();
                    }
                }
            }

            return instance;
        }

        public string ComputeMD5(byte[] bytes)
        {
            MD5 calculator = MD5.Create();
            byte[] buffer = calculator.ComputeHash(bytes);

            return Byte2Hex(buffer);
        }

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
    }
}
