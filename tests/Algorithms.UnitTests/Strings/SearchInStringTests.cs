using Algorithms.Strings;
using DataStructures.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTests.Arrays
{
    [TestClass]
    public class SearchInStringTests
    {
        [TestMethod]
        public void TestNativeSearch() => TestSearch(SearchInString.NaiveSearch);

        [TestMethod]
        public void TestRabinKarpSearch() => TestSearch(SearchInString.RabinKarpSearch);
        
        private void TestSearch(Func<string, string, ArrayList<int>> searchAlgorythm)
        {
            var random = new Random();
            var stringsArray = new string[] { "A", "ab", "abc", "abcd", "abcdef", "DeF", "Sub string", "The Naive String Matching algorithm slides the pattern one by one", "(_)", "幼稚的字符串匹配算法可將模式一一滑動" };
            var delimitersArray = new char[] { ' ', ',' };

            for (int i = 0; i < 2000; i++)
            {
                var textBuilder = new StringBuilder();
                for (int j = 0; j < i / 10; j++)
                {
                    var word = stringsArray[random.Next(stringsArray.Length)];
                    var delimiter = delimitersArray[random.Next(delimitersArray.Length)];
                    textBuilder.Append(word);
                    if (i % 3 != 0)
                    {
                        textBuilder.Append(delimiter);
                    }
                }

                var text = textBuilder.ToString();
                var pattern = stringsArray[random.Next(stringsArray.Length)];
                if (i % 3 == 0 && pattern.Length > 1)
                {
                    pattern = pattern.Substring(0, random.Next(pattern.Length - 1));
                }

                var matches = searchAlgorythm(text, pattern).ToArray();
                var expectedMatches = ControlSearchInStringAlgoryth(text, pattern);

                Assert.AreEqual(expectedMatches.Length, matches.Length);
                CollectionAssert.AreEqual(expectedMatches, matches);
            }
        }

        private int[] ControlSearchInStringAlgoryth(string text, string pattern)
        {
            pattern = Regex.Escape(pattern);
            return Regex.Matches(text, pattern).Cast<Match>().Select(m => m.Index).ToArray();
        }
    }
}
