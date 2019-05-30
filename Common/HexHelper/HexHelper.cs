using System;
using System.Text;

namespace Common.HexHelper
{
    public sealed class HexHelper
    {
        private HexHelper() { }

        /// <summary>
        /// Byte => Hex
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Hex => Byte
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] Hex2Byte(string hex)
        {
            Console.WriteLine("this is hex body");
            Console.WriteLine(hex);

            if (string.IsNullOrEmpty(hex))
            {
                throw new ArgumentNullException("hex");
            }

            hex = hex.Trim();

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
