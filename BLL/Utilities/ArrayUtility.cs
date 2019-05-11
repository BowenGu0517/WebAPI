using System;

namespace BLL.Utilities
{
    public static class ArrayUtility<T>
    {
        public static T[] Reverse(T[] inputArray)
        {
            var reversedArray = new T[inputArray.Length];

            for (var index = 0; index < inputArray.Length; index++)
            {
                reversedArray[inputArray.Length - 1 - index] = inputArray[index];
            }

            return reversedArray;
        }

        public static T[] DeletePart(int position, T[] inputArray)
        {
            if (position <= 0 || position > inputArray.Length)
                throw new ArgumentOutOfRangeException(nameof(position));

            var deletedPartArray = new T[inputArray.Length - 1];

            for (var index = 0; index < position - 1; index++)
            {
                deletedPartArray[index] = inputArray[index];
            }
            for (var index = position; index < inputArray.Length; index++)
            {
                deletedPartArray[index - 1] = inputArray[index];
            }

            return deletedPartArray;
        }
    }
}
