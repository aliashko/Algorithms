using System;
using System.Linq;

namespace Algorithms.Arrays
{
    public static class SearchElements
    {
        public static void GetMaxElement()
        {
            var array = CommonFunctions.InitIntArray(100, 0, 1000);

            var maxElementIndex = 0;
            for(var i = 0; i < array.Length; i++)
            {
                if(array[i] > array[maxElementIndex])
                {
                    maxElementIndex = i;
                }
            }

            Console.WriteLine($"Max element: [{maxElementIndex}] = {array[maxElementIndex]}");

            // Test
            if(array.Max() != array[maxElementIndex])
            {
                throw new Exception("Algorythm result is incorrect");
            }
        }


    }
}
