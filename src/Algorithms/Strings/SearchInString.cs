using DataStructures.Arrays;

namespace Algorithms.Strings
{
    public static class SearchInString
    {
        public static ArrayList<int> NativeSearch(string text, string pattern)
        {
            var matchesIndexes = new ArrayList<int>();

            for(int i=0; i<=text.Length - pattern.Length; i++)
            {
                var matchFound = true;
                for(int j = 0; j < pattern.Length; j++)
                {
                    if (text[i + j] != pattern[j])
                    {
                        matchFound = false;
                        break;
                    }
                }
                if (matchFound)
                {
                    matchesIndexes.Add(i);
                }
            }

            return matchesIndexes;
        }

        public static ArrayList<int> RabinKarpSearch(string text, string pattern)
        {
            var matchesIndexes = new ArrayList<int>();

            //TODO: Implement algoruthm

            return matchesIndexes;
        }
    }
}
