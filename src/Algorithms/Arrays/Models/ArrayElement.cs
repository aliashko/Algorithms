namespace Algorithms.Arrays.Models
{
    public struct ArrayElement
    {
        public ArrayElement(int elementIndex, int elementValue)
        {
            ElementIndex = elementIndex;
            ElementValue = elementValue;
        }

        public int ElementIndex { get; private set; }

        public int ElementValue { get; private set; }
    }
}
