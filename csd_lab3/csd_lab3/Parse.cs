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

        //Assign players of the moves
        public List<List<string>> AssignPlayer(string[] moves)
        {

        }

        public string[] GenerateTree(string[] input)
        {

            //List<string> x = AssignPlayer(input).ElementAt(0);

            List<string> x = new List<string>();
            List<string> o = new List<string>();

            //Decides player for each move
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    x.Add(input[i]);
                }
                else
                {
                    o.Add(input[i]);
                }
            }

            int depth = 0;
            string firstLevel = input[0];

            //counts depth
            foreach (char character in firstLevel)
            {
                while (character == '.')
                {
                    depth++;
                }
            }

            if (depth > 0)
            {
                //go through all items: "NW.CC, CC.SE ..." for example
                foreach (string item in input)
                {
                    //separates to NW and CC
                    string[] separatedCoordinates = item.Split(".");

                    if (item.StartsWith("NW"))
                    {
                        IComponentBoard NWcomponent = null;
                        for (int i = separatedCoordinates.Length - 1; i > 0; i--)
                        {
                            if (i == separatedCoordinates.Length - 1)
                            {
                                NWcomponent = new LeafBoard(separatedCoordinates[i], player);
                            }
                            else
                            {
                                NWcomponent = new CompositeBoard(NWcomponent); //med leafboardet!!
                            }
                        }
                        //return component;
                    }
                    else if (item.StartsWith("NC"))
                    {
                        //samma kod
                    }




                }



            }   

        }




        //public string ParseOutput(LeafBoard leafboard)
        //{
            
        //}

    }
}
