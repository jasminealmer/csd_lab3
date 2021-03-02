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

        readonly List<string> x = new List<string>();
        readonly List<string> o = new List<string>();

        //Assign players of the moves
        public void AssignPlayers(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    x.Add(moves[i]);
                }
                else
                {
                    o.Add(moves[i]);
                }
            }
        }

        public IComponentBoard GenerateTree(string[] input)
        {
            AssignPlayers(input);

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
                    string player;

                    if (x.Contains(item))
                    {
                        player = "x";
                    }
                    else if (o.Contains(item))
                    {
                        player = "o";
                    }



                    //separates to NW and CC
                    string[] separatedCoordinates = item.Split(".");

                    if (item.StartsWith("NW")) //den kommer komma in här fler gånger, hur ska den veta att ta den redan existerande NW?
                    {
                        IComponentBoard NWcomponent = null;
                        for (int i = separatedCoordinates.Length - 1; i > 0; i--)
                        {
                            if (i == separatedCoordinates.Length - 1)
                            {
                                NWcomponent = new LeafBoard(separatedCoordinates[i], player); //varför tar den inte emot player?
                            }
                            else
                            {
                                NWcomponent = new CompositeBoard(NWcomponent); //med leafboardet!!
                            }
                        }
                        return NWcomponent;
                    }
                    else if (item.StartsWith("NC"))
                    {
                        //samma kod
                    }

                    //fortsätt


                }
            }

            else
            {
                IComponentBoard leafboard = null;
                foreach (string item in input)
                {
                    string player;

                    if (x.Contains(item))
                    {
                        player = "x";
                    }
                    else if (o.Contains(item))
                    {
                        player = "o";
                    }

                    leafboard = new LeafBoard(item, player);
                }

            }

        }




        //public string ParseOutput(LeafBoard leafboard)
        //{
            
        //}

    }
}
