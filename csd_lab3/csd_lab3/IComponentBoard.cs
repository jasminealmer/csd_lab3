using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponentBoard
    {

        public void MakeMove(string cell, string player);
        public string DeterminateWinner();
        public IComponentBoard Copy();

        //Printinfo
        //public void PrintInfo(string info)
        //{
        //    Console.WriteLine(info);
        //}
    }
}
