using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponent
    {
        public string Id { get; set; }
        public void MakeMove(string move);
        public string DeterminateWinner();
        public IComponent Copy();

        public List<IComponent> GetChildren();

        public void SetId(string id);

        //Printinfo
        //public void PrintInfo(string info)
        //{
        //    Console.WriteLine(info);
        //}
    }
}
