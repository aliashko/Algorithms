﻿using System;

namespace DataStructures.Arrays
{
    public class Stack<T>
    {
        private ArrayList<T> dataArray;

        public Stack()
        {
            dataArray = new ArrayList<T>();
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public void Push(T element)
        {
            dataArray.Add(element);
        }

        /// <summary>
        /// O(1)?
        /// </summary>
        public T Pop()
        {
            var lastIndex = dataArray.GetLength() - 1;

            if(lastIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var lastItem = dataArray[lastIndex];
            dataArray.Remove(lastIndex);

            return lastItem;
        }

        public T[] ToArray()
        {
            var array = new T[dataArray.GetLength()];
            for(var i = 0; i < dataArray.GetLength(); i++)
            {
                array[i] = dataArray[dataArray.GetLength() - 1 - i];
            }
            return array;
        }
    }
}
