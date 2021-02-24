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

        public string[] GenerateTree(string[] input)
        {
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

                    for (int i = 0; i < separatedCoordinates.Length; i++)
                    {
                        if (i == depth-1)
                        {
                            //create composite board with leaf boards!


                        }
                        else
                        {
                            //create composite board
                        }
                        if (item.StartsWith("NW"))
                        {

                            //create composite board
                        }
                    }

                    

                    for (int i = 0; i < separatedCoordinates.Length; i++)
                    {
                        if (separatedCoordinates[0] == "NW")
                        {

                        }
                        else if (separatedCoordinates[0] == "NC")
                        {

                        }
                    }

                }


                //detta är knas!!!!

                string[] coordinatesForLeafBoard;
                //go through all items: "NW.CC, CC.SE ..." for example
                foreach  (string item in input)
                {
                    //separate item "NW.CC" to "NW" and "CC"
                    string[] separatedCoordinates = item.Split(".");

                    //CC and NW (start with leafboard)
                    Array.Reverse(separatedCoordinates);

                    for (int i = 0; i < separatedCoordinates.Length; i++)
                    {
                        //CC
                        if (i == 0)
                        {
                            
                            //skapa leafboard med input CC
                        }
                        //NW
                        else
                        {

                        }
                    }

                }
                

                for (int i = 0; i < depth; i++)
                {

                }
            }
            else
            {
                return input;
            }

        }



        //public string ParseOutput(LeafBoard leafboard)
        //{
            
        //}

    }
}
