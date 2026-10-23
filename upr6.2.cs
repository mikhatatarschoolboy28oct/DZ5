using System;

class Program
{
    static double[] GetMonthlyAverages(int[,] temperature)
    {
        int months = temperature.GetLength(0);
        int days = temperature.GetLength(1);
        double[] averages = new double[months];

        for (int m = 0; m < months; m++)
        {
            double sum = 0;
            for (int d = 0; d < days; d++)
                sum += temperature[m, d];
            averages[m] = sum / days;
        }
        return averages;
    }

    static void Main()
    {
        var rnd = new Random();
        int[,] temperature = new int[12, 30];

        for (int m = 0; m < 12; m++)
            for (int d = 0; d < 30; d++)
                temperature[m, d] = rnd.Next(-30, 36);

        double[] averages = GetMonthlyAverages(temperature);

        Console.WriteLine("Средняя температура по месяцам:");
        for (int i = 0; i < averages.Length; i++)
            Console.WriteLine($"Месяц {i + 1}: {averages[i]:F2}");

        Array.Sort(averages);

        Console.WriteLine("\nСредние температуры по возрастанию:");
        foreach (double avg in averages)
            Console.WriteLine($"{avg:F2}");
    }
}