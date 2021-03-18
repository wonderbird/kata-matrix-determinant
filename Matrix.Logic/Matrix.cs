using System;

namespace Matrix.Logic
{
    public static class Matrix
    {
        private static double[][] _matrix;
        private static int _countSwappedLines;

        public static int Determinant(int[][] matrix)
        {
            Console.WriteLine("Input:");
            matrix.Write();

            _matrix = CloneToDoubleMatrix(matrix);
            ReduceToLeftRowEchelonForm();
            var determinant = Math.Pow(-1, _countSwappedLines) * MultiplyDiagonal();

            return (int)Math.Round(determinant);
        }

        private static double[][] CloneToDoubleMatrix(int[][] matrix)
        {
            var result = new double[matrix.Length][];
            for (var line = 0; line < matrix.Length; line++)
            {
                result[line] = new double[matrix.Length];
                matrix[line].CopyTo(result[line], 0);
            }

            return result;
        }

        private static void ReduceToLeftRowEchelonForm()
        {
            _countSwappedLines = 0;
            for (var sourceLine = 0; sourceLine < _matrix.Length - 1; sourceLine++)
            {
                var divider = GetDividerForLine(sourceLine);
                if (divider == 0)
                {
                    SwapWithLineHavingNonZeroDivider(sourceLine);
                    divider = GetDividerForLine(sourceLine);
                    _countSwappedLines++;
                }

                TransformSubsequentLinesToHaveLeadingZeros(sourceLine, divider);
            }
        }

        private static double GetDividerForLine(int sourceLine) => _matrix[sourceLine][sourceLine];

        private static void SwapWithLineHavingNonZeroDivider(int expectedLineIndex)
        {
            var swapCandidate = FindLineWithNonZeroDivider(expectedLineIndex);
            SwapLines(expectedLineIndex, swapCandidate);
        }

        private static int FindLineWithNonZeroDivider(int expectedLineIndex)
        {
            var swapCandidate = expectedLineIndex + 1;
            while (swapCandidate < _matrix.Length && _matrix[swapCandidate][expectedLineIndex] == 0)
            {
                swapCandidate++;
            }

            if (_matrix[swapCandidate][expectedLineIndex] == 0)
            {
                throw new ArgumentException(
                    $"Found no suitable candidate for swapping lines. All lines start with {expectedLineIndex + 1} or more zeros.");
            }

            return swapCandidate;
        }

        private static void SwapLines(int sourceLine, int swapCandidate)
        {
            var temp = new double[_matrix.Length];
            _matrix[sourceLine].CopyTo(temp, 0);
            _matrix[swapCandidate].CopyTo(_matrix[sourceLine], 0);
            temp.CopyTo(_matrix[swapCandidate], 0);
        }

        private static void TransformSubsequentLinesToHaveLeadingZeros(int sourceLine, double divider)
        {
            for (var targetLine = sourceLine + 1; targetLine < _matrix.Length; targetLine++)
            {
                var factor = _matrix[targetLine][sourceLine];
                for (var column = sourceLine; column < _matrix.Length; column++)
                {
                    _matrix[targetLine][column] = _matrix[targetLine][column] - _matrix[sourceLine][column] / divider * factor;
                }

                Console.WriteLine("Matrix after reduction step:");
                _matrix.Write();
            }
        }

        private static double MultiplyDiagonal()
        {
            var result = 1.0;
            for (var i = 0; i < _matrix.Length; i++)
            {
                result *= _matrix[i][i];
            }

            return result;
        }

        private static void Write<T>(this T[][] matrix)
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
    }
}