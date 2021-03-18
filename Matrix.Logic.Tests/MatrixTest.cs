using Xunit;

namespace Matrix.Logic.Tests
{
    public class MatrixTest
    {
        [Fact]
        public static void Determinant_SingleElementMatrix_ReturnsElementValue()
        {
            var testData = new[]
            {
                new[] { new[] { 1 } },
                new[] { new[] { 5 } },
            };
            var expected = new[]
            {
                1,
                5,
            };

            RunTest(expected, testData);
        }

        [Fact]
        public static void Determinant_2x2Matrix_ReturnsCorrectDeterminant()
        {
            var testData = new[]
            {
                new[] { new[] { 1, 2 }, new[] { 3, 4 } },
                new[] { new[] { 1, 3 }, new[] { 2, 5 } },
            };
            var expected = new[]
            {
                -2,
                -1,
            };

            RunTest(expected, testData);
        }

        // https://matrix.reshish.com/de/detCalculation.php
        /*
2  5  3
1 -2 -1
1  3  4
         */
        [Fact]
        public static void Determinant_3x3Matrix_ReturnsCorrectDeterminant()
        {
            var testData = new[]
            {
                new[] { new[] { 2, 5, 3 }, new[] { 1, -2, -1 }, new[] { 1, 3, 4 } },
            };
            var expected = new[]
            {
                -20
            };

            RunTest(expected, testData);
        }

        // https://matrix.reshish.com/de/detCalculation.php
        [Fact]
        public static void Determinant_5x5Matrix_ReturnsCorrectDeterminant()
        {
            var testData = new[]
            {
                new[]
                {
                    new[] { 1, 3, 4, 2, 7 },
                    new[] { 2, 8, 4, 3, 6 },
                    new[] { 1, 6, 4, 0, 3 },
                    new[] { 7, 0, 5, 2, 4 },
                    new[] { 13, 2, 8, 7, 0 },
                }
            };
            var expected = new[]
            {
                3313
            };

            RunTest(expected, testData);
        }
        
        // https://matrix.reshish.com/de/detCalculation.php
        /*
2 4 5 3 1 2
2 4 7 5 3 2
1 1 0 2 3 1
1 3 9 0 3 2
1 1 2 2 4 1
0 0 4 1 2 3
         */
        [Fact]
        public static void Determinant_Codewars6x6Matrix_ReturnsCorrectDeterminant()
        {
            var testData = new[]
            {
                new[]
                {
                    new [] { 2, 4, 5, 3, 1, 2 },
                    new [] { 2, 4, 7, 5, 3, 2 },
                    new [] { 1, 1, 0, 2, 3, 1 },
                    new [] { 1, 3, 9, 0, 3, 2 },
                    new [] { 1, 1, 2, 2, 4, 1 },
                    new [] { 0, 0, 4, 1, 2, 3 },
                }
            };
            var expected = new[]
            {
                88
            };

            RunTest(expected, testData);
        }
        
        // https://matrix.reshish.com/de/detCalculation.php
        /*
7 -1 4 1 -1 8 6 -8 9
-5 3 10 -1 -1 4 2 -7 0
2 7 10 8 10 -6 -2 -6 -10
-2 -2 2 2 -10 9 -10 3 10
-1 9 0 7 -4 -8 5 10 -5
-2 4 1 -8 -2 3 10 8 -4
10 10 -1 0 -8 -5 8 -3 5
-4 4 3 -9 -1 7 4 -8 -6
-10 6 0 8 -8 10 9 -10 0
         */
        [Fact]
        public static void Determinant_Codewars9x9Matrix_ReturnsCorrectDeterminant()
        {
            var testData = new[]
            {
                new[]
                {
                    new[] { 7, -1, 4, 1, -1, 8, 6, -8, 9 },
                    new[] { -5, 3, 10, -1, -1, 4, 2, -7, 0 },
                    new[] { 2, 7, 10, 8, 10, -6, -2, -6, -10 },
                    new[] { -2, -2, 2, 2, -10, 9, -10, 3, 10 },
                    new[] { -1, 9, 0, 7, -4, -8, 5, 10, -5 },
                    new[] { -2, 4, 1, -8, -2, 3, 10, 8, -4 },
                    new[] { 10, 10, -1, 0, -8, -5, 8, -3, 5 },
                    new[] { -4, 4, 3, -9, -1, 7, 4, -8, -6 },
                    new[] { -10, 6, 0, 8, -8, 10, 9, -10, 0 },
                }
            };
            var expected = new[]
            {
                -2114540878
            };

            RunTest(expected, testData);
        }

        // https://matrix.reshish.com/de/detCalculation.php
        /*
3 9 7 8 3 4 9 8 5 7
3 4 9 5 8 7 4 3 9 5
8 3 2 7 4 3 8 5 7 9
3 4 5 7 4 3 8 5 7 3
5 7 8 4 5 7 9 3 7 9
8 6 9 2 8 0 3 4 9 8
5 4 7 9 6 9 3 2 3 2
8 9 6 7 6 1 7 8 2 3
4 5 2 1 3 4 5 6 3 5
0 1 3 8 5 1 0 3 4 2
         */
        [Fact]
        public static void Determinant_10x10Matrix_ReturnsCorrectDeterminant()
        {
            var testData = new[]
            {
                new[]
                {
                    new[] { 3, 9, 7, 8, 3, 4, 9, 8, 5, 7 },
                    new[] { 3, 4, 9, 5, 8, 7, 4, 3, 9, 5 },
                    new[] { 8, 3, 2, 7, 4, 3, 8, 5, 7, 9 },
                    new[] { 3, 4, 5, 7, 4, 3, 8, 5, 7, 3 },
                    new[] { 5, 7, 8, 4, 5, 7, 9, 3, 7, 9 },
                    new[] { 8, 6, 9, 2, 8, 0, 3, 4, 9, 8 },
                    new[] { 5, 4, 7, 9, 6, 9, 3, 2, 3, 2 },
                    new[] { 8, 9, 6, 7, 6, 1, 7, 8, 2, 3 },
                    new[] { 4, 5, 2, 1, 3, 4, 5, 6, 3, 5 },
                    new[] { 0, 1, 3, 8, 5, 1, 0, 3, 4, 2 },
                }
            };
            var expected = new[]
            {
                11746830
            };

            RunTest(expected, testData);
        }

        private static void RunTest(int[] expected, int[][][] testData)
        {
            for (var index = 0; index < expected.Length; index++)
            {
                Assert.Equal(expected[index], Matrix.Determinant(testData[index]));
            }
        }
    }
}