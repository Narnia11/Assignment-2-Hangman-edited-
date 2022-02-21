using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] wordList = new string[5] { "red", "blue", "brown", "orange", "crimson" };


            Random random = new Random((int)DateTime.Now.Ticks);

            string wordToGuess = wordList[random.Next(0, wordList.Length)];




            StringBuilder revealedLetters = new StringBuilder(wordToGuess.Length);

            for (int i = 0; i < wordToGuess.Length; i++)


                revealedLetters.Append('-');


            List<char> correctGuess = new List<char>();


            List<char> incorrectGuess = new List<char>();


            int lives = 10;


            bool won = false;


            int numbOfLettersRevealed = 0;

            string userInput;
            char guess;
            while (!won && lives > 0)

            {

                Console.Write("Enter your guess: ");
                userInput = Console.ReadLine();
                guess = userInput[0];




                if (String.Equals(wordToGuess , userInput))
                {
                    Console.WriteLine("Good job! You guessed the whole word! ");
                    Console.ReadLine();
                }

                else
                {


                    if (correctGuess.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                        continue;
                    }

                    else if (incorrectGuess.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        continue;
                    }
                    if (wordToGuess.Contains(guess))
                    {
                        correctGuess.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuess[i] == guess)
                            {
                                revealedLetters[i] = wordToGuess[i];
                                numbOfLettersRevealed++;
                            }

                        }
                        if (numbOfLettersRevealed == wordToGuess.Length)
                            won = true;
                    }
                    else
                    {
                        incorrectGuess.Add(guess);


                        Console.WriteLine("Sorry, there's no '{0}' in this word!", guess);
                        lives--;
                    }
                    Console.WriteLine(revealedLetters.ToString());
                }
            }

            if (won)

                Console.WriteLine("Congratulations, you won!");
            else

                Console.WriteLine("You lost! it was '{0}'", wordToGuess);

            Console.ReadLine();
        }
    }
}