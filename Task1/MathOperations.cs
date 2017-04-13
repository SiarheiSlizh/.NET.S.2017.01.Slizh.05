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

        #region public EuclidMethods and BinaryEuclidMethods without elapsedTime

        /// <summary>
        /// Calculates gcd by classic method
        /// </summary>
        /// <returns>Argument Exception</returns>
        public static int GcdEuclid()
        {
            throw new ArgumentException();
        }

        /// <summary>
        /// Calculates gcd of number by classic method
        /// </summary>
        /// <param name="first">number</param>
        /// <returns>gcd of number</returns>
        public static int GcdEuclid(int first) => Math.Abs(first);

        /// <summary>
        /// Calculates gcd of two numbers by classic method
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>gcd of two numbers</returns>
        public static int GcdEuclid(int first, int second) => DelegateMethod(EuclidMethod, first, second);

        /// <summary>
        /// Calculates gcd of three numbers by classic method
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <param name="third">third number</param>
        /// <returns>gcd of three numbers</returns>
        public static int GcdEuclid(int first, int second, int third) => DelegateMethod(EuclidMethod, DelegateMethod(EuclidMethod, first, second), third);

        /// <summary>
        /// Calculates gcd of four and more numbers by classic method
        /// </summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>gcd of four and more numbers</returns>
        public static int GcdEuclid(params int[] numbers)
        {
            if (numbers.Contains(0))
                numbers = numbers.Where(p => p != 0).Distinct().OrderByDescending(p => p).ToArray();

            if (numbers.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < numbers.Length - 1; i++)
                numbers[i + 1] = DelegateMethod(EuclidMethod, numbers[i], numbers[i + 1]);

            return Math.Abs(numbers.Last());
        }

        /// <summary>
        /// Calculates gcd by binary method
        /// </summary>
        /// <returns>Argument Exception</returns>
        public static int GcdBinaryEuclid()
        {
            throw new ArgumentException();
        }

        /// <summary>
        /// Calculates gcd of number by binary method
        /// </summary>
        /// <param name="first">number</param>
        /// <returns>gcd of number</returns>
        public static int GcdBinaryEuclid(int first) => Math.Abs(first);

        /// <summary>
        /// Calculates gcd of two numbers by binary method
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>gcd of two numbers</returns>
        public static int GcdBinaryEuclid(int first, int second) => DelegateMethod(BinaryEuclidMethod, first, second);

        /// <summary>
        /// Calculates gcd of three numbers by binary method
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <param name="third">third number</param>
        /// <returns>gcd of three numbers</returns>
        public static int GcdBinaryEuclid(int first, int second, int third) => DelegateMethod(BinaryEuclidMethod, DelegateMethod(BinaryEuclidMethod, first, second), third);

        /// <summary>
        /// Calculates gcd of four and more numbers by binary method
        /// </summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>gcd of four and more numbers</returns>
        public static int GcdBinaryEuclid(params int[] numbers)
        {
            if (numbers.Contains(0))
                numbers = numbers.Where(p => p != 0).Distinct().OrderByDescending(p => p).ToArray();

            if (numbers.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < numbers.Length - 1; i++)
                numbers[i + 1] = DelegateMethod(BinaryEuclidMethod, numbers[i], numbers[i + 1]);

            return Math.Abs(numbers.Last());
        }

        #endregion


        #region public EuclidMethods and BinaryEuclidMethods with elapsedTime

        /// <summary>
        /// Calculates gcd by classic method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <returns>Argument Exception</returns>
        public static int GcdEuclid(out long elapsedTime)
        {
            throw new ArgumentException();
        }

        /// <summary>
        /// Calculates gcd of number by classic method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <returns>gcd of number</returns>
        public static int GcdEuclid(out long elapsedTime, int first) => DelegateMethodWithTime(EuclidMethod, out elapsedTime, first, 0);

        /// <summary>
        /// Calculates gcd of two numbers by classic method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>gcd of two numbers</returns>
        public static int GcdEuclid(out long elapsedTime, int first, int second) => DelegateMethodWithTime(EuclidMethod, out elapsedTime, first, second);

        /// <summary>
        /// Calculates gcd of three numbers by classic method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <param name="third">gcd of three numbers</param>
        /// <returns></returns>
        public static int GcdEuclid(out long elapsedTime, int first, int second, int third) => DelegateMethodWithTime(EuclidMethod, out elapsedTime, DelegateMethod(EuclidMethod, first, second), third);

        /// <summary>
        /// Calculates gcd of four and more numbers by classic method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="numbers">gcd of four and more numbers</param>
        /// <returns></returns>
        public static int GcdEuclid(out long elapsedTime, params int[] numbers)
        {
            if (numbers.Contains(0))
                numbers = numbers.Where(p => p != 0).Distinct().OrderByDescending(p => p).ToArray();

            if (numbers.Length == 0)
                throw new ArgumentException();

            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            for (int i = 0; i < numbers.Length - 1; i++)
                numbers[i + 1] = DelegateMethod(EuclidMethod, numbers[i], numbers[i + 1]);

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return Math.Abs(numbers.Last());
        }

        /// <summary>
        /// Calculates gcd by binary method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <returns>gcd</returns>
        public static int GcdBinaryEuclid(out long elapsedTime)
        {
            throw new ArgumentException();
        }

        /// <summary>
        /// Calculates gcd of number by binary method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <returns>gcd of number</returns>
        public static int GcdBinaryEuclid(out long elapsedTime, int first) => DelegateMethodWithTime(BinaryEuclidMethod, out elapsedTime, first, 0);

        /// <summary>
        /// Calculates gcd of two numbers by binary method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>gcd of two numbers</returns>
        public static int GcdBinaryEuclid(out long elapsedTime, int first, int second) => DelegateMethodWithTime(BinaryEuclidMethod, out elapsedTime, first, second);

        /// <summary>
        /// Calculates gcd of three numbers by binary method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <param name="third">third number</param>
        /// <returns>gcd of three numbers</returns>
        public static int GcdBinaryEuclid(out long elapsedTime, int first, int second, int third) => DelegateMethodWithTime(BinaryEuclidMethod, out elapsedTime, DelegateMethod(BinaryEuclidMethod, first, second), third);

        /// <summary>
        /// Calculates gcd of four and more numbers by binary method with time measurement
        /// </summary>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="numbers">array of numbers</param>
        /// <returns>gcd of four and more numbers</returns>
        public static int GcdBinaryEuclid(out long elapsedTime, params int[] numbers)
        {
            if (numbers.Contains(0))
                numbers = numbers.Where(p => p != 0).Distinct().OrderByDescending(p => p).ToArray();

            if (numbers.Length == 0)
                throw new ArgumentException();

            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            for (int i = 0; i < numbers.Length - 1; i++)
                numbers[i + 1] = DelegateMethod(BinaryEuclidMethod, numbers[i], numbers[i + 1]);

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return Math.Abs(numbers.Last());
        }

        #endregion


        #region Delegated methods

        /// <summary>
        /// Calculates gcd by one of methods
        /// </summary>
        /// <param name="gcd">method of gcd calculating</param>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>gcd</returns>
        private static int DelegateMethod(Func<int, int, int> gcd, int first, int second) => gcd(first, second);

        /// <summary>
        /// Calculates gcd by one of methods with time measurement
        /// </summary>
        /// <param name="gcd">method of gcd calculating</param>
        /// <param name="elapsedTime">time measurement</param>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <returns>gcd</returns>
        private static int DelegateMethodWithTime(Func<int, int, int> gcd, out long elapsedTime, int first, int second)
        {
            elapsedTime = default(long);

            Stopwatch sw = new Stopwatch();
            sw.Restart();

            int result = DelegateMethod(gcd, first, second);

            sw.Stop();
            elapsedTime = sw.ElapsedMilliseconds;

            return result;
        }

        #endregion


        #region EuclidMethod

        /// <summary>
        /// Method calculates gcd of two integers by Euclid method.
        /// </summary>
        /// <param name="number1">First integer.</param>
        /// <param name="number2">Second integer.</param>
        /// <returns>Gcd of two integers.</returns>
        private static int EuclidMethod(int number1, int number2)
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
        private static int BinaryEuclidMethod(int number1, int number2)
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