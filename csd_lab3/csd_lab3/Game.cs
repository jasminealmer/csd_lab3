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
        public List<string> PlayGame(string[] moves)
        {
            int depth = DecideDepth(moves[0]);
            IComponent tree = composite.GenerateTree(depth);
            string[] movesWithPlayer = AssignPlayers(moves);
            List<string> result = new List<string>();

            if (depth == 0)
            {
                leaf.FillTree(tree, movesWithPlayer);
                tree.DeterminateWinner();
                //Console.WriteLine(tree.Id);

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
            

            else
            {
                composite.FillTree(tree, movesWithPlayer);
                tree.DeterminateWinner();

                foreach (IComponent child in tree.Children)
                {
                    if (tree.Winner == child.Winner)
                    {
                        result.Add(child.Id);
                    }

                }
                return result;
               
            }

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
