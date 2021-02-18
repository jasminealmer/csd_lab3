using System;

namespace csd_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = args[0];

            Parse parse = new Parse();
            string[] output = parse.ParseInput(input);

            LeafBoard leafboard = new LeafBoard(output);

            Console.WriteLine(leafboard.Winner);

            //input and output

        }
    }
}
