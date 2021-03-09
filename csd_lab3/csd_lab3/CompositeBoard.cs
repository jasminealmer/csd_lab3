using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class CompositeBoard : IComponent
    {
        public List<IComponent> children { get; private set; }
        public string Winner { get; private set; } 

        public string Id { get; set; }


        public CompositeBoard(IComponent child) 
        {
      
            IComponent child2 = child.Copy();
            IComponent child3 = child.Copy();
            IComponent child4 = child.Copy();
            IComponent child5 = child.Copy();
            IComponent child6 = child.Copy();
            IComponent child7 = child.Copy();
            IComponent child8 = child.Copy();
            IComponent child9 = child.Copy();

            child.SetId("NW");
            child2.SetId("NC");
            child3.SetId("NE");
            child4.SetId("CW");
            child5.SetId("CC");
            child6.SetId("CE");
            child7.SetId("SW");
            child8.SetId("SC");
            child9.SetId("SE");

            children = new List<IComponent>();
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

        public List<IComponent> GetChildren()
        {
            return children;
        }
        public void SetId(string id)
        {
            Id = id;
        }
        public void Execute()
        {

        }
        public IComponent Copy()
        {
            IComponent anotherOne = (IComponent)this.MemberwiseClone();
            return anotherOne;
        }

        public void MakeMove(string move)
        {
            foreach (IComponent child in children)
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

            //string newMoveX = "";
            //string newMoveO = "";

            //foreach (string move in playerX)
            //{
            //    //remove first
            //    newMoveX = move.Substring(3);
            //}
            //foreach (string move in playerO)
            //{
            //    //remove first
            //    newMoveO = move.Substring(3);
            //}

                

                //string tail = playerX.Substring()

                //RemoveCoordinate(playerX, playerO);

                //måste skala av input för varje nivå?
                //ändring
            
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
