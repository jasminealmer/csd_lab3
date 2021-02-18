using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponentBoard
    {
        //create leaf board
        //put in input values X and O moves

        //deklarera leafboard
        public string[][] Leafboard { get; private set; }
        public string Winner { get; private set; }

        public LeafBoard(string[] moves)
        {
            string[] cell1 = new string[2] { "NW", null };
            string[] cell2 = new string[2] { "NC", null };
            string[] cell3 = new string[2] { "NE", null };
            string[] cell4 = new string[2] { "CW", null };
            string[] cell5 = new string[2] { "CC", null };
            string[] cell6 = new string[2] { "CE", null };
            string[] cell7 = new string[2] { "SW", null };
            string[] cell8 = new string[2] { "SC", null };
            string[] cell9 = new string[2] { "SE", null };

            string[][] leafboard = new string[][] { cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9 };

            List<string> x = new List<string>();
            List<string> o = new List<string>();

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

            foreach (string[] cell in leafboard)
            {
                foreach (string move in x)
                {
                    if (move == cell[0])
                    {
                        cell[1] = "x";
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (string move in o)
                {
                    if (move == cell[0])
                    {
                        cell[1] = "o";
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Leafboard = leafboard;
            Winner = DeterminateWinner();
        }

        private string DeterminateWinner()
        {
            //check winner horinzontally
            if (Leafboard[0][1] == Leafboard[1][1] && Leafboard[1][1] == Leafboard[2][1] && Leafboard[0][1] != null)
            {
                return Leafboard[0][1];
            }
            else if (Leafboard[3][1] == Leafboard[4][1] && Leafboard[4][1] == Leafboard[5][1] && Leafboard[3][1] != null)
            {
                return Leafboard[3][1];
            }
            else if (Leafboard[6][1] == Leafboard[7][1] && Leafboard[7][1] == Leafboard[8][1] && Leafboard[6][1] != null)
            {
                return Leafboard[6][1];
            }

            //check winner vertically
            else if (Leafboard[0][1] == Leafboard[3][1] && Leafboard[3][1] == Leafboard[6][1] && Leafboard[0][1] != null)
            {
                return Leafboard[0][1];
            }
            else if (Leafboard[1][1] == Leafboard[4][1] && Leafboard[4][1] == Leafboard[7][1] && Leafboard[1][1] != null)
            {
                return Leafboard[1][1];
            }
            else if (Leafboard[2][1] == Leafboard[5][1] && Leafboard[5][1] == Leafboard[8][1] && Leafboard[2][1] != null)
            {
                return Leafboard[2][1];
            }

            //check winner diagonally
            else if (Leafboard[0][1] == Leafboard[4][1] && Leafboard[4][1] == Leafboard[8][1] && Leafboard[0][1] != null)
            {
                return Leafboard[0][1];
            }
            else if (Leafboard[6][1] == Leafboard[4][1] && Leafboard[4][1] == Leafboard[2][1] && Leafboard[6][1] != null)
            {
                return Leafboard[6][1];
            }
            else
            {
                return "No winner determined.";
            }

        }

        //public string LeafboardToString(string[][] leafboard)
        //{

        //}
        //public void CreateLeafBoard(string[] moves)
        //{

        //}

        //public string PlayGame()
        //{
        //    //returnera cellens värde
        //    return move; 
        //}

    }
}
