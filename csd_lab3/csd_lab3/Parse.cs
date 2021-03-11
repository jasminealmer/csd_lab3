using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class Parse
    {
        //readonly List<string> x = new List<string>();
        //readonly List<string> o = new List<string>();
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

        //public string ParseOutput(LeafBoard leafboard)
        //{
            
        //}

    }
}
