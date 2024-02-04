using System.Text;

namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int n = 0;
        bool wordGuessed = false;
        int tries = 0;
        Random rand = new Random();
        string[] words = File.ReadAllLines(@"C:\Users\Admin\RiderProjects\Homeworks\Hangman\WordsStockRus.txt");
        int index = rand.Next(1, words.Length);
        string word = words[index];
        char[] wordArray = word.ToCharArray();
        char[] enteredCharArray = new char[word.Length];
        char[] charArray = new char[99999];
        while (!wordGuessed && tries < 10)
        {
            Console.WriteLine("Введите предпологаемый символ");
            char enteredChar;
            try
            {
                enteredChar = char.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }

            enteredChar = char.ToLower(enteredChar);
            Console.Clear();
            if (word.Contains(enteredChar) && !enteredCharArray.Contains(enteredChar) &&
                !charArray.Contains(enteredChar))
            {

                Console.WriteLine("Вы угадали букву");
                for (int i = 0; i < enteredCharArray.Length; i++)
                {
                    if (wordArray[i] == enteredChar)
                    {
                        enteredCharArray[i] = enteredChar;
                    }
                }

            }
            else if (enteredCharArray.Contains(enteredChar) || charArray.Contains(enteredChar))
            {
                Console.WriteLine("Вы уже вводили данную букву");
            }
            else
            {
                Console.WriteLine("Данной буквы нету в слове");
                tries++;
            }

            charArray[n++] = enteredChar;
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i] == enteredCharArray[i])
                {
                    Console.Write(enteredCharArray[i]);
                }
                else
                {
                    Console.Write("_");
                }
            }
            Console.WriteLine();
            if (enteredCharArray.SequenceEqual(wordArray))
            {
                Console.WriteLine("Вы отгадали слово");
                wordGuessed = true;
            }
        }

        if (!wordGuessed)
        {
            Console.WriteLine("Вы проиграли");
            Console.WriteLine($"Правильное слово {word}");
        }

        Console.ReadKey();
    }
} 