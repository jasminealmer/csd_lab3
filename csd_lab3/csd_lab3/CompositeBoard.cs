using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class CompositeBoard : IComponent
    {
        public List<IComponent> Children { get; set; }
        public string Winner { get; set; } 

        public string Id { get; set; }

        public List<IComponent> Collection { get; set; }

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
                    component = new CompositeBoard(component.Collection, stop);
                }
                else
                {
                    component = new CompositeBoard(component.Collection);
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
            IComponent composite = new CompositeBoard(leaf.Collection, id);
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

            //check winner horinzontally
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

            //check winner vertically
            else if (Children[0].Winner == Children[3].Winner && Children[3].Winner == Children[6].Winner)
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

            //check winner diagonally
            else if (Children[0].Winner == Children[4].Winner && Children[4].Winner == Children[8].Winner)
            {
                Winner = Children[0].Winner;
            }
            else if (Children[6].Winner == Children[4].Winner && Children[4].Winner == Children[2].Winner)
            {
                Winner = Children[6].Winner;
            }
            else
            {
                Winner = "No winner";
            }

        }
        public List<string> GetWinningLargeCells(IComponent tree)
        {
            List<string> result = new List<string>();

            foreach (IComponent child in tree.Children)
            {
                if (tree.Winner == child.Winner)
                {
                    result.Add(child.Id);
                }
            }

            return result;
        }

        List<string> winningCoord = new List<string>();
        public List<string> GetWinningSmallCells(IComponent tree)
        {
            foreach (IComponent child in tree.Children)
            {
                if (tree.Winner == child.Winner)
                {
                    winningCoord.Add("." + child.Id);
                    child.GetWinningSmallCells(child.Children);
                }
            }
            return winningCoord;
        }

       
    }
}
