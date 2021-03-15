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

        private static void RunTest(int[] expected, int[][][] testData)
        {
            for (var index = 0; index < expected.Length; index++)
            {
                Assert.Equal(expected[index], Matrix.Determinant(testData[index]));
            }
        }
    }
}