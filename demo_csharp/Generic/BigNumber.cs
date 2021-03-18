using Common.Log;
using System.Collections.Generic;
using System.Linq;

namespace demo_csharp.Generic
{
    public class BigNumber
    {
        private List<BigNumberItem> number = new List<BigNumberItem>();

        public BigNumber() { }

        public BigNumber(string value)
        {
            char[] charArray = value.ToCharArray().Reverse().ToArray();

            for (int index = 0; index < charArray.Length; index++)
            {
                number.Add(new BigNumberItem() { Index = index + 1, Value = charArray[index].ToString() });
            }
        }

        public List<BigNumberItem> Number
        {
            get
            {
                return number;
            }
            private set { }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (number.Count.Equals(0))
            {
                return result;
            }

            for (int index = 1; index <= number.Count; index++)
            {
                result += number.Where(item => item.Index.Equals(index)).First().Value;
            }

            return result;
        }

        public string Add(BigNumber another)
        {
            string result = string.Empty;
            return result;
        }

        public string Add(string s1, string s2)
        {
            string result = string.Empty;

            string bigger = s1.Length > s2.Length ? s1 : s2;
            string smaller = s1.Length > s2.Length ? s2 : s1;

            string extraPart = bigger.Substring(0, bigger.Length - smaller.Length);

            int extra = 0;
            for (int index = 0; index < smaller.Length; index++)
            {
                int num1 = int.Parse(bigger.Substring(bigger.Length - index - 1, 1));
                int num2 = int.Parse(smaller.Substring(smaller.Length - index - 1, 1));

                int temp = num1 + num2 + extra;
                if (temp >= 10)
                {
                    extra = 1;
                }
                else
                {
                    extra = 0;
                }

                result = $"{temp % 10}{result}";
            }

            if (extraPart.Length.Equals(0))
            {
                if (extra.Equals(1))
                {
                    result = $"{1}{result}";
                }
            }
            else
            {
                for (int index = 0; index < extraPart.Length; index++)
                {
                    int num1 = int.Parse(extraPart.Substring(extraPart.Length - index - 1, 1));
                    int temp = num1 + extra;
                    if (temp >= 10)
                    {
                        extra = 1;
                    }
                    else
                    {
                        extra = 0;
                    }

                    result = $"{temp % 10}{result}";
                }

                if (extra.Equals(1))
                {
                    result = $"{1}{result}";
                }
            }

            return result;
        }
    }
}
