﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace csd_lab3
{
    public class Game
    {
        readonly CompositeBoard composite = new CompositeBoard();

        List<string> winningLargeCells = new List<string>();
        List<string> winningSmallCells = new List<string>();
        List<string> winsOfPlayers = new List<string>();
        public Dictionary<string, List<string>> PlayGame(string[] moves)
        {
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
            int depth = DecideDepth(moves[0]);
            IComponent tree = composite.GenerateTree(depth);
            string[] movesWithPlayer = AssignPlayers(moves);

            tree.FillTree(tree, movesWithPlayer);
            tree.DeterminateWinner();
            winningLargeCells = OrderResult(tree.GetWinningLargeCells(tree, movesWithPlayer), movesWithPlayer);
            winningSmallCells = OrderResult(tree.GetWinningSmallCells(tree), movesWithPlayer);

            //winsOfPlayers = tree.GetWinsOfPlayers(tree, movesWithPlayer);
            winsOfPlayers = GetWins(tree, depth);

            results.Add("Winning Large Cells: ", winningLargeCells);
            results.Add("Winning Small Cells: ", winningSmallCells);

            if (depth == 0 && tree.Winner == "x")
            {
                List<string> orderOfWins = new List<string>();
                orderOfWins.Add("1");
                orderOfWins.Add("0");

                results.Add("Wins Of Players: ", orderOfWins);
            }
            else if (depth == 0 && tree.Winner == "o")
            {
                List<string> orderOfWins = new List<string>();
                orderOfWins.Add("0");
                orderOfWins.Add("1");

                results.Add("Wins Of Players: ", orderOfWins);
            }

            else
            {
                results.Add("Wins Of Players: ", winsOfPlayers);
            }

            return results;

        }

        private List<string> GetWins(IComponent tree, int depth)
        {
            List<string> result = new List<string>();
            List<IComponent> allBoards = new List<IComponent>();
            Dictionary<int, List<IComponent>> allLayers = new Dictionary<int, List<IComponent>>();
            int counterX = 0;
            int counterO = 0;
            string winsOfX = string.Empty;
            string winsOfO = string.Empty;

            allBoards = tree.GetAllBoards(tree);

            for (int i = 0; i <= depth; i++)
            {
                var layer = allBoards.Where(x => x.Layer == i);
                allLayers.Add(i, layer.ToList());
            }

            var lastLayer = allLayers.Keys.Last();

            foreach (var layer in allLayers)
            {
                List<IComponent> onlyBoards = layer.Value;

                foreach (IComponent board in onlyBoards)
                {
                    if (board.Winner == "x")
                    {
                        counterX++;
                    }
                    else if (board.Winner == "o")
                    {
                        counterO++;
                    }
                    else
                    {
                        continue;
                    }

                }

                if (layer.Key == lastLayer)
                {
                    winsOfX += counterX.ToString();
                    winsOfO += counterO.ToString();
                }
                else
                {
                    winsOfX += counterX.ToString() + ".";
                    winsOfO += counterO.ToString() + ".";
                    
                }
                counterX = 0;
                counterO = 0;
            }

            result.Add(winsOfX);
            result.Add(winsOfO);

            return result;

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

        //orders results by moves
        private List<string> OrderResult(List<string> unOrderedResult, string[] moves)
        {

            string checkLength = unOrderedResult[0];
            List<string> orderedResult = new List<string>();
            string move;

            for (int i = 0; i < moves.Length; i++)
            {
                if (checkLength.Length == 2)
                {
                    move = moves[i].Substring(0, 2);
                }
                else
                {
                    move = moves[i].Substring(0, moves[i].Length - 2);
                }

                if (unOrderedResult != null && unOrderedResult.Contains(move))
                {
                    orderedResult.Add(move);
                    unOrderedResult.Remove(move);
                }
                else if (!unOrderedResult.Any())
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            return orderedResult;

        }


    }
}
