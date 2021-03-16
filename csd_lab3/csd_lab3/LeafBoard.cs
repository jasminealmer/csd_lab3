using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponent
    {
        public List<string> Cells { get; set; }
       
        public string Winner { get; private set; }

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
            Winner = "No winner.";

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
            Winner = "No winner";
        }

        //public void SetId(string id)
        //{
        //    Id = id;
        //}

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
            //Id = DeterminateWinner();
        }

        public void DeterminateWinner()
        {
            //check winner horinzontally
            if (Cells[0] == Cells[1] && Cells[1] == Cells[2] && Cells[0] != null)
            {
                Winner = Cells[0];
            }
            else if (Cells[3] == Cells[4] && Cells[4] == Cells[5] && Cells[3] != null)
            {
                Winner = Cells[3];
            }
            else if (Cells[6] == Cells[7] && Cells[7] == Cells[8] && Cells[6] != null)
            {
                Winner = Cells[6];
            }

            //check winner vertically
            else if (Cells[0] == Cells[3] && Cells[3] == Cells[6] && Cells[0] != null)
            {
                Winner = Cells[0];
            }
            else if (Cells[1] == Cells[4] && Cells[4] == Cells[7] && Cells[1] != null)
            {
                Winner = Cells[1];
            }
            else if (Cells[2] == Cells[5] && Cells[5] == Cells[8] && Cells[2] != null)
            {
                Winner = Cells[2];
            }

            //check winner diagonally
            else if (Cells[0] == Cells[4] && Cells[4] == Cells[8] && Cells[0] != null)
            {
                Winner = Cells[0];
            }
            else if (Cells[6] == Cells[4] && Cells[4] == Cells[2] && Cells[6] != null)
            {
                Winner = Cells[6];
            }
            Id = Winner;

        }


    }
}
