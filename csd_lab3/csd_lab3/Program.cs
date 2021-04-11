using System;
using System.Collections.Generic;

namespace csd_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse parse = new Parse();
            Game game = new Game();

            if (args.Length < 1 || args.Length > 1)
            {
                Console.WriteLine("The input must be in one string");
            }
            else
            {
                string[] parsedInput = parse.ParseInput(args[0]);

                if (!parse.NoDuplicates(parsedInput))
                {
                    Console.WriteLine("The input contains duplicated moves, try again!");
                }

                if (!parse.ValidCharacters(parsedInput))
                {
                    Console.WriteLine("The input has other characters than the ones allowed");
                }

                if (!parse.EqualLength(parsedInput))
                {
                    Console.WriteLine("There is something wrong with the length of each move");
                }

                if (parse.EqualLength(parsedInput) && parse.ValidCharacters(parsedInput) && parse.NoDuplicates(parsedInput))
                {
                    Dictionary<string, List<string>> gameResults = new Dictionary<string, List<string>>();
                    gameResults = game.PlayGame(parsedInput);

                    Console.WriteLine("The game results are:");
                    Console.WriteLine(" ");

                    foreach (var result in gameResults)
                    {
                        string concatValues = string.Join(", ", result.Value.ToArray());
                        Console.WriteLine(result.Key + concatValues);
                        
                    }
                    Console.ReadKey();
                }

            }

           


        }
    }
}
