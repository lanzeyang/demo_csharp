using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    public class LongestPalindromeWorker : IMasterWorker
    {
        public void Do()
        {
            Console.WriteLine(LongestPalindrome("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth"));
        }

        public int LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            char[] chars = s.ToArray();

            Dictionary<char, int> char2Count = new Dictionary<char, int>();

            while (chars.Count() > 0)
            {
                char2Count.Add(chars[0], chars.Where(item => item.Equals(chars[0])).Count());
                chars = chars.Where(item => !item.Equals(chars[0])).ToArray();
            }

            int maxOddNumCount = 0;
            char charWithMaxLength;
            IEnumerable<KeyValuePair<char, int>> oddNums = char2Count.Where(item => item.Value % 2 == 1);
            if (!oddNums.Count().Equals(0))
            {
                maxOddNumCount = oddNums.Select(item => item.Value).Max();

                int leftOddCount =  oddNums.Where(item => item.Value % 2 == 1).Count() - 1;

                maxOddNumCount += oddNums.Where(item => item.Value % 2 == 1).Select(item => item.Value).Sum() - maxOddNumCount - leftOddCount;
            }

            int evenNumberCount = char2Count.Where(item => item.Value % 2 == 0).Sum(item => item.Value);

            return maxOddNumCount + evenNumberCount;
        }
    }
}
