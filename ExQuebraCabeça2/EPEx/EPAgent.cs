using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using ProjetoGrafos.DataStructure;
using EP.DataStructure;

namespace EP
{
    /// <summary>
    /// EPAgent - searchs solution for the eight puzzle problem
    /// </summary>
    public class EightPuzzle : Graph
    {
        private int[] initState;
        private int[] target;

        /// <summary>
        /// Creating the agent and setting the initialstate plus target
        /// </summary>
        /// <param name="InitialState"></param>
        public EightPuzzle(int[] InitialState, int[] Target)
        {
            initState = InitialState;
            target = Target;
        }

        /// <summary>
        /// Accessor for the solution
        /// </summary>
        public int[] GetSolution()
        {
            return FindSolution();
        }

        /// <summary>
        /// Função principal de busca
        /// </summary>
        /// <returns></returns>
        private int[] FindSolution()
        {
            Node inicio = new Node(null,initState,0,null);
            PQ open = new PQ();
            List<Caminho> closed = new List<Caminho>();

            
            int euristicaInicio = Euristica(inicio);
            Caminho n = new Caminho(inicio, euristicaInicio, 0);
            open.Add(n);
            closed.Add(n);
            while (!open.EstaVazio())
            {
                foreach(Caminho m in GetSucessors(n.N,euristicaInicio))
                {
                    if(!closed.Contains(m))
                    {
                        open.Add(m);
                    }
                    
                }
                n = open.Pop();
                closed.Add(n);
                if(TargetFound(n.N))
                {
                    break;
                }
            }

            return BuildAnswer(n.N); ;
        }

        private List<Caminho> GetSucessors(Node n,int valorInicio)
        {
            List<Caminho> sucessores = new List<Caminho>();
            //tamanho de cada linha do quebra-cabeça
            int lateral = (int)Math.Sqrt(target.Length);
            //posicao atual que pode ser colocada uma peca
            int posicao = Array.IndexOf(n.Info, 0), gcost, hcost;
            int[] sup;
            Caminho c;
            Node a;

            //top
            if (posicao > lateral)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao - lateral];
                sup[posicao - lateral] = 0;
                if(n.Nivel>0 && !Compare(sup,n.Parent.Info))
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a,gcost,hcost);
                    sucessores.Add(c);
                }
                else if (n.Nivel == 0)
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
                
            }
            //left
            if (posicao % lateral != 0)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao - 1];
                sup[posicao - 1] = 0;
                if (n.Nivel > 0 && !Compare(sup, n.Parent.Info))
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
                else if (n.Nivel == 0)
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
            }
            //right
            if (posicao % lateral != lateral - 1)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao + 1];
                sup[posicao + 1] = 0;
                if (n.Nivel > 0 && !Compare(sup, n.Parent.Info))
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
                else if (n.Nivel == 0)
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
            }
            //bottom
            if (posicao < target.Length - lateral)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao + lateral];
                sup[posicao + lateral] = 0;
                if (n.Nivel > 0 && !Compare(sup, n.Parent.Info))
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = valorInicio - gcost;
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
                else if (n.Nivel == 0)
                {
                    a = new Node(sup[posicao].ToString(), sup, n.Nivel + 1, n);
                    gcost = Euristica(a);
                    hcost = Math.Abs(valorInicio - gcost);
                    c = new Caminho(a, gcost, hcost);
                    sucessores.Add(c);
                }
            }
            return sucessores;
        }
        
        private int[] BuildAnswer(Node n)
        {
            int tam = n.Nivel;
            int[] resposta = new int[tam];
            int i = 0;
            while(n.Name != null)
            {
                resposta[tam-i-1] = int.Parse(n.Name);
                i++;
                n = n.Parent;
            }

            return resposta;
        }

        private bool TargetFound(Node n)
        {
            bool valido = true;
            for(int i=0; i<target.Length;i++)
            {
                if (n.Info[i]!=target[i])
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }

        private bool Compare(int[] a, int[] b)
        {
            bool valido = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }

        private int Euristica(Node n)
        {
            int[] sup = n.Info;
            int valor = 0;

            for(int i=0; i<sup.Length;i++)
            {
                valor += Math.Abs(sup[i] - i);
            }

            return valor;
        }
    }
}

