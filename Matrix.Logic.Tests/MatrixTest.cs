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