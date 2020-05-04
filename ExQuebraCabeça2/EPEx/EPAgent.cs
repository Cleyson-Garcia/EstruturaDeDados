using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using ProjetoGrafos.DataStructure;

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
            Node inicio = new Node(initState,0);
            List<Node> busca = new List<Node>();

            Node n = inicio;

            while(!TargetFound(n))
            {
                
            }

            return BuildAnswer(n); ;
        }

        private List<Node> GetSucessors(Node n)
        {
            List<Node> sucessores = new List<Node>();
            //tamanho de cada linha do quebra-cabeça
            int lateral = (int)Math.Sqrt(target.Length);
            //posicao atual que pode ser colocada uma peca
            int posicao = Array.IndexOf(n.Info, 0);
            int[] sup;
            
            //top
            if(posicao >= lateral)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao - lateral];
                sup[posicao - lateral] = 0;
                sucessores.Add(new Node(sup,n.Nivel+1));
            }
            //left
            if (posicao % lateral == 0)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao - 1];
                sup[posicao - lateral] = 0;
                sucessores.Add(new Node(sup, n.Nivel + 1));
            }
            //right
            if (posicao % lateral == lateral - 1)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao + 1];
                sup[posicao - lateral] = 0;
                sucessores.Add(new Node(sup, n.Nivel + 1));
            }
            //bottom
            if (posicao >= target.Length - lateral)
            {
                sup = (int[])n.Info.Clone();
                sup[posicao] = sup[posicao + lateral];
                sup[posicao - lateral] = 0;
                sucessores.Add(new Node(sup, n.Nivel + 1));
            }
            return sucessores;
        }
        
        private int[] BuildAnswer(Node n)
        {
            //Passara pelo caminho, do fim ao começo,
            //Adicionando o movimento realizado a uma lista
            throw new NotImplementedException();
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
    }
}

