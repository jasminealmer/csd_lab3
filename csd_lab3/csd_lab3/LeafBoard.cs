using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponentBoard
    {

        public string[] cells = { "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE" };
        public string Winner { get; private set; }

        public LeafBoard(string cell, string player)
        {
            MakeMove(cell, player);
            Winner = DeterminateWinner();
        }

        public void MakeMove(string cell, string player)
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
        }

        public string DeterminateWinner()
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


    }
}
