﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using CSharpCalculator;
using log4net;
using log4net.Config;
using System.Threading;

namespace AutoTest
{
    [TestFixture]
    [Parallelizable]
    public class isPositive_test : LoggingTests
    {
        Calculator calculator = new Calculator();

        [Test, TestCaseSource("Cases")]
        public void isPositive(object input)
        {
            bool resultExpected;
            bool resultCalculator;
            resultExpected = (Convert.ToDouble(input) > 0);
            resultCalculator = calculator.isPositive(input);
            Assert.IsTrue(resultExpected == resultCalculator);
        }

        static object[] Cases =
        {
            new object[] {"1"},
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