using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class CompositeBoard : IComponentBoard
    {
        public List<IComponentBoard> children { get; private set; }
        public string Winner { get; private set; } 

        public CompositeBoard(IComponentBoard child) 
        {
            IComponentBoard child2 = child.Copy();
            IComponentBoard child3 = child.Copy();
            IComponentBoard child4 = child.Copy();
            IComponentBoard child5 = child.Copy();
            IComponentBoard child6 = child.Copy();
            IComponentBoard child7 = child.Copy();
            IComponentBoard child8 = child.Copy();
            IComponentBoard child9 = child.Copy();

            children = new List<IComponentBoard>();
            children.Add(child);
            children.Add(child2);
            children.Add(child3);
            children.Add(child4);
            children.Add(child5);
            children.Add(child6);
            children.Add(child7);
            children.Add(child8);
            children.Add(child9);

            //MakeMove(child, player); eller är detta redan sparat på något sätt i child?

            Winner = "No winner"; 
        }

        public IComponentBoard Copy()
        {
            IComponentBoard anotherOne = (IComponentBoard)this.MemberwiseClone();
            return anotherOne;
        }

        public void MakeMove(string cell, string player)
        {

        }

        public string DeterminateWinner()
        {
            //ska detta vara annorlunda? jag vill göra samma, ska jag lägga det i IComponentBoard då istället?
            string error = "hello";
            return error;
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
