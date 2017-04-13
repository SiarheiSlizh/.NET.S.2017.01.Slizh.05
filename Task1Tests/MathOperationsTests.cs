using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Tests
{
    [TestFixture]
    public class MathOperationsTests
    {
        #region MathOperations

        #region GcdEuclid

        [TestCase(0,0)]
        [TestCase(0)]
        [TestCase()]
        public void GcdEuclid_ArgumentException(params int[] numbers)
        {
            long ElapsedTime = default(long);
            Assert.Throws<ArgumentException>(() => MathOperations.GcdEuclid(MathOperations.EuclidMethod, out ElapsedTime, numbers));
        }


        [TestCase(12, -44, ExpectedResult = 4)]
        [TestCase(5, 25, ExpectedResult = 5)]
        [TestCase(-128, 1024, 256, 512, ExpectedResult = 128)]
        [TestCase(0, 1024, -256, 512, ExpectedResult = 256)]
        [TestCase(19, 37, 14, ExpectedResult = 1)]
        [TestCase(5, ExpectedResult = 5)]
        public int GcdEuclid_PositiveTest(params int[] numbers)
        {
            long elapsedTime = default(long);
            int result = MathOperations.GcdEuclid(MathOperations.EuclidMethod, out elapsedTime, numbers);
            Debug.WriteLine("Elapsed time: " + elapsedTime);
            return result;
        }

        #endregion


        #region BinaryGcdEuclid 

        [TestCase(0, 0)]
        [TestCase(0)]
        [TestCase()]
        public void GcdBinaryEuclid_ArgumentException(params int[] numbers)
        {
            long ElapsedTime = default(long);
            Assert.Throws<ArgumentException>(() => MathOperations.GcdEuclid(MathOperations.BinaryEuclidMethod, out ElapsedTime, numbers));
        }


        [TestCase(12, -44, ExpectedResult = 4)]
        [TestCase(5, 25, ExpectedResult = 5)]
        [TestCase(-128, 1024, 256, 512, ExpectedResult = 128)]
        [TestCase(0, 1024, -256, 512, ExpectedResult = 256)]
        [TestCase(19, 37, 14, ExpectedResult = 1)]
        [TestCase(5, ExpectedResult = 5)]
        public int GcdBinaryEuclid_PositiveTest(params int[] numbers)
        {
            long elapsedTime = default(long);
            int result = MathOperations.GcdEuclid(MathOperations.BinaryEuclidMethod, out elapsedTime, numbers);
            Debug.WriteLine("Elapsed time: " + elapsedTime);
            return result;
        }

        #endregion

        #endregion
    }
}
