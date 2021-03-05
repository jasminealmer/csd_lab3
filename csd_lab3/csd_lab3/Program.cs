using System;

namespace csd_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = args[0];

            Parse parse = new Parse();
            string[] parsedInput = parse.ParseInput(input);

            parse.PlayGame(parsedInput);

            //input and output

        }
    }
}
