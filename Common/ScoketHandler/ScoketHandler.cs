using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Common.ScoketHandler
{
    public sealed class ScoketHandler
    {
        private const int SECTION_MESSAGE_LENGTH = 6;
        private const int BUFFER_SIZE = 100;

        private ScoketHandler() { }

        public static byte[] Connect(string server, int port, string message)
        {
            if (string.IsNullOrEmpty(server))
            {
                throw new ArgumentNullException("server");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message");
            }

            TcpClient client = new TcpClient(server, port);
            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            List<byte> byteList = new List<byte>();

            byte[] buffer = new byte[BUFFER_SIZE];
            while (true)
            {
                int count = stream.Read(buffer, 0, buffer.Length);
                if (count < BUFFER_SIZE)
                {
                    byte[] lastBuffer = new byte[count];
                    lastBuffer = buffer.Skip(0).Take(count).ToArray();
                    byteList.AddRange(lastBuffer);
                    break;
                }
                byteList.AddRange(buffer);
                buffer = new byte[BUFFER_SIZE];

                //CPU处理数据到缓冲区
                Thread.Sleep(10);
            }

            stream.Close();
            client.Close();

            return byteList.ToArray();
        }
    }
}
