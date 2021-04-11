using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class NullBoard : IComponent
    {
        public string Id { get; set; }
        public string Winner { get; set; }
        public int Layer { get; set; }
        public List<IComponent> Siblings { get; set; }
        public List<IComponent> Children { get; set; }

        public IComponent Copy(string id, int layer)
        {
            return new NullBoard();
        }

        public void DeterminateWinner()
        {

        }

        public void FillTree(IComponent tree, string[] moves)
        {

        }

        public List<IComponent> GetAllBoards(IComponent tree)
        {
            return new List<IComponent>();
        }

        public List<string> GetWinningLargeCells(IComponent tree)
        {
            return new List<string>();
        }

        public List<string> GetWinningSmallCells(IComponent tree)
        {
            return new List<string>();
        }

        public void MakeMove(string move)
        {

        }
    }
}
