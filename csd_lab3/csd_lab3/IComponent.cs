using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponent
    {
        public string Id { get; set; }
        public string Winner { get; set; }
        public int Layer { get; set; }
        public List<IComponent> Siblings { get; set; }
        public List<IComponent> Children { get; set; }
        public void MakeMove(string move);
        public void DeterminateWinner();
        public List<IComponent> GetAllBoards(IComponent tree);
        public List<string> GetWinningLargeCells(IComponent tree);
        public List<string> GetWinningSmallCells(IComponent tree);
        public void FillTree(IComponent tree, string[] moves);

    }
}
