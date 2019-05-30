using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.SecrectUtil
{
    /// <summary>
    /// 加密解密工具类
    /// </summary>
    public sealed class SecrectUtil
    {
        /// <summary>
        /// Constructors
        /// </summary>
        private SecrectUtil() { }

        private const string ALGORITHM = "DESede";
        private const string PASSWORD_CRYPT_KEY = "w993945xw641269xw993945x";

        public static byte[] Crypt(byte[] origin)
        {
            MemoryStream stream = new MemoryStream();

            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            tdsp.Padding = PaddingMode.PKCS7;

            byte[] key = build3DesKey(PASSWORD_CRYPT_KEY);

            CryptoStream tempStream = new CryptoStream(stream, tdsp.CreateEncryptor(key, null), CryptoStreamMode.Write);

            tempStream.Write(origin, 0, origin.Length);
            tempStream.FlushFinalBlock();
            byte[] ret = stream.ToArray();

            tempStream.Close();
            stream.Close();

            return ret;
        }

        public static byte[] Decrypt(byte[] data)
        {
            MemoryStream msDecrypt = new MemoryStream(data);

            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            //tdsp.Padding = PaddingMode.PKCS7;
            tdsp.Padding = PaddingMode.None;

            byte[] key = build3DesKey(PASSWORD_CRYPT_KEY);

            CryptoStream csDecrypt = new CryptoStream(msDecrypt, tdsp.CreateDecryptor(key, null), CryptoStreamMode.Read);

            byte[] fromEncrypt = new byte[data.Length];
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            msDecrypt.Close();
            csDecrypt.Close();

            return fromEncrypt;
        }

        /// <summary>
        /// 根据字符串生成密钥字节数组
        /// </summary>
        /// <param name="keyStr"></param>
        /// <returns></returns>
        private static byte[] build3DesKey(string keyStr)
        {
            byte[] key = new byte[24];
            byte[] temp = Encoding.UTF8.GetBytes(keyStr);

            Array.Copy(temp, key, key.Length > temp.Length ? temp.Length : key.Length);

            return key;
        }

        public static string Byte2Hex(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            if (bytes != null && bytes.Length > 0)
            {
                foreach (byte item in bytes)
                {
                    builder.Append(String.Format("{0:X2}", item));
                }
            }

            return builder.ToString().TrimEnd(':');
        }

        public static byte[] Hex2Byte(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                throw new ArgumentNullException("hex");
            }

            if (!(hex.Length % 2 == 0))
            {
                throw new ArgumentException("hex的长度必须是偶数");
            }

            byte[] result = new byte[hex.Length / 2];

            for (int index = 0; index < hex.Length; index += 2)
            {
                string section = hex.Substring(index, 2);

                result[index / 2] = (byte)Convert.ToInt32(section, 16);
            }

            return result;
        }
    }
}
