
//1
using System;

namespace Kr
{
    class Program
    {
        static void Main(string[] args)
        {
            WordCalculation calculation = new WordCalculation();

            Console.WriteLine("Введите слово:");
            string text = Console.ReadLine();

            int uniqueLetterCount = calculation.CountLettersAmount(text);

            Console.WriteLine($"Количество уникальных букв в слове \"{text}\": {uniqueLetterCount}");
        }
    }

    class WordCalculation
    {
        public int CountLettersAmount(string text)
        {
            bool[] uniqueLetters = new bool[26];

            foreach (char letter in text.ToLower())
            {
                if (char.IsLetter(letter) && char.IsLetterOrDigit(letter))
                {

                    int index = letter - 'а';


                    uniqueLetters[index] = true;
                }
            }

            int uniqueLetterCount = 0;
            foreach (bool flag in uniqueLetters)
            {
                if (flag)
                {
                    uniqueLetterCount++;
                }
            }

            return uniqueLetterCount;
        }
    }
}








//2

using System;
namespace LetterShifter
{
    class Program
    {
        static void Main(string[] args)
        {
            TextShifter shifter = new TextShifter();
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            string shiftedText = shifter.ShiftLetters(text, 10);
            Console.WriteLine($"Сдвинутый текст:");
            Console.WriteLine(shiftedText);
        }
    }

    class TextShifter
    {
        public string ShiftLetters(string text, int shiftAmount)
        {
            char[] shiftedText = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (char.IsLetter(letter) && char.IsLetterOrDigit(letter))
                {
                    letter = (char)((int)letter + shiftAmount);
                    if (letter > 'я')
                    {
                        letter = 'а';
                    }
                }
                shiftedText[i] = letter;
            }
            return new string(shiftedText);
        }
    }
}






//3
using System;
using System.IO;

namespace FileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "m2300951", "Answers");
            Directory.CreateDirectory(folderPath);

            string filePath1 = Path.Combine(folderPath, "task_1.json");
            string filePath2 = Path.Combine(folderPath, "task_2.json");

            if (!File.Exists(filePath1))
            {
                File.Create(filePath1).Close();
            }

            if (!File.Exists(filePath2))
            {
                File.Create(filePath2).Close();
            }

            Console.WriteLine("Файлы успешно созданы в папке \"Answers\".");
        }
    }
}



