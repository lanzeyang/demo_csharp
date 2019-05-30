using System.Security.Cryptography;
using System.Text;

namespace Common.SHA1Helper
{
    /// <summary>
    /// SHA1帮助类
    /// </summary>
    public sealed class SHA1Helper
    {
        #region Constructors
        private SHA1Helper() { }
        #endregion

        /// <summary>
        /// 计算签名
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Hash(string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder hashBuilder = new StringBuilder(hash.Length * 2);

                foreach(byte hashByte in hash)
                {
                    hashBuilder.Append(hashByte.ToString("X2"));
                }

                return hashBuilder.ToString();
            }
        }
    }
}
