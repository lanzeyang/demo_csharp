using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.RSAHelper
{
    public sealed class RSAHelper
    {
        private RSAHelper() { }

        /// <summary>
        /// RSA签名
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <param name="content">密文</param>
        /// <returns></returns>
        public static string Sign(string data, string privareKey, string charset, string algorithm)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //导入私钥
            rsa.FromXmlString(RSAConverter.RSAPrivateKeyJava2DotNet(privareKey));

            byte[] dataByte = Encoding.GetEncoding(charset).GetBytes(data);

            if (algorithm.ToUpper().Equals("RSA"))
            {
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                return Convert.ToBase64String(rsa.SignData(dataByte, sha1));
            }
            else if (algorithm.ToUpper().Equals("RSA2"))
            {
                return Convert.ToBase64String(rsa.SignData(dataByte, "SHA256"));
            }

            return string.Empty;
        }

        /// <summary>
        /// 验证RSA签名
        /// </summary>
        /// <param name="data">需要验证的数据</param>
        /// <param name="publicKey">RSA公钥</param>
        /// <param name="charset">编码格式</param>
        /// <param name="sign">需要验证的签名</param>
        /// <param name="algorithm">加密算法</param>
        /// <returns>验证是否成功</returns>
        public static bool Verify(string data, string publicKey, string charset, string sign, string algorithm)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //导入公钥，因为公钥是JAVA生成的，需要转换为.NET的格式
            rsa.FromXmlString(RSAConverter.RSAPublicKeyJava2DotNet(publicKey));

            byte[] dataByte = Encoding.GetEncoding(charset).GetBytes(data);

            if (algorithm.ToUpper().Equals("RSA"))
            {
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                return rsa.VerifyData(dataByte, sha1, Convert.FromBase64String(sign));
            }
            else if (algorithm.ToUpper().Equals("RSA2"))
            {
                return rsa.VerifyData(dataByte, "SHA256", Convert.FromBase64String(sign));
            }

            return false;
        }
    }
}
