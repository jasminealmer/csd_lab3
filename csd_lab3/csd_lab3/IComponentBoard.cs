using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponentBoard
    {

        public void MakeMove(string cell, string player);

        //Printinfo
        public void PrintInfo(string info)
        {
            Console.WriteLine(info);
        }
    }
}
