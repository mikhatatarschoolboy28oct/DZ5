using System;
using System.Collections.Generic;

class Program
{
    static void PrintMatrix(LinkedList<LinkedList<int>> m)
    {
        foreach (var row in m)
        {
            foreach (var x in row)
                Console.Write($"{x,6}");
            Console.WriteLine();
        }
    }

    static LinkedList<LinkedList<int>> MultiplyMatrices(
        LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
    {
        var result = new LinkedList<LinkedList<int>>();

        foreach (var rowA in a)
        {
            var newRow = new LinkedList<int>();
            for (int j = 0; j < b.First.Value.Count; j++)
            {
                int sum = 0;
                var nodeA = rowA.First;
                foreach (var rowB in b)
                {
                    sum += nodeA.Value * rowB.ElementAt(j);
                    nodeA = nodeA.Next;
                }
                newRow.AddLast(sum);
            }
            result.AddLast(newRow);
        }
        return result;
    }

    static void Main()
    {
        var a = new LinkedList<LinkedList<int>>();
        a.AddLast(new LinkedList<int>(new[] { 1, 2, 3 }));
        a.AddLast(new LinkedList<int>(new[] { 4, 5, 6 }));

        var b = new LinkedList<LinkedList<int>>();
        b.AddLast(new LinkedList<int>(new[] { 7, 8 }));
        b.AddLast(new LinkedList<int>(new[] { 9, 10 }));
        b.AddLast(new LinkedList<int>(new[] { 11, 12 }));

        PrintMatrix(MultiplyMatrices(a, b));
    }
}