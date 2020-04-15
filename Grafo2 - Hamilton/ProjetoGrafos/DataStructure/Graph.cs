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

        #region Atributos

        /// <summary>
        /// Lista de nós que compõe o grafo.
        /// </summary>
        private List<Node> nodes;

        #endregion

        #region Propridades

        /// <summary>
        /// Mostra todos os nós do grafo.
        /// </summary>
        public Node[] Nodes
        {
            get { return this.nodes.ToArray(); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do grafo.
        /// </summary>
        public Graph()
        {
            this.nodes = new List<Node>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Criador do Grafo
        /// </summary>
        public void CreateGraph()
        {
            nodes.Add(new Node("A", null));
            nodes.Add(new Node("B", null));
            nodes.Add(new Node("C", null));
            nodes.Add(new Node("D", null));
            nodes.Add(new Node("E", null));
        }

        /// <summary>
        /// Adiciona as arestas no Grafo
        /// </summary>
        public void CreateEdges()
        {
            Node a = Find("A");
            Node b = Find("B");
            Node c = Find("C");
            Node d = Find("D");
            Node e = Find("E");
            a.AddEdge(b);
            a.AddEdge(c);
            b.AddEdge(e);
            b.AddEdge(d);
            b.AddEdge(a);
            c.AddEdge(a);
            c.AddEdge(b);
            c.AddEdge(c);
            c.AddEdge(e);
            d.AddEdge(e);

        }

        /// <summary>
        /// Encontra o nó através do seu nome.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <returns>O nó encontrado ou nulo caso não encontre nada.</returns>
        private Node Find(string name)
        {
            foreach(Node n in nodes)
            {
                if (n.Name.Equals(name))
                    return n;
            }
            return null;
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name)
        {
            
            if(Find(name)==null)
            {
                nodes.Add(new Node(name,null));
            }
            
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name, object info)
        {
            if (Find(name) == null)
            {
                nodes.Add(new Node(name, null));
            }
        }

        /// <summary>
        /// Remove um nó do grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser removido.</param>
        public void RemoveNode(string name)
        {
            Node n = Find(name);
            if(n!=null)
            {
                nodes.Remove(n);
            }
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="from">O nó de origem.</param>
        /// <param name="to">O nó de destino.</param>
        /// <param name="cost">O cust associado.</param>
        public void AddEdge(string from, string to, double cost)
        {
            Node f = Find(from);
            Node t = Find(to);
            if(f!=null && t!=null)
            {
                f.AddEdge(t, cost);
            }
        }

        /// <summary>
        /// Obtem todos os nós vizinhos de determinado nó.
        /// </summary>
        /// <param name="node">O nó origem.</param>
        /// <returns></returns>
        public Node[] GetNeighbours(string from)
        {
            Node f = Find(from);
            Node[] node = new Node[f.Edges.Count];
            if(f!=null)
            {
                int i = 0;
                foreach (Edge e in f.Edges)
                {
                    node[i] = e.To;
                    i++;
                }
            }
            return node;
        }

        /// <summary>
        /// Valida um caminho, retornando a lista de nós pelos quais ele passou.
        /// </summary>
        /// <param name="nodes">A lista de nós por onde passou.</param>
        /// <param name="path">O nome de cada nó na ordem que devem ser encontrados.</param>
        /// <returns></returns>
        public bool IsValidPath(ref Node[] nodes, params string[] path)
        {
            nodes = new Node[path.Length];
            bool val=true;
            for (int i=0;i<(path.Length-1);i++)
            {
                if (val)
                {
                    Node n = Find(path[i]);
                    val = false;
                    foreach (Edge e in n.Edges)
                    {
                        if (e.To.Equals(Find(path[i + 1])))
                        {
                            val = true;
                            break;
                        }    
                    }
                }
                else
                    return false;
            }
            if(!val)
            {
                return false;
            }
            for (int i = 0; i < (path.Length); i++)
            {
                nodes[i] = Find(path[i]);
            }
            return true;
        }

        #endregion

    }
}
