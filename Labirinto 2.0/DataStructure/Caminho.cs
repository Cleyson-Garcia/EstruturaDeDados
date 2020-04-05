using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labirinto.DataStructure
{
    class Caminho
    {
        private double dist;
        private Node destino;
        private Edge rota;

        public Caminho(double dist, Node destino, Edge caminho)
        {
            this.dist = dist;
            this.destino = destino;
            this.rota = caminho;
        }

        public double GetDist()
            {
                return dist;
            }
        public Node GetDestino()
            {
                return destino;
            }
        public Edge GetRota()
        {
            return rota;
        }
    

    }
}
