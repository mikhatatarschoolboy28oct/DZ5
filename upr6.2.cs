using System;

class Program
{
    static void PrintMatrix(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                Console.Write($"{m[i, j],6}");
            Console.WriteLine();
        }
    }

    static int[,] MultiplyMatrices(int[,] a, int[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0))
            throw new ArgumentException("Умножение невозможно: размеры не согласованы.");

        int[,] r = new int[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < r.GetLength(0); i++)
            for (int j = 0; j < r.GetLength(1); j++)
                for (int k = 0; k < a.GetLength(1); k++)
                    r[i, j] += a[i, k] * b[k, j];
        return r;
    }

    static void Main()
    {
        int[,] a = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] b = { { 7, 8 }, { 9, 10 }, { 11, 12 } };

        PrintMatrix(MultiplyMatrices(a, b));
    }
}