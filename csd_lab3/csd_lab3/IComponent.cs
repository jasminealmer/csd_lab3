using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IComponent
    {
        public string Id { get; set; }

        public List<IComponent> Collection { get; set; }
        public List<IComponent> Children { get; set; }
        public void MakeMove(string move);
        public void DeterminateWinner();
        public IComponent Copy(string id);

        //public List<IComponent> GetChildren();

        //public void SetId(string id);

        //Printinfo
        //public void PrintInfo(string info)
        //{
        //    Console.WriteLine(info);
        //}
    }
}
