using System;

namespace AdvancedGraph
{
    internal static class ArrayHelper
    {
        public static T[,] ResizeArray<T>(this T[,] original, int rows, int cols)
        {
            if (rows < 0)
                throw new ArgumentOutOfRangeException(nameof(rows), "Количество элементов не может быть отрицательным!");
            if (cols < 0)
                throw new ArgumentOutOfRangeException(nameof(cols), "Количество элементов не может быть отрицательным!");
            var newArray = new T[rows, cols];
            var minRows = Math.Min(rows, original.GetLength(0));
            var minCols = Math.Min(cols, original.GetLength(1));
            for (var i = 0; i < minRows; i++)
                for (var j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }
        public static T[,] AddColRow<T>(this T[,] original, int count, T defaultValue = default(T))
        {
            if (count == 0)
                return original;
            var rows = original.GetLength(0);
            var cols = original.GetLength(1);

            var rowsNew = rows + count;
            var colsNew = cols + count;

            var resizedArray = original.ResizeArray(rowsNew, colsNew);
            if (defaultValue != null && count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    for (var j = 0; j < rowsNew; j++)
                    {
                        resizedArray[rows + i, j] = defaultValue;
                    }
                    for (var j = 0; j < colsNew - 1; j++)
                    {
                        resizedArray[j, cols + i] = defaultValue;
                    }
                }
            }
            return resizedArray;
        }
        public static T[,] RemoveColRow<T>(this T[,] original, int toRemove)
        {
            if (toRemove < 0)
                throw new ArgumentOutOfRangeException("toRemove", "Индекс не может быть отрицательным!");
            var rows = original.GetLength(0);
            var cols = original.GetLength(1);
            if (toRemove > rows - 1 || toRemove > cols - 1)
                throw new ArgumentOutOfRangeException("toRemove", "Индекс находится вне грани массива!");
            var newArray = new T[rows - 1, cols - 1];

            var ni = 0;
            for (var i = 0; i < rows; i++)
            {
                if (i == toRemove)
                    continue;
                var nj = 0;
                for (var j = 0; j < cols; j++)
                {
                    if (j == toRemove)
                        continue;
                    newArray[ni, nj] = original[i, j];
                    nj++;
                }
                ni++;
            }
            return newArray;
        }
        public static T[] ResizeArray<T>(this T[] original, int newLenght)
        {
            if (newLenght < 0)
                throw new ArgumentOutOfRangeException("newLenght", "Количество элементов не может быть отрицательным!");

            var newArray = new T[newLenght];
            var minLenght = Math.Min(newLenght, original.GetLength(0));
            for (var i = 0; i < minLenght; i++)
            {
                newArray[i] = original[i];
            }
            return newArray;
        }
        public static T[] AddCell<T>(this T[] original, int count, T defaultValue = default(T))
        {
            if (count == 0)
                return original;
            var cells = original.GetLength(0);
            var cellNew = original.GetLength(0) + count;
            var resizedArray = original.ResizeArray(cellNew);
            if (defaultValue != null && count > 0)
            {
                for (var i = cells; i < cellNew; i++)
                {
                    resizedArray[i] = defaultValue;
                }
            }
            return resizedArray;
        }
        public static T[] RemoveCell<T>(this T[] original, int toRemove)
        {
            if (toRemove < 0)
                throw new ArgumentOutOfRangeException("toRemove", "Индекс не может быать отрицательным!");
            var cells = original.GetLength(0);
            if (toRemove > cells - 1)
                throw new ArgumentOutOfRangeException("toRemove", "Индекс находиатся вне грани массива!");
            var newAarray = new T[cells - 1];
            var ni = 0;
            for (var i = 0; i < cells; i++)
            {
                if (i == toRemove)
                    continue;
                newAarray[ni] = original[i];
                ni++;
            }
            return newAarray;
        }
        public static void PrintArray<T>(this T[] original)
        {
            var rows = original.GetLength(0);
            for (var i = 0; i < rows; i++)
            {
                Console.Write("{0,3}", original[i]);
            }
            Console.Write("\n");
        }
        public static void PrintMatrix<T>(this T[,] original)
        {
            var rows = original.GetLength(0);
            var cols = original.GetLength(1);
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    Console.Write("{0,3}", original[i, j]);
                }
                Console.Write("\n");
            }
        }
        public static void EnsureCapacity<T>(ref T[,] original, int minRows, int minCols)
        {
            var rows = original.GetLength(0);
            var cols = original.GetLength(1);
            if (rows < minRows || cols < minCols)
            {
                if (rows < minRows)
                {
                    rows = EnsureSize(rows, minRows);
                }
                if (cols < minCols)
                {
                    cols = EnsureSize(cols, minCols);
                }
                original = original.ResizeArray(rows, cols);
            }
        }
        public static void EnsureCapacity<T>(ref T[] original, int min)
        {
            var originalSize = original.Length;
            if (originalSize < min)
            {
                var newSize = EnsureSize(originalSize, min);
                original = original.ResizeArray(newSize);
            }
        }
        private static int EnsureSize(int original, int min)
        {
            var newSize = original == 0 ? 4 : original * 2;
            if (newSize > 0x7fefffff)
            {
                newSize = 0x7fefffff;
            }
            if (newSize < min)
            {
                newSize = min;
            }
            return newSize;
        }
    }
}
