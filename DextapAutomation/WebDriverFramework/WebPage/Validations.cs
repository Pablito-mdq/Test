using System.Text.RegularExpressions;
using MbUnit.Framework;

namespace WebDriverFramework.Validations
{

    internal class Validations
    {
        /// <summary>
        /// Performs a comparison between two strings.
        /// Throws an exception if strings are not equal.
        /// </summary>
        /// <param name="actual">The actual string</param>
        /// <param name="expected">The expected to be string</param>
        public static void StringsMatch(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Attempts to match a regex pattern against a given string.
        /// Throws an exception if string does not pass the Finite State Machine test.
        /// </summary>
        /// <param name="actual">The actual string</param>
        /// <param name="pattern">The regex pattern to use</param>
        public static void StringsMatchesPattern(string actual, string pattern)
        {
            Assert.IsTrue(Regex.IsMatch(actual, pattern));
        }

    }
}
