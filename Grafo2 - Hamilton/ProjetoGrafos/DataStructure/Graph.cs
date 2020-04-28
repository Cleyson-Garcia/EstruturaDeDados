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
            nodes.Add(new Node("F", null));
            nodes.Add(new Node("G", null));
            nodes.Add(new Node("H", null));
            nodes.Add(new Node("I", null));
            nodes.Add(new Node("J", null));
            nodes.Add(new Node("K", null));
            nodes.Add(new Node("L", null));
            nodes.Add(new Node("M", null));
            nodes.Add(new Node("N", null));
            nodes.Add(new Node("O", null));
            nodes.Add(new Node("P", null));
            nodes.Add(new Node("Q", null));
            nodes.Add(new Node("R", null));
            nodes.Add(new Node("S", null));
            nodes.Add(new Node("T", null));
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
            Node f = Find("F");
            Node g = Find("G");
            Node h = Find("H");
            Node i = Find("I");
            Node j = Find("J");
            Node k = Find("K");
            Node l = Find("L");
            Node m = Find("M");
            Node n = Find("N");
            Node o = Find("O");
            Node p = Find("P");
            Node q = Find("Q");
            Node r = Find("R");
            Node s = Find("S");
            Node t = Find("T");
            doubleEdge(a,b);
            doubleEdge(b,c);
            doubleEdge(c,d);
            doubleEdge(d,e);
            doubleEdge(e,a);
            doubleEdge(a,f);
            doubleEdge(e,n);
            doubleEdge(e,l);
            doubleEdge(c,j);
            doubleEdge(b,h);
            doubleEdge(n,o);
            doubleEdge(o,f);
            doubleEdge(f,g);
            doubleEdge(g,h);
            doubleEdge(h,i);
            doubleEdge(i,j);
            doubleEdge(j,k);
            doubleEdge(k,l);
            doubleEdge(l,m);
            doubleEdge(m,n);
            doubleEdge(o,p);
            doubleEdge(g,q);
            doubleEdge(i,r);
            doubleEdge(k,s);
            doubleEdge(m,t);
            doubleEdge(p,q);
            doubleEdge(q,r);
            doubleEdge(r,s);
            doubleEdge(s,t);
            doubleEdge(t,q);

        }

        private void doubleEdge(Node a, Node b)
        {
            a.AddEdge(b);
            b.AddEdge(a);
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
            Node[] node = new Node[f.EdgesIndo.Count];
            if(f!=null)
            {
                int i = 0;
                foreach (Edge e in f.EdgesIndo)
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
                    foreach (Edge e in n.EdgesIndo)
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

        public Tuple<Node[],Edge[]> Setup()
        {
            Node noInicial = null;
            List<Edge> edges = new List<Edge>();
            List<Node> nodes = new List<Node>();
            int valido1 = 0, valido2 = 0;
            Node[] retornaNode;
            Edge[] retornaEdge;

            //Validando se o caminho hamiltoniano pode existir
            //Não garante existencia, apenas rezuz calculos para camininhos impossiveis
            foreach (Node n in Nodes)
            {
                if ((n.EdgesIndo.Count() + n.EdgesVindo.Count()) == 0)
                {
                    return Tuple.Create<Node[], Edge[]>(null, null);
                }
                else if(n.EdgesIndo.Count() == 0)
                {
                    valido1++;   
                }
                else if (n.EdgesVindo.Count() == 0)
                {
                    valido2++;
                    noInicial = n;
                }
            }
            if(valido1 > 1 || valido2 > 1)
            {
                return Tuple.Create<Node[], Edge[]>(null, null);
            }

            if(valido2 == 1)
            {
                nodes = Hamilton(noInicial);
            }
            else
            {
                foreach(Node inicio in Nodes)
                {
                    nodes = Hamilton(inicio);
                    if(nodes != null)
                    {
                        break;
                    }
                }
            }

            if(nodes == null)
            {
                return Tuple.Create<Node[], Edge[]>(null, null);
            }
            else
            {
                retornaNode = nodes.ToArray();
            }
            

            for (int i = 0; i < retornaNode.Count() - 1; i++)
            {
                Node no = retornaNode[i];
                foreach (Edge aresta in no.EdgesIndo)
                {
                    if (aresta.To.Equals(retornaNode[i + 1]))
                    {
                        edges.Add(aresta);
                        Console.WriteLine("Adiconou aresta");
                        break;
                    }
                }
            }

            retornaEdge = edges.ToArray();
            return Tuple.Create<Node[],Edge[]>(retornaNode, retornaEdge);
        }

        public List<Node> Hamilton(Node n)
        {
            Stack<Node> s = new Stack<Node>();
            List<Node> l = new List<Node>();
            bool validador;

            n.Usando = true;
            n.Parent = null;
            s.Push(n);
            l.Add(n);
            while (s.Count > 0)
            {
                validador = false;
                n = s.Peek();
                foreach (Edge e in n.EdgesIndo)
                {
                    if (e.Testado == false && e.To.Usando == false)
                    {
                        e.To.Parent = n;
                        e.To.Usando = true;
                        e.Testado = true;
                        s.Push(e.To);
                        l.Add(e.To);
                        validador = true;
                        break;
                    }
                }
                if (!validador)
                {
                    if (l.Count() == Nodes.Length)
                    {
                        break;
                    }
                    if (n.Parent == null)
                    {
                        return null;
                    }
                    l.Remove(n);
                    s.Pop();
                    n.Usando = false;
                    foreach (Edge e in n.EdgesIndo)
                    {
                        e.Testado = false;
                    }

                }
            }
            return l;
        }

        #endregion

    }
}
