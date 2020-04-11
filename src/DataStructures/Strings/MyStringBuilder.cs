using DataStructures.Arrays;

namespace DataStructures.Strings
{
    public class MyStringBuilder
    {
        ArrayList<char> charsArray;

        public MyStringBuilder(string initialString = null)
        {
            charsArray = new ArrayList<char>();

            if (!string.IsNullOrEmpty(initialString))
            {
                charsArray.AddRange(initialString.ToCharArray());
            }
        }

        public void Append(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                charsArray.AddRange(str.ToCharArray());
            }
        }

        public int GetLength()
        {
            return charsArray.GetLength();
        }

        public override string ToString()
        {
            return new string(charsArray.ToArray());
        }
    }
}
