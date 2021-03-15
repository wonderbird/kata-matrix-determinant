using System.Collections.Generic;

namespace Matrix.Logic
{
    public static class MatrixSlow
    {
        public static int Determinant(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }

            var determinant = 0;
            var sign = 1;

            for (var i = 0; i < matrix.Length; i++)
            {
                determinant += sign * matrix[0][i] * Determinant(SubMatrix(i, matrix));
                sign *= -1;
            }

            return determinant;

        }

        private static int[][] SubMatrix(int columnToRemove, IReadOnlyList<int[]> matrix)
        {
            var subMatrix = new int[matrix.Count - 1][];
            for (var row = 1; row < matrix.Count; row++)
            {
                subMatrix[row - 1] = new int[matrix.Count - 1];
                for (var column = 0; column < columnToRemove; column++)
                {
                    subMatrix[row - 1][column] = matrix[row][column];
                }
                for (var column = columnToRemove + 1; column < matrix.Count; column++)
                {
                    subMatrix[row - 1][column - 1] = matrix[row][column];
                }
            }
            return subMatrix;
        }
    }
}