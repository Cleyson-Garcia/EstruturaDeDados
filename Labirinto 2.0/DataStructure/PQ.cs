using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labirinto.DataStructure
{
    class PQ
    {
        private Caminho[] _elementos;
        private int size;
        private int tamanhoTotal = 20;

        public PQ()
        {
            _elementos = new Caminho[tamanhoTotal];
        }

        public void More()
        {
            if(size == tamanhoTotal)
            {
                tamanhoTotal *= 2;
                Caminho[] temp = new Caminho[tamanhoTotal];
                _elementos.CopyTo(temp, 0);
                _elementos = temp;
            }
        }
        private int IndexFilhoEsquerda(int indiceElemento)
        {
            return 2*indiceElemento + 1;
        }

        private int IndexFilhoDireita(int indiceElemento)
        {
            return 2 * indiceElemento + 2;
        }

        private int IndexPai(int indiceElemento)
        {
            return (indiceElemento -1) / 2;
        }

        private bool TemFilhoDireito(int indiceElemento)
        {
            return (IndexFilhoDireita(indiceElemento) < size);
        }
        private bool TemFilhoEsquerdo(int indiceElemento)
        {
            return (IndexFilhoEsquerda(indiceElemento) < size);
        }
        private bool IsRaiz(int indiceElemento)
        {
            return (indiceElemento == 0);
        }

        private Caminho GetFilhoDireita(int indiceElemento)
        {
            return _elementos[IndexFilhoDireita(indiceElemento)];
        }
        private Caminho GetFilhoEsquerda(int indiceElemento)
        {
            return _elementos[IndexFilhoEsquerda(indiceElemento)];
        }
        private Caminho GetPai(int indiceElemento)
        {
            return _elementos[IndexPai(indiceElemento)];
        }

        private void Troca(int primeiroIndice, int segundoIndice)
        {
            Caminho temp = _elementos[primeiroIndice];
            _elementos[primeiroIndice] = _elementos[segundoIndice];
            _elementos[segundoIndice] = temp;
        }
        public bool EstaVazio()
        {
            return size == 0;
        }

        public Caminho MostraPrimeiro()
        {
            if (EstaVazio())
            {
                throw new IndexOutOfRangeException();
            }
            return _elementos[0];
        }

        public Caminho Pop()
        {
            if (EstaVazio())
            {
                throw new IndexOutOfRangeException();
            }

            Caminho result = _elementos[0];
            _elementos[0] = _elementos[size - 1];
            size--;
            HeapDown();
            return result;
        }

        public void Add(Caminho elemento)
        {
            More();
            _elementos[size] = elemento;
            size++;
            HeapUp();
        }

        private void HeapUp()
        {
            int indice = size - 1;
            while(!IsRaiz(indice) && _elementos[indice].GetDist() < GetPai(indice).GetDist())
            {
                int indicePai = IndexPai(indice);
                Troca(indice, indicePai);
                indice = indicePai;
            }
        }
        private void HeapDown()
        {
            int indice = 0;
            while(TemFilhoEsquerdo(indice))
            {
                int menorIndice = IndexFilhoEsquerda(indice);
                if(TemFilhoDireito(indice) && GetFilhoDireita(indice).GetDist()< GetFilhoEsquerda(indice).GetDist())
                {
                    menorIndice = IndexFilhoDireita(indice);
                }

                if(_elementos[menorIndice].GetDist() >= _elementos[indice].GetDist())
                {
                    break;
                }

                Troca(menorIndice, indice);
                indice = menorIndice;
                    
             }
        }
    }
}
