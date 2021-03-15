namespace Matrix.Logic
{
    public static class Matrix
    {
        public static int Determinant(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }

            var newTopRow = new double[matrix.Length + 1];
            var divider = matrix[0][0];
            var factor = matrix[1][0];
            for (var i = 0; i < matrix.Length; i++)
            {
                newTopRow[i] = (double)matrix[0][i] / divider * factor;
                matrix[1][i] -= newTopRow[i];
            }

            return matrix[0][0];
        }
    }
}