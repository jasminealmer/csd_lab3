using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponentBoard
    {
        //public string[][] Leafboard { get; private set; }
        public string[] cells = { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
        public string Winner { get; private set; }

        public LeafBoard(string cell, string player)
        {

            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == cell)
                {
                    cells[i] = player;
                }
                else
                {
                    continue;
                }
            }

            Winner = DeterminateWinner();

            //string[] cell1 = new string[2] { "NW", null };
            //string[] cell2 = new string[2] { "NC", null };
            //string[] cell3 = new string[2] { "NE", null };
            //string[] cell4 = new string[2] { "CW", null };
            //string[] cell5 = new string[2] { "CC", null };
            //string[] cell6 = new string[2] { "CE", null };
            //string[] cell7 = new string[2] { "SW", null };
            //string[] cell8 = new string[2] { "SC", null };
            //string[] cell9 = new string[2] { "SE", null };

            //string[][] leafboard = new string[][] { cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9 };

            List<string> x = new List<string>();
            List<string> o = new List<string>();

            //Decides player for each move
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

            //gives each cell the correct value if played
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

        }

        private string DeterminateWinner()
        {
            //check winner horinzontally
            if (cells[0] == cells[1] && cells[1] == cells[2] && cells[0] != null)
            {
                return cells[0];
            }
            else if (cells[3] == cells[4] && cells[4] == cells[5] && cells[3] != null)
            {
                return cells[3];
            }
            else if (cells[6] == cells[7] && cells[7] == cells[8] && cells[6] != null)
            {
                return cells[6];
            }

            //check winner vertically
            else if (cells[0] == cells[3] && cells[3] == cells[6] && cells[0] != null)
            {
                return cells[0];
            }
            else if (cells[1] == cells[4] && cells[4] == cells[7] && cells[1] != null)
            {
                return cells[1];
            }
            else if (cells[2] == cells[5] && cells[5] == cells[8] && cells[2] != null)
            {
                return cells[2];
            }

            //check winner diagonally
            else if (cells[0] == cells[4] && cells[4] == cells[8] && cells[0] != null)
            {
                return cells[0];
            }
            else if (cells[6] == cells[4] && cells[4] == cells[2] && cells[6] != null)
            {
                return cells[6];
            }
            else
            {
                return null;
            }

        }

        public void MakeMove(string cell, string player)
        {

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
