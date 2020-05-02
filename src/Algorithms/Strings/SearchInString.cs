using DataStructures.Arrays;
using System;

namespace Algorithms.Strings
{
    public static class SearchInString
    {
        public static ArrayList<int> NaiveSearch(string text, string pattern)
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
            const int alphabetLength = 256;
            const int primeNumber = 101;

            // Hashing functions
            int HashString(string stringToHash, int lengthToHash)
            {
                var hash = 0;
                for (var i = 0; i < lengthToHash; i++)
                {
                    hash = (alphabetLength * hash + stringToHash[i]) % primeNumber;
                }
                return hash;
            }

            int Rehash(int oldHash, char oldChar, char newChar, int differenceFactor)
            {
                var hash = (alphabetLength * (oldHash - oldChar * differenceFactor) + newChar) % primeNumber;

                if (hash < 0) {
                    hash += primeNumber;
                }

                return hash;
            }

            if(pattern.Length > text.Length)
            {
                return matchesIndexes;
            }

            var patternHash = HashString(pattern, pattern.Length);
            var textSubstringHash = HashString(text, pattern.Length);

            int differenceFactor = 1;
            for (var i = 0; i < pattern.Length - 1; i++)
                differenceFactor = (differenceFactor * alphabetLength) % primeNumber;

            // Matching
            for (var i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (patternHash == textSubstringHash)
                {
                    var matchFound = true;
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if(pattern[j] != text[i + j])
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

                // Rehash next substring
                if(i < text.Length - pattern.Length && pattern.Length != 0)
                {
                    textSubstringHash = Rehash(textSubstringHash, text[i], text[i+pattern.Length], differenceFactor);
                }                
            }

            return matchesIndexes;
        }
    }
}
