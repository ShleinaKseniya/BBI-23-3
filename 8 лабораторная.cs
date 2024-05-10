using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

abstract class Task
{
    public Task(string text) { }
    protected virtual string ParseText(string text)
    { return text; }

}
class Task2 : Task
{
    private string text;
    public Task2(string text) : base(text) { this.text = text; }
    public string Encrypt(string text)
    {
        char[] punctuation = { '.', ',', '!', '?', ';', ':', '(', ')' };
        StringBuilder reversed = new StringBuilder();
        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            int punctuationIndex = -1;

            foreach (char p in punctuation)
            {
                if (word.Contains(p))
                {
                    punctuationIndex = word.IndexOf(p);
                    break;
                }
            }

            if (punctuationIndex != -1)
            {
                string reversedWord = new string(word.Substring(0, punctuationIndex).ToCharArray().Reverse().ToArray());
                reversed.Append(reversedWord + word[punctuationIndex]);
            }
            else
            {
                string reversedWord = new string(word.ToCharArray().Reverse().ToArray());
                reversed.Append(reversedWord);
            }

            if (i < words.Length - 1)
            {
                reversed.Append(" ");
            }
        }

        return (reversed).ToString();
    }
    public string Descrypt(string text2)
    {
        text = Encrypt(text2);
        return text;
    }
}
class Task4 : Task
{
    private string text;
    public Task4(string text) : base(text) { this.text = text; }

    public int HardText(string text4)
    {
        int hardText = 0;
        string[] words = text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            foreach (char c in word)
            {
                if (char.IsPunctuation(c))
                {
                    hardText++;
                }
            }
        }
        hardText += words.Length;
        return hardText;
    }
}


class Task7 : Task
{
    private string text;

    public Task7(string text) : base(text)
    {
        if (text.Length > 1000)
        {
            throw new ArgumentException("Текст не должен превышать 1000 символов.");
        }

        this.text = text;
    }

    public List<string> FindWordsContainingSequence(string sequence)
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<string> matchingWords = new List<string>();
        foreach (string word in words)
        {
            if (word.IndexOf(sequence, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                matchingWords.Add(word);
            }
        }

        return matchingWords;
    }
}
class Task5 : Task
{
    private string text;

    public Task5(string text) : base(text)
    {
        if (text.Length > 1000)
        {
            throw new ArgumentException("Текст не должен превышать 1000 символов.");
        }

        this.text = text;
    }

    public void PrintLetterFrequencies()
    {
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();
        
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (string word in words)
        {
           
            
            char firstLetter = char.ToUpper(word[0]);
            if (char.IsLetter(firstLetter))
            { 

                if (letterCounts.ContainsKey(firstLetter))
                {
                    letterCounts[firstLetter]++;
                }
                else
                {
                    letterCounts[firstLetter] = 1;
                }
            }
        }

        var sortedLetters = letterCounts.OrderByDescending(pair => pair.Value);
        Console.WriteLine("Буквы в порядке убывания частоты употребления:");
        foreach (var pair in sortedLetters)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
class Task11 : Task
{
    private string lastNamesString;

    public Task11(string lastNamesString) : base(lastNamesString)
    {
        this.lastNamesString = lastNamesString;
    }

    public List<string> SortLastNames()
    {
        List<string> lastNames = lastNamesString.Split(", ").ToList();

        lastNames.Sort();

        return lastNames;
    }
}

class Task14 : Task
{
    private string text;

    public Task14(string text) : base(text)
    {
        this.text = text;
    }

    public int SumOfNumbers()
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int sum = 0;

        foreach (string word in words)
        {
            if (int.TryParse(word, out int number) && number >= 1 && number <= 10)
            {
                sum += number;
            }
        }

        return sum;
    }
}



class Program
{
    public static void Main()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ 2 данных показал, что основной участник 5 разрушения лесного 6 покрова - человеческая деятельность.";
        Task2 task2 = new Task2(text);
        Console.WriteLine("\t Text: ");
        Console.WriteLine(text);
        Console.WriteLine("\n \t Задание 2 зашифровано");
        Console.WriteLine(task2.Encrypt(text));
        Console.WriteLine("\n \t Задание 2 расшифровано");
        Console.WriteLine(task2.Descrypt(task2.Encrypt(text)));

        Task4 task4 = new Task4(text);
        Console.WriteLine("\n \t Задание 4");
        Console.WriteLine(task4.HardText(text));



        Task7 task7 = new Task7(text);
        List<string> wordsWithSequence = task7.FindWordsContainingSequence("лес");

        Console.WriteLine("\n\tЗадание 7");
        Console.WriteLine("Слова, содержащие последовательность 'лес':");
        foreach (string word in wordsWithSequence)
        {
            Console.WriteLine(word);
        }
        Task5 task5 = new Task5(text);
        Console.WriteLine("\n \t Задание 5");

        task5.PrintLetterFrequencies();

        string lastNamesString = "Иванов, Петров, Сидоров, Кузнецов, Васильев";
        Task11 task11 = new Task11(lastNamesString);
        List<string> sortedLastNames = task11.SortLastNames();

        Console.WriteLine("\n\tЗадание 11");
        Console.WriteLine("Отсортированный список фамилий:");
        foreach (string lastName in sortedLastNames)
        {
            Console.WriteLine(lastName);
        }

        Task14 task14 = new Task14(text);
        int sum = task14.SumOfNumbers();

        Console.WriteLine("\n\tЗадание 14");
        Console.WriteLine($"Сумма чисел в тексте: {sum}");


    }
}