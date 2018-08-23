using CSharpCalculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//there is 4 cores on my work station
namespace AutoTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class Abs_test: LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void Abs(object input)
        {
            //Thread.Sleep(1000); for paralelization testing
            double resultExpected;
            double resultCalculator;
            if (Convert.ToDouble(input) > 0)
            {
                resultExpected = Convert.ToDouble(input);
            }
            else
            {
                resultExpected = Convert.ToDouble(input) * (-1);
            }
            resultCalculator = calculator.Abs(input);
            Assert.AreEqual(resultExpected, resultCalculator);
        }

        static object[] Cases =
        {
            new object[] {"1"},
            new object[] {"1" },
            new object[] {"-1"},
            new object[] {"1.2"},
            new object[] {"1.0"},
            new object[] {"-1.2"},
            new object[] {"0.0"},

            new object[] {1},
            new object[] {-1},
            new object[] {0},

            new object[] {1.0},
            new object[] {1.2},
            new object[] {-1.0},
            new object[] {-1.2},
            new object[] {0.0},
            new object[] {0.2},

            new object[] {"1    "},
            new object[] {"     -1"}
        };

    }
}
