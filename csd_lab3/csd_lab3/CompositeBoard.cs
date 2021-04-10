using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace csd_lab3
{
    class CompositeBoard : IComponent
    {
        public List<IComponent> Children { get; set; }
        public string Winner { get; set; } 
        public int Layer { get; set; }

        public string Id { get; set; }

        public List<IComponent> Siblings { get; set; }

        public CompositeBoard()
        {

        }

        public CompositeBoard(List<IComponent> children, int layer)
        {
            Children = children;
            Id = "NW";
            Layer = layer;

            Siblings = new List<IComponent>();
            Siblings.Add(this);
            Siblings.Add(Copy("NC", Layer));
            Siblings.Add(Copy("NE", Layer));
            Siblings.Add(Copy("CW", Layer));
            Siblings.Add(Copy("CC", Layer));
            Siblings.Add(Copy("CE", Layer));
            Siblings.Add(Copy("SW", Layer));
            Siblings.Add(Copy("SC", Layer));
            Siblings.Add(Copy("SE", Layer));
        }

        public CompositeBoard(List<IComponent> children) 
        {
            Children = children;
            //last component
        }

        public CompositeBoard(List<IComponent> children, string id, int layer)
        {
            Children = children;
            Id = id;
            Layer = layer;
        }
        public IComponent GenerateTree(int depth)
        {
            IComponent component = null;
            for (int i = depth; i >= 0; i--)
            {
                if (i == depth)
                {
                    component = new LeafBoard(i);
                }
                else if (i == 0)
                {
                    component = new CompositeBoard(component.Siblings);
                }
                else
                {
                    component = new CompositeBoard(component.Siblings, i);
                }
            }
            return component;

        }
        public void FillTree(IComponent tree, string[] moves)
        {
            if (tree != null)
            {
                foreach (var child in tree.Children)
                {
                    foreach (string move in moves)
                    {
                        string firstCoordinate = move.Substring(0, 2);

                        if (firstCoordinate == child.Id)
                        {
                            child.MakeMove(move.Substring(3));
                        }
                        else
                        {
                            continue;
                        }
                    }

                }

            }

        }
       
        public IComponent Copy(string id, int layer)
        {
            IComponent leaf = new LeafBoard(layer +1);
            IComponent composite = new CompositeBoard(leaf.Siblings, id, layer);
            return composite;
        }

        public void MakeMove(string move)
        {
            bool found = false;
            foreach (IComponent child in Children)
            {
                if (found)
                {
                    break;
                }
                string firstCoordinate = move.Substring(0, 2);

                if (firstCoordinate == child.Id)
                {
                    child.MakeMove(move.Substring(3));
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
            foreach (IComponent child in Children)
            {
                child.DeterminateWinner();
            }

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
            if (Children[0].Winner == Children[1].Winner && Children[1].Winner == Children[2].Winner)
            {
                Winner = Children[0].Winner;
            }
            else if (Children[3].Winner == Children[4].Winner && Children[4].Winner == Children[5].Winner)
            {
                Winner = Children[3].Winner;
            }
            else if (Children[6].Winner == Children[7].Winner && Children[7].Winner == Children[8].Winner)
            {
                Winner = Children[6].Winner;
            }
        }

        private void CheckWinnerVertically()
        {
            if (Children[0].Winner == Children[3].Winner && Children[3].Winner == Children[6].Winner)
            {
                Winner = Children[0].Winner;
            }
            else if (Children[1].Winner == Children[4].Winner && Children[4].Winner == Children[7].Winner)
            {
                Winner = Children[1].Winner;
            }
            else if (Children[2].Winner == Children[5].Winner && Children[5].Winner == Children[8].Winner)
            {
                Winner = Children[2].Winner;
            }

        }

        private void CheckWinnerDiagonally()
        {
            if (Children[0].Winner == Children[4].Winner && Children[4].Winner == Children[8].Winner)
            {
                Winner = Children[0].Winner;
            }
            else if (Children[6].Winner == Children[4].Winner && Children[4].Winner == Children[2].Winner)
            {
                Winner = Children[6].Winner;
            }
        }
        public List<string> GetWinningLargeCells(IComponent tree)
        {
            List<string> result = new List<string>();

            foreach (string cell in GetWinningSmallCells(tree))
            {
                string largeCell = cell.Substring(0, 2);
                result.Add(largeCell);
            }

            result = result.Distinct().ToList();
            return result;
        }

        public List<string> GetWinningSmallCells(IComponent tree)
        {
            List<string> result = new List<string>();

            foreach (IComponent child in tree.Children)
            {
                if (tree.Winner == child.Winner)
                {
                    List<string> smallCells = new List<string>();
                    smallCells.AddRange(child.GetWinningSmallCells(child));

                    for (int i = 0; i < smallCells.Count; i++)
                    {
                        result.Add(child.Id + "." + smallCells[i]);
                    }

                }
            }

            return result;
           
        }

        public List<IComponent> GetAllBoards(IComponent tree)
        {
            List<IComponent> result = new List<IComponent>();

            result.Add(tree);
            foreach (IComponent board in tree.Children)
            {
                result.AddRange(board.GetAllBoards(board));
            }

            return result;

        }
       
    }
}
