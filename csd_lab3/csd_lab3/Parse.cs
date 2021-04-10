using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class Parse
    {

        public string[] ParseInput(string input)
        {
            string withoutSpaces = RemoveWhiteSpaces(input);
            string[] parsedInput = SplitInput(withoutSpaces);
            return parsedInput;
        }

        private string RemoveWhiteSpaces(string input)
        {

            if (input.Contains(" "))
            {
                input = input.Replace(" ", "");
            }
            return input;
        }
        private string[] SplitInput(string input)
        {
            string[] splittedInput = input.Split(",");
            return splittedInput;
        }
        public bool NoDuplicates(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                for (int j = i + 1; j < moves.Length; j++)
                {
                    if (moves[i] == moves[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //public string ParseOutput(LeafBoard leafboard)
        //{

        //}

    }
}
