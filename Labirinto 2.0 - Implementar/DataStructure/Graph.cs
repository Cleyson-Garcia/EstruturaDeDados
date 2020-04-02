using Labirinto.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>
    public class Graph
    {
        private List<Node> nodes;

        public Graph()
        {
            nodes = new List<Node>();
        }
        public List<Node> ShortestPath(string begin, string end)
        {
            double dist;
            Caminho menor;
            List<Node> l = new List<Node>();
            PQ pq = new PQ();

            Node n = FindNode(begin);
            Node fim = FindNode(end);

            while(!l.Contains(fim))
            {                
                foreach(Edge e in n.Edges)
                {
                    if(e.To.Visited == false)
                    {
                        dist = e.Cost + n.Dist;
                        pq.Add(new Caminho(dist, e.To, e));
                    }
                   
                }

                
                menor = pq.Pop();
                while(menor.GetDestino().Visited)
                {
                    menor = pq.Pop();
                }
                n = menor.GetDestino();
                n.Visited = true;
                n.Dist = menor.GetDist();
                l.Add(n);

                
               
            }

            return l;
        }

        public List<Node> BreadthFirstSearch(string begin)
        {
            Queue<Node> q = new Queue<Node>();
            List<Node> l = new List<Node>();

            Node n = FindNode(begin);
            n.Visited = true;
            q.Enqueue(n);
            l.Add(n);
            while(q.Count>0)
            {
                n = q.Dequeue();
                
                foreach (Edge e in n.Edges)
                {
                    if(e.To.Visited == false)
                    {
                        e.To.Parent = n;
                        e.To.Visited = true;
                        q.Enqueue(e.To);
                        l.Add(e.To);
                    }
                }
            }
            return l;

        }

        public List<Node> DepthFirstSearch(string begin)
        {
            Stack<Node> s = new Stack<Node>();
            List<Node> l = new List<Node>();

            Node n = FindNode(begin);
            n.Visited = true;
            s.Push(n);
            l.Add(n);
            bool possui;
            while(s.Count>0)
            {
                possui = false;
                n = s.Peek();
                foreach (Edge e in n.Edges)
                {
                    if (e.To.Visited == false)
                    {
                        e.To.Parent = n;
                        e.To.Visited = true;
                        s.Push(e.To);
                        l.Add(e.To);
                        possui = true;
                        break;
                    }
                }
                if(!possui)
                {
                    s.Pop();
                }
                
            }

            return l;
        }

        public void AddNode(string name, object info)
        {
            Node n = FindNode(name);
            if(n == null)
            {
                nodes.Add(new Node(name, info));
            }
            else
            {
                throw new Exception("Nó já criado"); 
            }
        }

        public void AddEdge(string nameFrom, string nameTo, int cost)
        {
            Node n = FindNode(nameFrom);
            Node m = FindNode(nameTo);
            if(n == null || m == null)
            {
                throw new Exception("Nó não existe");
            }
            else
            {
                n.AddEdge(m, cost);
            }

        }

        public Node FindNode(string nome)
        {
            foreach(Node n in nodes)
            {
                if(n.Name.Equals(nome))
                {
                    return n;
                }
            }
            return null;
        }
    }
}
