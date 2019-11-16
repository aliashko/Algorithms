namespace Algorithms.MathOperations
{
    public static class Factorial
    {
        /// <summary>
        /// time complexity  - O(1)
        /// space complexity - O(1)
        /// </summary>
        public static long CalcRecursively(int number)
        {
            if(number == 1)
            {
                return 1;
            }
            return CalcRecursively(number - 1) * number;
        }
    }
}