using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafBoard : IComponent
    {
        public List<string> cells { get; set; }
       
        public string Winner { get; private set; }

        public string Id { get; set; }
        //public LeafBoard(string cell, string player)
        //{
        //    MakeMove(cell, player);

        //    //vill endast setta denna när spelet är "klart" - hur göra detta?
        //    Winner = DeterminateWinner();
        //}

        public LeafBoard()
        {
            cells = new List<string>();
            cells.Add("NW");
            cells.Add("NC");
            cells.Add("NE");
            cells.Add("CW");
            cells.Add("CC");
            cells.Add("CE");
            cells.Add("SW");
            cells.Add("SC");
            cells.Add("SE");

            Winner = "No winner";
        }

        public List<IComponent> GetChildren()
        {
            return null;
        }

        public void SetId(string id)
        {
            Id = id;
        }

        public IComponent Copy()
        {
            IComponent anotherOne = (IComponent)this.MemberwiseClone();
            return anotherOne;
        }

        public void MakeMove(string move)
        {
            string[] coordAndPlayer = move.Split('.');
            string coord = coordAndPlayer[0];
            string player = coordAndPlayer[1];
            
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i] == coord)
                {
                    cells[i] = player;
                }
                else
                {
                    continue;
                }

            }
            Id = DeterminateWinner();
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
                return "No winner";
            }

        }


    }
}
