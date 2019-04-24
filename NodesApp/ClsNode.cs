using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ClsNode
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        private ClsNode Prev { get; set; }
        private ClsNode Next { get; set; }

        public ClsNode(string name)
        {
            Name = name;
            Weight = 0;
        }

        public void SetNext(ClsNode nextNode, int weight)
        {
            Next = nextNode;
            Next.SetPrev(this);
            Weight = weight;
        }

        public ClsNode GetNext()
        {
            return Next ?? null;
        }

        public void SetPrev(ClsNode prevNode)
        {
            Prev = prevNode;
        }

        public ClsNode GetPrev()
        {
            return Prev ?? null;
        }

        public ClsNode SearchNode(string name)
        {
            return Name.ToLower().Trim() == name.ToLower().Trim() ? this : Next?.SearchNode(name);
        }
    }
}
