using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// This class uses math operations.
    /// </summary>
    public static class MathOperations
    {

        #region EuclidMethod

        public static int GCDEuclid(Func<int, int, int> gcd, int first) => Math.Abs(first);

        public static int GCDEuclid(Func<int, int, int> gcd, int first, int second) => gcd(first, second);

        public static int GCDEuclid(Func<int, int, int> gcd, int first, int second, int third) => gcd(gcd(first, second), third);

        public static int GCDEuclid(Func<int, int, int> gcd, out long elapsedTime, int first)
        {
            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            int result = first;

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return result;    
        } 

        public static int GCDEuclid(Func<int, int, int> gcd, out long elapsedTime, int first, int second)
        {
            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            int result = gcd(first, second);

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return result;
        }

        public static int GCDEuclid(Func<int, int, int> gcd, out long elapsedTime, int first, int second, int third)
        {
            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            int result = gcd(gcd(first, second), third);

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Method finds gcd of several integers by Euclid method.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Gcd of several integers.</returns>
        public static int GcdEuclid(Func<int,int,int> gcd, out long elapsedTime, params int[] numbers)
        {
            if (numbers.Contains(0))
                numbers = numbers.Where(p => p != 0).Distinct().OrderByDescending(p => p).ToArray();

            if (numbers.Length == 0)
                throw new ArgumentException();

            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            for (int i = 0; i < numbers.Length - 1; i++)
                numbers[i + 1] = gcd(numbers[i], numbers[i + 1]);

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return Math.Abs(numbers.Last());
        }

        public static int GcdEuclid(Func<int, int, int> gcd, params int[] numbers)
        {
            if (numbers.Contains(0))
                numbers = numbers.Where(p => p != 0).Distinct().OrderByDescending(p => p).ToArray();

            if (numbers.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < numbers.Length - 1; i++)
                numbers[i + 1] = gcd(numbers[i], numbers[i + 1]);

            return Math.Abs(numbers.Last());
        }

        #endregion


        #region EuclidMethod

        /// <summary>
        /// Method calculates gcd of two integers by Euclid method.
        /// </summary>
        /// <param name="number1">First integer.</param>
        /// <param name="number2">Second integer.</param>
        /// <returns>Gcd of two integers.</returns>
        public static int EuclidMethod(int number1, int number2)
        {
            int t;
            while (number2 != 0)
            {
                t = number2;
                number2 = number1 % number2;
                number1 = t;
            }
            return number1;
        }

        #endregion


        #region BinaryEuclidMethod

        /// <summary>
        /// Method finds gcd of two numbers by binary Euclid method.
        /// </summary>
        /// <param name="number1">First number.</param>
        /// <param name="number2">Second number.</param>
        /// <returns>Gcd of two integers.</returns>
        public static int BinaryEuclidMethod(int number1, int number2)
        {
            if (number1 == 0) return number2;
            if (number2 == 0) return number1;
            if (number1 == number2) return number1;
            if (number1 == 1 || number2 == 1) return 1;
            if ((number1 % 2 == 0) && (number2 % 2 == 0)) return 2 * BinaryEuclidMethod(number1 / 2, number2 / 2);
            if ((number1 % 2 == 0) && (number2 % 2 != 0)) return BinaryEuclidMethod(number1 / 2, number2);
            if ((number1 % 2 != 0) && (number2 % 2 == 0)) return BinaryEuclidMethod(number1, number2 / 2);
            return BinaryEuclidMethod(number2, Math.Abs(number1 - number2));
        }

        #endregion
    }
}