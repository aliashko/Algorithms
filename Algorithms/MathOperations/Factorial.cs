namespace Algorithms.MathOperations
{
    public static class Factorial
    {
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