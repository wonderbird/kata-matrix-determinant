using System;

namespace Matrix.Logic
{
    public static class Matrix
    {
        public static int Determinant(int[][] matrix)
        {
            Console.WriteLine("Input:");
            matrix.Write();

            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }

            var reducedMatrix = CloneToDoubleMatrix(matrix);
            ReduceToLeftRowEchelonForm(reducedMatrix);
            var result = MultiplyDiagonal(matrix, reducedMatrix);

            return (int)Math.Round(result);
        }

        public static void Write<T>(this T[][] matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var column in row)
                {
                    Console.Write($"{column} ");
                }
                Console.WriteLine();
            }
        }

        private static double[][] CloneToDoubleMatrix(int[][] matrix)
        {
            var reducedMatrix = new double[matrix.Length][];
            for (var line = 0; line < matrix.Length; line++)
            {
                reducedMatrix[line] = new double[matrix.Length];
                matrix[line].CopyTo(reducedMatrix[line], 0);
            }

            return reducedMatrix;
        }

        private static void ReduceToLeftRowEchelonForm(double[][] reducedMatrix)
        {
            for (var sourceLine = 0; sourceLine < reducedMatrix.Length - 1; sourceLine++)
            {
                for (var targetLine = sourceLine + 1; targetLine < reducedMatrix.Length; targetLine++)
                {
                    var divider = reducedMatrix[sourceLine][sourceLine];
                    var factor = reducedMatrix[targetLine][sourceLine];
                    for (var column = sourceLine; column < reducedMatrix.Length; column++)
                    {
                        reducedMatrix[targetLine][column] = reducedMatrix[targetLine][column] -
                                                            reducedMatrix[sourceLine][column] / divider * factor;
                    }
                }

                Console.WriteLine("Matrix after reduction step:");
                reducedMatrix.Write();
            }
        }

        private static double MultiplyDiagonal(int[][] matrix, double[][] reducedMatrix)
        {
            var result = 1.0;
            for (var i = 0; i < matrix.Length; i++)
            {
                result *= reducedMatrix[i][i];
            }

            return result;
        }
    }
}