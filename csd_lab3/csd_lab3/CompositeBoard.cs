﻿using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class CompositeBoard : IComponentBoard
    {
        public List<IComponentBoard> children { get; private set; }

        public CompositeBoard(IComponentBoard child)
        {
            children.Add(child);
        }

        public void MakeMove(string cell, string player)
        {
            //foreach (var child in children)
            //{
            //    children.Add = player;
            //}
        }

        //kan bestå av leaf boards ELLER composite boards?? En string "NW"?


        //private List<IComponentBoard> boards;

        //public CompositeBoard(List<IComponentBoard> boards)
        //{
        //    this.boards = boards;
        //}

        //public void PlayGame()
        //{
        //    //don't know what to return yet

        //    string result;

        //    foreach (IComponentBoard board in boards)
        //    {
        //        //ASK FOR THE X OR O WINNER from the sub-composite (or leaf)
        //        //check if all subcomposites has a winner and what winner
        //        //calculate if it is a row, then WINNER for either X or O

        //        result += board.PlayGame(); //recurse, method calls itself
        //        return result;
        //    }
        //}





        //game board. methods that belongs to game

        //method 1: recurse through pattern composite to play boards
        //method 2: sends in and saves moves to Player (x/o), remember to terminate if wrong move etc
        //method 3: calculate win/loose for each game (här eller i Player?)

        //andra methods: skicka ut output enl. dokument
    }
}
