using DataStructures.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Strings
{
    [TestClass]
    public class MyStringBuilderTests
    {
        [TestMethod]
        public void StringsCanBeAddedToStringBuilder()
        {
            var strings = new string[] {"Some","string", "long string - in NetCF arguments pretty much don't matter as long as count is 0", "", null };
            var stringBuilder = new MyStringBuilder();

            var actualString = string.Empty;
            for (int i = 0; i < 200; i++) {
                actualString += strings[i % strings.Length];
                stringBuilder.Append(strings[i % strings.Length]);

                Assert.AreEqual(actualString.Length, stringBuilder.GetLength());
                Assert.AreEqual(actualString, stringBuilder.ToString());
            }
        }

        [TestMethod]
        public void VeryLongStringsCanBeAddedToStringBuilder()
        {
            var stringBuilder = new MyStringBuilder();

            var actualString = string.Empty;
            for (int i = 0; i < 200; i++) {
                var str = new string('a', 10000);
                actualString += str;
                stringBuilder.Append(str);

                Assert.AreEqual(actualString.Length, stringBuilder.GetLength());
                Assert.AreEqual(actualString, stringBuilder.ToString());
            }
        }
    }
}
