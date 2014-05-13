using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TriviaGame
{
    class Program
    {
        static int correct = 0;
        static int incorrect = 0;
        static bool geography = false;
        static bool movies = false;
        static bool food = false;
        static bool tvshows = false;
        static bool misc = false;
        static bool trivia = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to trivia! What's your name?");
            string name = Console.ReadLine().ToString();
            Console.WriteLine("Welcome " + name + "!");
            Thread.Sleep(2500);
            catagorize();
            GetTriviaList();
            Console.ReadKey();

        }
        
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = new List<string>() { };
            if (geography)
            {
                contents = File.ReadAllText("geography.txt").Replace("\r", "").Split('\n').ToList();
            }
            else if (movies)
            {
                contents = File.ReadAllText("movies.txt").Replace("\r", "").Split('\n').ToList();
            }
            else if (food)
            {
                contents = File.ReadAllText("food.txt").Replace("\r", "").Split('\n').ToList();
            }
            else if (tvshows)
            {
                contents = File.ReadAllText("tvshows.txt").Replace("\r", "").Split('\n').ToList();
            }
            else if (misc)
            {
                contents = File.ReadAllText("misc.txt").Replace("\r", "").Split('\n').ToList();
            }
            else if (trivia)
            {
                contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            }
 
            var random = new Random();
            var randQuestion = random.Next(0, contents.Count);
            var triviaQuestion = contents[randQuestion];
            var tQuestion = triviaQuestion.Split('*');

            Console.WriteLine(tQuestion[0]);
            var userInput = "";
            var continueT = "";
            var playAgain = "";
            while(correct < 10 && incorrect < 10)
            {
                Console.WriteLine("Enter a guess now, if you want to move on type pass");
                Console.WriteLine();
                Console.WriteLine("Correct: " + correct);
                Console.WriteLine("Incorrect: " + incorrect);
                userInput = Console.ReadLine().ToLower();
                if (userInput.ToLower() == "pass" || userInput.ToLower() == "next" || userInput.ToLower() == "skip")
                {
                    Console.Clear();
                    pass();
                }
                else if (userInput.ToLower() != tQuestion[1].ToLower())
                {
                    Console.WriteLine("Sorry thats not the write answer, try again");
                    incorrect++;
                }
                else
                {
                    Console.WriteLine("Yes that is the answer! For the next question type next");
                    correct++;
                    continueT = Console.ReadLine().ToLower();
                    if (continueT.ToLower() == "next")
                    {
                        Console.Clear();
                        pass();
                    }
                    else 
                    {
                        Console.Clear();
                        pass();
                    }
                }
            }
            if (correct == 10)
            {
                Console.WriteLine("You win! would you like to play again? Yes or No");
                playAgain = Console.ReadLine().ToLower();
                if (playAgain.ToLower() == "yes")
                {
                    Console.Clear();
                    GetTriviaList();
                    correct = 0;
                    incorrect = 0;
                }
            }
            else 
            {
                Console.WriteLine("You lose! would you like to play again? Yes or No");
                playAgain = Console.ReadLine().ToLower();
                if (playAgain.ToLower() == "yes")
                {
                    Console.Clear();
                    GetTriviaList();
                    correct = 0;
                    incorrect = 0;
                }
            }
            //Each item in list "contents" is now one line of the Trivia.txt document.
            return new List<Trivia>();
        }
        static void pass()
        {
            GetTriviaList();
        }
        static void catagorize()
        {
            Console.Clear();
            Console.WriteLine("Please select a catagory to play:");
            Console.WriteLine("1. Geography");
            Console.WriteLine("2. Movies");
            Console.WriteLine("3. Food");
            Console.WriteLine("4. TV Shows");
            Console.WriteLine("5. Misc.");
            Console.WriteLine("6. Lame Trivia");
            string catagory = Console.ReadLine().ToString().ToLower();
            if(catagory == "geography" || catagory == "1")
            {
                geography = true;
                pass();
            }
            else if (catagory == "movies" || catagory == "2") 
            {
                movies = true;
                pass();
            }
            else if (catagory == "food" || catagory == "3") 
            {
                food = true;
                pass();
            }
            else if (catagory == "tv shows" || catagory == "4")
            {
                tvshows = true;
                pass();
            }
            else if (catagory == "misc" || catagory == "5")
            {
                misc = true;
                pass();
            }
            else if (catagory == "lame trivia" || catagory == "trivia" || catagory == "6")
            {
                trivia = true;
                pass();
            }
            else
            {
                catagorize();
            }

        }
    }
}
