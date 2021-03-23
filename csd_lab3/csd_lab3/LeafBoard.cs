using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponent
    {
        public List<string> Cells { get; set; }

        public string Winner { get; set; }

        public string Id { get; set; }

        public List<IComponent> Collection { get; set; }
        public List<IComponent> Children { get; set; }

        //public LeafBoard(string cell, string player)
        //{
        //    MakeMove(cell, player);

        //    //vill endast setta denna när spelet är "klart" - hur göra detta?
        //    Winner = DeterminateWinner();
        //}

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

            Collection = new List<IComponent>();
            Collection.Add(this);
            Collection.Add(Copy("NC"));
            Collection.Add(Copy("NE"));
            Collection.Add(Copy("CW"));
            Collection.Add(Copy("CC"));
            Collection.Add(Copy("CE"));
            Collection.Add(Copy("SW"));
            Collection.Add(Copy("SC"));
            Collection.Add(Copy("SE"));

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
            List<string> result = new List<string>();

            if (tree.Id == "x")
            {
                foreach (string move in movesWithPlayer)
                {
                    if (move.EndsWith("x"))
                    {
                        result.Add(move.Remove(3));
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            else if (tree.Id == "o")
            {
                foreach (string move in movesWithPlayer)
                {
                    if (move.EndsWith("o"))
                    {
                        result.Add(move.Remove(3));
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return result;
        }

        public List<string> GetWinningSmallCells(IComponent tree)
        {
            List<string> lastCoord = new List<string>();

            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i] == "x" || Cells[i] == "o")
                {
                    int indexPos = Cells.IndexOf(Cells[i]);

                    if (indexPos == 0)
                    {
                        lastCoord.Add("NW");
                    }
                    if (indexPos == 1)
                    {
                        lastCoord.Add("NC");
                    }
                    if (indexPos == 2)
                    {
                        lastCoord.Add("NE");
                    }
                    if (indexPos == 3)
                    {
                        lastCoord.Add("CW");
                    }
                    if (indexPos == 4)
                    {
                        lastCoord.Add("CC");
                    }
                    if (indexPos == 5)
                    {
                        lastCoord.Add("CE");
                    }
                    if (indexPos == 6)
                    {
                        lastCoord.Add("SW");
                    }
                    if (indexPos == 7)
                    {
                        lastCoord.Add("SC");
                    }
                    if (indexPos == 8)
                    {
                        lastCoord.Add("SE");
                    }

                }
                else
                {
                    continue;
                }
            }
            return lastCoord;
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
            }
            else if (Cells[3] == Cells[4] && Cells[4] == Cells[5])
            {
                Winner = Cells[3];
            }
            else if (Cells[6] == Cells[7] && Cells[7] == Cells[8])
            {
                Winner = Cells[6];
            }
        }

        private void CheckWinnerVertically()
        {
            if (Cells[0] == Cells[3] && Cells[3] == Cells[6])
            {
                Winner = Cells[0];
            }
            else if (Cells[1] == Cells[4] && Cells[4] == Cells[7])
            {
                Winner = Cells[1];
            }
            else if (Cells[2] == Cells[5] && Cells[5] == Cells[8])
            {
                Winner = Cells[2];
            }
        }

        private void CheckWinnerDiagonally()
        {
            if (Cells[0] == Cells[4] && Cells[4] == Cells[8])
            {
                Winner = Cells[0];
            }
            else if (Cells[6] == Cells[4] && Cells[4] == Cells[2])
            {
                Winner = Cells[6];
            }
        }



    }
}
