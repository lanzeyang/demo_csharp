using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class ToolWorker : IMasterWorker
    {
        private const float HEIGHT = 1270F;
        private const float WIDTH = 2421F;
        public void Do()
        {
            Console.WriteLine("请输入控件横坐标、总坐标、宽、高，逗号隔开");
            string locationXString = Console.ReadLine();
            string[] inputs = locationXString.Split(',');

            float locationX = TryParseFloat(inputs[0]);
            float locationY = TryParseFloat(inputs[1]);
            float height = TryParseFloat(inputs[2]);
            float width = TryParseFloat(inputs[3]);


            Console.WriteLine(string.Format("输入的X={0}，Y={1}，高={2}，宽={3}", locationX, locationY, height, width));

            float parsedLocationX = locationY;
            float parsedLocationY = WIDTH - locationX - width;

            Console.WriteLine(string.Format("转换后的X={0}，Y={1}，高={2}，宽={3}", parsedLocationX, parsedLocationY, width, height));
            Do();
        }

        private float TryParseFloat(string floatString)
        {
            float result = 0F;
            float.TryParse(floatString, out result);
            return result;
        }
    }
}
