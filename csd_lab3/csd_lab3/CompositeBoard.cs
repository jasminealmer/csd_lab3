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

        public string Id { get; set; }

        public List<IComponent> Siblings { get; set; }

        public CompositeBoard()
        {

        }

        public CompositeBoard(List<IComponent> children, int last)
        {
            Children = children;
            //sista component
        }

        public CompositeBoard(List<IComponent> children) 
        {
            Children = children;
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

        public CompositeBoard(List<IComponent> children, string id)
        {
            Children = children;
            Id = id;
        }
        public IComponent GenerateTree(int depth)
        {
            IComponent component = null;
            int stop = 0;
            for (int i = depth; i >= 0; i--)
            {
                if (i == depth)
                {
                    component = new LeafBoard();
                }
                else if (i == 0)
                {
                    component = new CompositeBoard(component.Siblings, stop);
                }
                else
                {
                    component = new CompositeBoard(component.Siblings);
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
       
        public IComponent Copy(string id)
        {
            IComponent leaf = new LeafBoard();
            IComponent composite = new CompositeBoard(leaf.Siblings, id);
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
        public List<string> GetWinningLargeCells(IComponent tree, string[] moves)
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

        public List<string> GetWinsOfPlayers(IComponent tree, string[] moves)
        {
            int treeWinner = 1;
            int treeLooser = 0;

            List<string> layerWins = new List<string>();
            List<string> result = new List<string>();

            foreach (IComponent child in tree.Children)
            {
                layerWins.AddRange(child.GetWinsOfPlayers(child, moves));
            }

            int countX = 0;
            int countO = 0;

            foreach (string winner in layerWins)
            {
                if (winner == "x")
                {
                    countX++;
                }
                else
                {
                    countO++;
                }

            }

            string movesOfX = string.Empty;
            string movesOfO = string.Empty;

            if (tree.Winner == "x")
            {
                movesOfX = treeWinner.ToString() + "." + countX.ToString();
                movesOfO = treeLooser.ToString() + "." + countO.ToString();
            }
            else if (tree.Winner == "o")
            {
                movesOfO = treeWinner.ToString() + "." + countO.ToString();
                movesOfX = treeLooser.ToString() + "." + countX.ToString();
            }

            result.Add(movesOfX);
            result.Add(movesOfO);
            return result;

        }

       

       
    }
}
