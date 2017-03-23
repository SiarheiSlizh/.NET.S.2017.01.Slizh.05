using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{

    /// <summary>
    /// This class works with numbers.
    /// </summary>
    public static class BinaryOperation
    {
        #region BinaryNumber

        /// <summary>
        /// Extension method for double which represents number in binary format with double precision. 
        /// </summary>
        /// <param name="number">Number type of double.</param>
        /// <returns>Binary presentation of determained number.</returns>
        public static string GetBinaryNumber(this double number)
        {
            if (number.Equals(Double.Epsilon)) return Convert.ToString(BitConverter.DoubleToInt64Bits(Double.Epsilon), 2).PadLeft(4, '0');
            else return BinaryNumber(number);
        }

        #endregion


        #region private BinaryNumber

        /// <summary>
        /// This method calculates sign, exponent and mantissa to represent number in binary format with double precision.  
        /// </summary>
        /// <param name="number">Number type of double.</param>
        /// <returns>Binary presentation of determained number.</returns>
        private static string BinaryNumber(double number)
        {
            long num = BitConverter.DoubleToInt64Bits(number);
            long s = (num >> 63) & 1;
            long e = (num >> 52) & ((long)Math.Pow(2, 11) - 1);
            long m = num & ((long)Math.Pow(2, 52) - 1);

            return Convert.ToString(s, 2) + Convert.ToString(e, 2).PadLeft(11, '0') + Convert.ToString(m, 2).PadLeft(52, '0');
        }

        #endregion
    }
}
