using System;
using System.Collections.Generic;
using System.Linq;

namespace Wordle
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = { "fixed", "screw", "board", "hoard", "chord", "toque", "shovel", "squirtle", "memes", "meme", "cheese", "burger", "sword" };

            Console.WriteLine("\u001b[31;1m\x1B[4mWordle.\x1b[0m");

            var word = words[new Random().Next(0, words.Length)];
            var win = false;
            SortedSet<char> guessedLetters = new SortedSet<char>();
            var blanked = "";

            // https://www.jerriepelser.com/blog/using-ansi-color-codes-in-net-console-apps/

            for (int i = 0; i < word.Length; i++)
            {
                blanked += "\u001b[37;1m\x1B[4m  \x1b[0m ";
            }

            Console.WriteLine(blanked);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"\u001b[37;1m\x1B[4mGAME START -- YOU HAVE {word.Length} ATTEMPTS \x1b[0m");
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 1; i < word.Length; i++)
            {
                var guess = Console.ReadLine();

                if(guess.Length < word.Length)
                {
                    guess += "                                  ";
                }

                guess = guess.Substring(0, word.Length);

                var guessArray = guess.ToUpper().ToCharArray();
                var wordArray = word.ToUpper().ToCharArray();
                int[] resultArray = new int[word.Length];
                var response = "";
                var success = true;

                for(int j = 0; j < word.Length; j++)
                {
                    guessedLetters.Add(guessArray[j]);
                    if (guessArray[j] == wordArray[j])
                    {
                        response += "\u001b[32;1m\x1B[4m" + guessArray[j] + "\x1b[0m"; 
                    }
                    else if (Array.Exists(wordArray, element => element == guessArray[j])) 
                    {
                        response += "\u001b[33;1m\x1B[4m" + guessArray[j] + "\x1b[0m";
                        success = false;
                    } else
                    {
                        response += "\u001b[37;1m\x1B[4m" + guessArray[j] + "\x1b[0m";
                        success = false;
                    }
                }
                if(success)
                {
                    win = true;
                    break;
                }
                response += "            USED LETTERS: ";
                foreach(char c in guessedLetters)
                {
                    response += "\u001b[37;1m" + c + "\x1b[0m ";
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(response);
            }

            if(win)
            {
                for(int i = 0; i < 50; i++)
                {
                    Console.WriteLine("\u001b[36;1mWINNER (GAGNANT)\x1b[0m");
                }
            } 
            else
            {
                Console.WriteLine("Ur trash");
            }

            Console.ReadLine();
        }
    }
}
