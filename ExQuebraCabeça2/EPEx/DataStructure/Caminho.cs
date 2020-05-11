using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EP.DataStructure
{
    class Caminho
    {
        public Node N { set; get; }
        public int GCost { set; get; }
        public int HCost { set; get; }

        public Caminho(Node n, int GCost, int HCost)
        {
            this.N = n;
            this.GCost = GCost;
            this.HCost = HCost;
        }
        
        public int GetF()
        {
            return GCost + HCost;
        }

        public bool Equals(Caminho other)
        {
            return null != other && this.N == other.N && this.GCost == other.GCost && this.HCost == other.HCost;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Caminho);
        }
        public override int GetHashCode()
        {
            return GCost + HCost + N.Nivel;
        }
    }
}
