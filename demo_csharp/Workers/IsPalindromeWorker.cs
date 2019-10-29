using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class IsPalindromeWorker : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine(IsPalindrome(-11211));
        }

        public bool IsPalindrome(int x)
        {
            char[] numChar = x.ToString().ToCharArray();  
            Array.Reverse(numChar);

            return x.ToString().Equals(new string(numChar));
        }

        public bool IsPalindrome_2(int x)
        {
            char[] numChar = x.ToString().ToCharArray();
            Array.Reverse(numChar);

            return x.ToString().Equals(new string(numChar));
        }
    }
}
