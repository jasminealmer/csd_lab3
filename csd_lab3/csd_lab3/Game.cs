using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class Game : IBoard
    {
        private List<IBoard> boards;

        public Game(List<IBoard> boards)
        {
            this.boards = boards;
        }

        public void PlayGame()
        {
            //don't know what to return yet

            string result;

            foreach (IBoard board in boards)
            {
                //ASK FOR THE X OR O WINNER from the sub-composite (or leaf)
                //check if all subcomposites has a winner and what winner
                //calculate if it is a row, then WINNER for either X or O

                result += board.PlayGame(); //recurse, method calls itself
                return result;
            }
        }





        //game board. methods that belongs to game

        //method 1: recurse through pattern composite to play boards
        //method 2: sends in and saves moves to Player (x/o), remember to terminate if wrong move etc
        //method 3: calculate win/loose for each game (här eller i Player?)
        
        //andra methods: skicka ut output enl. dokument
    }
}
