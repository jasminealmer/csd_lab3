using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    public class Parse
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

        public bool ValidCharacters(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[0].Contains("."))
                {
                    string[] splittedMoves = moves[i].Split(".");

                    for (int j = 0; j < splittedMoves.Length; j++)
                    {
                        if (splittedMoves[j] == "NW" || splittedMoves[j] == "NC" || splittedMoves[j] == "NE" || splittedMoves[j] == "CW" || splittedMoves[j] == "CC" || splittedMoves[j] == "CE" || splittedMoves[j] == "SW" || splittedMoves[j] == "SC" || splittedMoves[j] == "SE")
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (moves[i] == "NW" || moves[i] == "NC" || moves[i] == "NE" || moves[i] == "CW" || moves[i] == "CC" || moves[i] == "CE" || moves[i] == "SW" || moves[i] == "SC" || moves[i] == "SE")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EqualLength(string[] moves)
        {
            int length = moves[0].Length;

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i].Length != length)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
