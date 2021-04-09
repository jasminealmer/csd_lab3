using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponent
    {
        public List<string> Cells { get; set; }

        public string Winner { get; set; }
        private List<int> winningCells { get; set; }

        public string Id { get; set; }

        public List<IComponent> Siblings { get; set; }
        public List<IComponent> Children { get; set; }


        public LeafBoard()
        {
            Cells = new List<string>();
            Cells.Add("NW");
            Cells.Add("NC");
            Cells.Add("NE");
            Cells.Add("CW");
            Cells.Add("CC");
            Cells.Add("CE");
            Cells.Add("SW");
            Cells.Add("SC");
            Cells.Add("SE");
            Id = "NW";

            Siblings = new List<IComponent>();
            Siblings.Add(this);
            Siblings.Add(Copy("NC"));
            Siblings.Add(Copy("NE"));
            Siblings.Add(Copy("CW"));
            Siblings.Add(Copy("CC"));
            Siblings.Add(Copy("CE"));
            Siblings.Add(Copy("SW"));
            Siblings.Add(Copy("SC"));
            Siblings.Add(Copy("SE"));

        }

        public LeafBoard(string id)
        {
            Cells = new List<string>();
            Cells.Add("NW");
            Cells.Add("NC");
            Cells.Add("NE");
            Cells.Add("CW");
            Cells.Add("CC");
            Cells.Add("CE");
            Cells.Add("SW");
            Cells.Add("SC");
            Cells.Add("SE");
            Id = id;
        }

        public List<string> GetWinningLargeCells(IComponent tree, string[] movesWithPlayer)
        {
            return GetWinningSmallCells(tree);
        }
        
        public List<string> GetWinningSmallCells(IComponent tree)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < Cells.Count; i++)
            {
                int indexPos = i;

                if (Cells[i] == tree.Winner && winningCells.Contains(i))
                {
                    if (indexPos == 0)
                    {
                        result.Add("NW");
                    }
                    else if (indexPos == 1)
                    {
                        result.Add("NC");
                    }
                    else if (indexPos == 2)
                    {
                        result.Add("NE");
                    }
                    else if (indexPos == 3)
                    {
                        result.Add("CW");
                    }
                    else if (indexPos == 4)
                    {
                        result.Add("CC");
                    }
                    else if (indexPos == 5)
                    {
                        result.Add("CE");
                    }
                    else if (indexPos == 6)
                    {
                        result.Add("SW");
                    }
                    else if (indexPos == 7)
                    {
                        result.Add("SC");
                    }
                    else if (indexPos == 8)
                    {
                        result.Add("SE");
                    }

                }
                else
                {
                    continue;
                }

            }

            return result;
        }

        public List<string> GetWinsOfPlayers(IComponent tree, string[] moves)
        {
            List<string> result = new List<string>();

            if (tree.Winner == "x")
            {
                result.Add("x");
            }
            else if (tree.Winner == "o")
            {
                result.Add("o");
            }

            return result;
        }

        public void FillTree(IComponent tree, string[] moves)
        {
            foreach (string move in moves)
            {
                MakeMove(move);
            }
        }
        public IComponent Copy(string id)
        {
            IComponent component = new LeafBoard(id);
            return component;
        }

        public void MakeMove(string move)
        {
            string[] coordAndPlayer = move.Split('.');
            string coord = coordAndPlayer[0];
            string player = coordAndPlayer[1];
            bool found = false;
            
            for (int i = 0; i < Cells.Count; i++)
            {
                if (found)
                {
                    break;
                }
                if (Cells[i] == coord)
                {
                    Cells[i] = player;
                    found = true;
                }
                else
                {
                    continue;
                }

            }
        }

        public void DeterminateWinner()
        {
            winningCells = new List<int>();

            CheckWinnerHorizontally();
            CheckWinnerVertically();
            CheckWinnerDiagonally();

            if (Winner == null)
            {
                Winner = "No winner";
            }

        }

        private void CheckWinnerHorizontally()
        {
            if (Cells[0] == Cells[1] && Cells[1] == Cells[2])
            {
                Winner = Cells[0];
                winningCells.Add(0);
                winningCells.Add(1);
                winningCells.Add(2);

            }
            else if (Cells[3] == Cells[4] && Cells[4] == Cells[5])
            {
                Winner = Cells[3];
                winningCells.Add(3);
                winningCells.Add(4);
                winningCells.Add(5);
            }
            else if (Cells[6] == Cells[7] && Cells[7] == Cells[8])
            {
                Winner = Cells[6];
                winningCells.Add(6);
                winningCells.Add(7);
                winningCells.Add(8);
            }
        }

        private void CheckWinnerVertically()
        {
            if (Cells[0] == Cells[3] && Cells[3] == Cells[6])
            {
                Winner = Cells[0];
                winningCells.Add(0);
                winningCells.Add(3);
                winningCells.Add(6);
            }
            else if (Cells[1] == Cells[4] && Cells[4] == Cells[7])
            {
                Winner = Cells[1];
                winningCells.Add(1);
                winningCells.Add(4);
                winningCells.Add(7);
            }
            else if (Cells[2] == Cells[5] && Cells[5] == Cells[8])
            {
                Winner = Cells[2];
                winningCells.Add(2);
                winningCells.Add(5);
                winningCells.Add(8);
            }
        }

        private void CheckWinnerDiagonally()
        {
            if (Cells[0] == Cells[4] && Cells[4] == Cells[8])
            {
                Winner = Cells[0];
                winningCells.Add(0);
                winningCells.Add(4);
                winningCells.Add(8);
            }
            else if (Cells[6] == Cells[4] && Cells[4] == Cells[2])
            {
                Winner = Cells[6];
                winningCells.Add(6);
                winningCells.Add(4);
                winningCells.Add(2);
            }
        }



    }
}
