﻿using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class Parse
    {
        readonly List<string> x = new List<string>();
        readonly List<string> o = new List<string>();
        public string[] ParseInput(string input)
        {
            string withoutSpaces = RemoveWhiteSpaces(input);
            string[] parsedInput = SplitInput(withoutSpaces);
            return parsedInput;
        }

        private string RemoveWhiteSpaces(string input)
        {

            if (input.Contains(" "))
            {
                input = input.Replace(" ", "");
            }
            return input;
        }
        private string[] SplitInput(string input)
        {
            string[] splittedInput = input.Split(",");
            return splittedInput;
        }

        public void PlayGame(string[] moves)
        {
            AssignPlayers(moves);
            int depth = DecideDepth(moves[0]);
            IComponent tree = GenerateTree(depth);
            TraverseTree(tree);

        }

        public void TraverseTree(IComponent tree)
        {
            if (tree != null)

            {
                tree.MakeMove(x, o);
                //TraverseTree(tree.Left);
                //PreOrder_Rec(root.Right);

            }
        }

        //Assign players of the moves
        public void AssignPlayers(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    x.Add(moves[i]);
                }
                else
                {
                    o.Add(moves[i]);
                }
            }
        }

        public int DecideDepth(string firstCoord)
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

        public IComponent GenerateTree(int depth)
        {
            IComponent component = null;
            for (int i = depth; i > 0; i--)
            {
                if (i == depth)
                {
                    component = new LeafBoard();
                }
                else
                {
                    component = new CompositeBoard(component);
                }
            }
            return component;

            //if (depth == 0)
            //{
            //    IComponentBoard leafboard = new LeafBoard();
            //    Console.WriteLine("hej");

            //        //if (item.StartsWith("NW")) //den kommer komma in här fler gånger, hur ska den veta att ta den redan existerande NW?
            //        //{
            //        //    //nu skapar jag en ny för varje "startswith NW"

            //        //}
            //        //else if (item.StartsWith("NC"))
            //        //{
            //        //    //samma kod
            //        //}

            //        //fortsätt


            //}

            //else if (depth == 1)
            //{
            //    LeafBoard leafboard = new LeafBoard();
            //    CompositeBoard compositeboard = new CompositeBoard(leafboard);


            //    string result = compositeboard.children.ToString();
            //    Console.WriteLine(result);
            //    //return compositeboard.children;

            //    //go through all items: "NW, CC, ..." for example
            //    //foreach (string item in input)
            //    //{
            //    //    //string player = "";

            //    //    //if (x.Contains(item))
            //    //    //{
            //    //    //    player = "x";
            //    //    //}
            //    //    //else if (o.Contains(item))
            //    //    //{
            //    //    //    player = "o";
            //    //    //}

            //    //    //skicka in cellen och playern i Leafboard MEN JAG VILL INTE STARTA ETT NYTT FÖR VARJE ITEM
            //    //    //leafboard = new LeafBoard();
            //    //}

            //    //IComponentBoard component = null;

            //    //string[] separatedCoordinates = firstLevel.Split(".");

            //    //for (int i = separatedCoordinates.Length - 1; i < 0; i--)
            //    //{
            //    //    if (i == separatedCoordinates.Length - 1)
            //    //    {
            //    //        component = new LeafBoard();
            //    //    }
            //    //    else
            //    //    {
            //    //        component = new CompositeBoard(component); //med leafboardet!!
            //    //    }
            //    //}
            //    //return component;

            //}




        }




        //public string ParseOutput(LeafBoard leafboard)
        //{
            
        //}

    }
}
