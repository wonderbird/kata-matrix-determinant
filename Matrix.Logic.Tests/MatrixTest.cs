using Xunit;

namespace Matrix.Logic.Tests
{
    public class MatrixTest
    {
        [Fact]
        public static void Determinant_SingleElementMatrix_ReturnsElementValue()
        {
            var testData = new int[][][]
            {
                new int[][] { new int[] { 1 } },
                new int[][] { new int[] { 5 } },
            };
            var expected = new int[]
            {
                1,
                5,
            };

            for (var index = 0; index < expected.Length; index++)
            {
                Assert.Equal(expected[index], Matrix.Determinant(testData[index]));
            }
        }
    }
}