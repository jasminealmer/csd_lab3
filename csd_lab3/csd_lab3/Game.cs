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
                leaf.FillTree(tree, movesWithPlayer);
                tree.DeterminateWinner();
                winningLargeCells = leaf.GetWinningLargeCells(tree, movesWithPlayer);
                winningSmallCells = winningLargeCells;
                results.Add("Winning Large Cells: ", winningLargeCells);
                results.Add("Winning Small Cells: ", winningSmallCells);
                return results;
            }
            

            else
            {
                composite.FillTree(tree, movesWithPlayer);
                tree.DeterminateWinner();
                winningLargeCells = composite.GetWinningLargeCells(tree);
                //winningLargeCells = OrderResult(winningLargeCells, movesWithPlayer);
                winningSmallCells = composite.GetWinningSmallCells(tree);
                results.Add("Winning Large Cells: ", winningLargeCells);
                results.Add("Winning Small Cells: ", winningSmallCells);
                return results;
            }

        }

        //hur ska jag lägga in result i korrekt order på bästa sätt? hur ska jag kolla vilket bräde som avslutas "först"?
        private List<string> OrderResult(List<string> listToBeOrdered, string[] moves)
        {
            List<string> orderedList = new List<string>();

            foreach (string move in moves)
            {
                if (listToBeOrdered.Contains(move.Substring(0, 2)))
                {
                    orderedList.Add(move.Substring(0, 2));
                }
            }
            return orderedList;
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
        
    }
}
