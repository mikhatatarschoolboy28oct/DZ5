using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, double> GetMonthlyAverages(Dictionary<string, int[]> temperature)
    {
        var averages = new Dictionary<string, double>();
        foreach (var pair in temperature)
            averages[pair.Key] = pair.Value.Average();
        return averages;
    }

    static void Main()
    {
        string[] months =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        var rnd = new Random();
        var temperature = new Dictionary<string, int[]>();

        foreach (string month in months)
        {
            int[] days = new int[30];
            for (int d = 0; d < days.Length; d++)
                days[d] = rnd.Next(-30, 36); // от -30 до 35 °C
            temperature[month] = days;
        }

        var averages = GetMonthlyAverages(temperature);

        Console.WriteLine("Средняя температура по месяцам:");
        foreach (var pair in averages)
            Console.WriteLine($"{pair.Key,-10}: {pair.Value:F2}");

        Console.WriteLine("\nПо возрастанию средней температуры:");
        foreach (var pair in averages.OrderBy(p => p.Value))
            Console.WriteLine($"{pair.Key,-10}: {pair.Value:F2}");
    }
}