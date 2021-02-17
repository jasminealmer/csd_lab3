using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class Cell : IBoard
    {
        private string move;

        public Cell(string move)
        {
            this.move = move;
            //antingen X eller O eller null beroende på inputen?
        }

        public string PlayGame()
        {
            //returnera cellens värde
            return move; 
        }

    }
}
