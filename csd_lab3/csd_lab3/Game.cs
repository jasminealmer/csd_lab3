using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace csd_lab3
{
    public class Game
    {
        readonly CompositeBoard composite = new CompositeBoard();
        readonly LeafBoard leaf = new LeafBoard();

        List<string> winningLargeCells = new List<string>();
        List<string> winningSmallCells = new List<string>();
        List<string> winsOfPlayers = new List<string>();
        public Dictionary<string, List<string>> PlayGame(string[] moves)
        {
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
            int depth = DecideDepth(moves[0]);
            IComponent tree = composite.GenerateTree(depth);
            string[] movesWithPlayer = AssignPlayers(moves);

            if (depth == 0)
            {
                leaf.FillTree(movesWithPlayer);
            }  

            else
            {
                composite.FillTree(tree, movesWithPlayer);
            }

            tree.DeterminateWinner();
            winningLargeCells = tree.GetWinningLargeCells(tree, movesWithPlayer);
            winningSmallCells = tree.GetWinningSmallCells(tree, movesWithPlayer);
            winsOfPlayers = GetWinsOfPlayers(tree, movesWithPlayer);

            results.Add("Winning Large Cells: ", winningLargeCells);
            results.Add("Winning Small Cells: ", winningSmallCells);
            return results;

        }
        private int DecideDepth(string firstCoord)
        {
            int depth = 0;
            //counts depth
            foreach (char character in firstCoord)
            {
                if (character == '.')
                {
                    depth++;
                }
                else
                {
                    continue;
                }
            }
            return depth;
        }

        //Assign players of the moves
        private string[] AssignPlayers(string[] moves)
        {

            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    moves[i] = moves[i].Insert(moves[i].Length, ".x");
                }
                else
                {
                    moves[i] = moves[i].Insert(moves[i].Length, ".o");
                }
            }
            return moves;
        }

        private List<string> GetWinsOfPlayers(IComponent tree, string[] moves)
        {
            List<string> result = new List<string>();
            string winsByX = "0";
            string winsByO = "0";

            if (tree.Winner == "x")
            {
                winsByX = "1";
            }
            else if (tree.Winner == "o")
            {
                winsByO = "1";
            }

            if (DecideDepth(moves[0]) == 0)
            {
                result.Add(winsByX);
                result.Add(winsByO);
            }
            else
            {
                int countX = 0;
                int countO = 0;

                foreach (IComponent child in tree.Children)
                {
                    if (child.Winner == "x")
                    {
                        count++;
                    }
                    else if (true)
                    {

                    }

                    winsByX += "." + 
                }
            }

            //decide for player X
            //Winner of BIG GAME
            //child.Winners = x


            //decide for player O
            //winner of big game
            //child.winners = o
        }

    }
}
