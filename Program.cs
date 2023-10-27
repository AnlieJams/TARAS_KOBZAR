using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // СЮДА ГРУЗИТЬ ТЕКСТ
        string text = File.ReadAllText("Kobzar.txt");

        
        string[] words = Regex.Split(text, @"\W+");

       
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        
        foreach (string word in words)
        {
            
            if (word.Length >= 3 && word.Length <= 20)
            {
               
                string lowercaseWord = word.ToLower();

                
                if (wordFrequency.ContainsKey(lowercaseWord))
                {
                    wordFrequency[lowercaseWord]++;
                }
                else
                {
                    wordFrequency[lowercaseWord] = 1;
                }
            }
        }

        
        var topWords = wordFrequency.OrderByDescending(pair => pair.Value)
                                     .Take(50)
                                     .ToDictionary(pair => pair.Key, pair => pair.Value);

        
        Console.WriteLine("Топ-50 самых популярных слов в сборнике \"Кобзарь\":");
        int rank = 1;
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{rank}. {pair.Key}: {pair.Value} раз");
            rank++;
        }
    }
}
