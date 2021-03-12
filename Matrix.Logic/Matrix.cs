namespace Matrix.Logic
{
    public class Matrix
    {
        public static int Determinant(int[][] matrix)
        {
            if (matrix.Length > 1)
            {
                return matrix[0][0] * Determinant(SubMatrix(0, matrix)) - matrix[0][1] * Determinant(SubMatrix(1, matrix));
            }
            return matrix[0][0];
        }

        private static int[][] SubMatrix(int columnToRemove, int[][] matrix)
        {
            var subMatrix = new int[matrix.Length - 1][];
            for (var row = 1; row < matrix.Length; row++)
            {
                subMatrix[row - 1] = new int[matrix.Length - 1];
                for (var targetColumn = 0; targetColumn < matrix.Length - 1; targetColumn++)
                {
                    var originalColumn = (targetColumn < columnToRemove) ? targetColumn : targetColumn + 1; 
                    subMatrix[row - 1][targetColumn] = matrix[row][originalColumn];
                }
            }
            return subMatrix;
        }
    }
}