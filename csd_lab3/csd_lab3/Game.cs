using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    public class Game
    {
        public int checkDepth = 0;
        readonly CompositeBoard composite = new CompositeBoard();
        readonly LeafBoard leaf = new LeafBoard();
        public void PlayGame(string[] moves)
        {
            int depth = DecideDepth(moves[0]);
            checkDepth = depth;
            IComponent tree = composite.GenerateTree(depth);
            string[] movesWithPlayer = AssignPlayers(moves);

            if (depth == 0)
            {
                leaf.FillTree(tree, movesWithPlayer);
            }
            else
            {
                composite.FillTree(tree, movesWithPlayer);
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
