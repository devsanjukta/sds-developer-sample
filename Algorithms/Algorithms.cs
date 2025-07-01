using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if(n < 0)
                throw new ArgumentOutOfRangeException("Value must be non-negative.");
           
            int result = 1;
            for (int i = n; i>=2; i--)
            {
                result *= i;
            }
            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return string.Empty;

            if (items.Length == 1)
                return items[0];

            int length = items.Length;
            var sb = new StringBuilder()
                .Append(items[0]); // Append the first item

            // Append middle items with ", "
            for (int i = 1; i < length - 1; i++)
            {
                sb.Append(", ")
                  .Append(items[i]);
            }

            // Append last item with " and "
            sb.Append(" and ")
              .Append(items[length - 1]);

            return sb.ToString();
        }

    }
}