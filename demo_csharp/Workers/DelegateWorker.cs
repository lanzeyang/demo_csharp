using demo_csharp.Workers.IWorkService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace demo_csharp.Workers
{
    public class DelegateWorker : IMasterWorker
    {
        private delegate void MethodDelegate(int x, int y);
        private static MethodDelegate method;

        private static Func<string, int> returnLength = text => text.Length;
        private static Func<int, string> returnHello = text => "Hello " + text;
        private static Func<string, string> returnHi = text => "Hi " + text;
        private static Func<int, int> add = value => value += 2;

        private static Action<string> sayHello = text => Console.WriteLine("Hello");
        private static Action<int> sayHi = text => Console.WriteLine("Hi");

        private static Predicate<string> stringEmpty = text => string.IsNullOrEmpty(text);

        public void Do()
        {
            SaySth<int>(sayHi, 1);
            SaySth<string>(sayHello, string.Empty);

            Console.WriteLine(SaySth(returnHello, 1));
            Console.WriteLine(SaySth(returnHi, "lianzeyang"));
            //Add(add, 1);

            Console.WriteLine(stringEmpty(""));
        }

        /// <summary>
        /// 测试委托
        /// </summary>
        private void TestDelegate()
        {
            Console.WriteLine("start to test delegate");
            Console.WriteLine("**********************");

            method = new MethodDelegate(Add);
            method += Show;
            method += Show_2;
            method(1, 2);

            while (method != null)
            {
                method -= method;
            }

            Console.WriteLine("*************************");
            Console.WriteLine("finished to test delegate");
        }

        /// <summary>
        /// 测试Action
        /// </summary>
        private void TestAction()
        {
            Console.WriteLine("start to test Action");
            Console.WriteLine("**********************");

            var films = new List<Film>
            {
                    new Film{ Name = "Jaws",Year = 1975 },
                    new Film{ Name = "Singing in the rain",Year = 1975 },
                    new Film{ Name = "Some like it hot",Year = 1959 },
                    new Film{ Name = "The Wizzard of oz",Year = 1939 },
                    new Film{ Name = "It's a wonderful life",Year = 1946 },
                    new Film{ Name = "American Beatify",Year = 1999 },
                    new Film{ Name = "High Fidelity",Year = 2000 },
                    new Film{ Name = "The usual suspect",Year = 1995 }
            };

            Action<Film> print = film => Console.WriteLine("Name = {0}, Year = {1}", film.Name, film.Year);
            films.ForEach(print);

            Console.WriteLine("**********");

            films.FindAll(film => film.Year < 1975).ForEach(print);

            Console.WriteLine("**********");

            films.Sort((f1, f2) => f1.Year.CompareTo(f2.Year));
            films.ForEach(print);

            Console.WriteLine("*************************");
            Console.WriteLine("finished to test Action");
        }

        public static void TestExpression()
        {
            Console.WriteLine("start to test expression");

            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            Expression add = Expression.Add(firstArg, secondArg);

            Func<int> compiled = Expression.Lambda<Func<int>>(add).Compile();
            Console.WriteLine(compiled());
        }

        /// <summary>
        /// 返回字符串长度，delegate写法
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int returnLengthTypeWithDelegate(string content)
        {
            Func<string, int> returnLength = delegate(string text) { return text.Length; };

            return returnLength(content);
        }

        /// <summary>
        /// 返回字符串长度，写法2
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int reurnLengthTypeWithParamType(string content)
        {
            Func<string, int> returnLength = (string text) => text.Length;

            return returnLength(content);
        }

        /// <summary>
        /// 返回字符串长度，省略参数类型写法
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int returnLengthTypeWithoutParamType(string content)
        {
            Func<string, int> returnLength = text =>
            {
                return string.IsNullOrEmpty(text) ? 0 : text.Length;
            };

            /*Func<string, int> returnLength = (text) =>
            {
                return string.IsNullOrEmpty(text) ? 0 : text.Length;
            };*/

            return returnLength(content);
        }

        private void SaySth<T>(Action<T> speacker, T t)
        {
            speacker(t);
        }

        private string SaySth<T>(Func<T, string> speacker, T t)
        {
            return speacker(t);
        }

        private void Add(int x, int y)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        private void Show(int x, int y)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        private void Show_2(int x, int y)
        {
            Console.WriteLine(x - y);
        }

        private void Add(Func<int, int> adder, int value)
        {
            while (value < 100)
            {
                Thread.Sleep(1000);
                Console.WriteLine(value);
                value = adder(value);
            }
        }
    }
}
