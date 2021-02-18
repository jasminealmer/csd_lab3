using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponentBoard
    {
        public void PlayGame() 
        {
            //method to be used for Cell and Game
            //will return something for output?

        }
        //Printinfo
        public void PrintInfo(string info)
        {
            Console.WriteLine(info);
        }
    }
}
