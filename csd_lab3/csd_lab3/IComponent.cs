using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponent
    {

        public void MakeMove(List<string> cell, List<string> player);
        public string DeterminateWinner();
        public IComponent Copy();

        //Printinfo
        //public void PrintInfo(string info)
        //{
        //    Console.WriteLine(info);
        //}
    }
}
