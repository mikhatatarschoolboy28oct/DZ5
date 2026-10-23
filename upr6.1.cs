using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
   
    private const string Vowels = "аеёиоуыэюяaeiouy";
    private const string Consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxz";


    static void CountLetters(List<char> text, out int vowels, out int consonants)
    {
        vowels = 0;
        consonants = 0;

        foreach (char c in text)
        {
            char lower = char.ToLower(c);

            if (Vowels.IndexOf(lower) >= 0)
                vowels++;
            else if (Consonants.IndexOf(lower) >= 0)
                consonants++;
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (args.Length == 0)
        {
            Console.WriteLine("Использование: Program <имя_файла>");
            return;
        }

        string fileName = "world.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл \"{fileName}\" не найден.");
            return;
        }

        try
        {
            // Содержимое файла заносим в список символов
            List<char> text = new List<char>(File.ReadAllText(fileName, Encoding.UTF8));

            CountLetters(text, out int vowels, out int consonants);

            Console.WriteLine($"Гласных букв:   {vowels}");
            Console.WriteLine($"Согласных букв: {consonants}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
        }
    }
}