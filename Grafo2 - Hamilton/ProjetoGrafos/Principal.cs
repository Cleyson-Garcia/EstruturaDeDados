using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Glee = Microsoft.Glee.Drawing;
using GleeUI = Microsoft.Glee.GraphViewerGdi;
using EDA = ProjetoGrafos.DataStructure;

namespace ProjetoGrafos
{
    /// <summary>
    /// Classe que representa o form principal da aplicação.
    /// </summary>
    public partial class Principal : Form
    {

        #region Atributos

        /// <summary>
        /// Instância do grafo a ser utilizada no formulário.
        /// </summary>
        private EDA.Graph graph;

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do form principal.
        /// </summary>
        public Principal()
        {
            InitializeComponent();
            this.graph = new EDA.Graph();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Atribui aos controles o conteúdo do grafo.
        /// </summary>
        private void SetGraphControls(bool drawGraph = true)
        {
            List<EDA.Edge> edges = new List<EDA.Edge>();
            EDA.Node[] nodes = this.graph.Nodes;
            // Limpa controles..
            // Carrega nós e agrupa arcos..
            // Adiciona os arcos ao listbox..
            if (drawGraph)
            {
                DrawGraph(null,null);
            }
        }

        /// <summary>
        /// Desenha o grafo atual.
        /// </summary>
        private void DrawGraph(EDA.Node[] highlightedNodes, EDA.Edge[] highlightedEdges)
        {
            List<EDA.Edge> edges = new List<EDA.Edge>();
            Glee.Graph drawingGraph = new Glee.Graph("Grafo - EDA2");
            // Adiciona nós ao grafo..
            foreach (EDA.Node node in this.graph.Nodes)
            {
                Glee.Node drawingNode = drawingGraph.AddNode(node.Name);
                drawingNode.Attr.Shape = Glee.Shape.Circle;
                if (highlightedNodes != null && Array.IndexOf(highlightedNodes, node) >= 0)
                {
                    drawingNode.Attr.Color = Glee.Color.Red;
                }
                // Consolida os arcos..
                edges.AddRange(node.EdgesIndo);
            }
            foreach (EDA.Edge edge in edges)
            {
                Glee.Edge drawingEdge = drawingGraph.AddEdge(edge.From.Name, edge.To.Name);
                drawingEdge.Attr.Label = String.Format("{0:F4}", edge.Cost);
                if (highlightedEdges != null && Array.IndexOf(highlightedEdges, edge) >= 0)
                {
                    drawingEdge.Attr.Color = Glee.Color.Red;
                }
            }
            // Gera controle de desenho..
            GleeUI.GViewer viewer = new GleeUI.GViewer();
            viewer.NavigationVisible = false;
            viewer.OutsideAreaBrush = Brushes.White;
            viewer.RemoveToolbar();
            viewer.Graph = drawingGraph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlGraph.Controls.Clear();
            pnlGraph.Controls.Add(viewer);
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Clique do botão AddNode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGraph_Click(object sender, EventArgs e)
        {
            this.graph.CreateGraph();
            SetGraphControls();
        }


        private void btnCreateEdges_click(object sender, EventArgs e)
        {
            this.graph.CreateEdges();
            SetGraphControls();
        }
        /// <summary>
        /// Clique do botão que limpa arcos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveArcs_Click(object sender, EventArgs e)
        {
            // Adiciona nós ao grafo..
            foreach (EDA.Node node in this.graph.Nodes)
            {
                node.EdgesIndo.Clear();
                node.EdgesVindo.Clear();
            }
            SetGraphControls();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            var tupp = this.graph.Setup();
            EDA.Node[] retornoNode = tupp.Item1;
            EDA.Edge[] edges = tupp.Item2;

            if (retornoNode == null)
            {
                MessageBox.Show("Não existe caminho Hemiltoniano", "Validação de Caminho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetGraphControls(false);
                DrawGraph(retornoNode, edges);
            }
        
            
        }

        #endregion

    }
}
