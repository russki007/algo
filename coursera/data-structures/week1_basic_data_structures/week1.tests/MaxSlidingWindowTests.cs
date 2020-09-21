using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace week1.tests
{
    public class MaxSlidingWindowTests
    {
        [Theory]
        [InlineData(8, "2 7 3 1 5 2 6 2", 4, "7 7 5 6 6")]
        public void MainTest(int n, string seq, int m, string exp) {
            // Arrange
            int[] arr = Parse(seq), expected = Parse(exp);
            Assert.Equal(n, arr.Length);
            MaxSlidingWindow window = new MaxSlidingWindow(m, arr);

            // Act
            List<int> actual = new List<int>();
            do {
                actual.Add(window.Max());
            } while (window.MoveNext());

            // Assert
            Assert.Equal(expected, actual.ToArray());
            Assert.Throws<NotEqualException>(() => Assert.NotEqual(expected, actual.ToArray()));
        }

        public static int[] Parse(string s, char sep = ' ') 
            => Array.ConvertAll(s.Split(sep, StringSplitOptions.RemoveEmptyEntries), Int32.Parse);
    }
}
