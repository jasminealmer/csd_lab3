using System;

namespace csd_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = args[0];

            Parse parse = new Parse();
            Game game = new Game();

            string[] parsedInput = parse.ParseInput(input);

            game.PlayGame(parsedInput);

            //input and output

        }
    }
}
