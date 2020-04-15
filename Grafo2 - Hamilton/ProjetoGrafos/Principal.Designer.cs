namespace ProjetoGrafos
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlGraph = new System.Windows.Forms.Panel();
            this.gbGraph = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRemoveArcs = new System.Windows.Forms.Button();
            this.lstArcs = new System.Windows.Forms.ListBox();
            this.lblEdge = new System.Windows.Forms.Label();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.gbOperations = new System.Windows.Forms.GroupBox();
            this.btnShowPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnShowNeighbours = new System.Windows.Forms.Button();
            this.cmbNodeNeighbourhood = new System.Windows.Forms.ComboBox();
            this.lblNoodeNeighbourhood = new System.Windows.Forms.Label();
            this.gbGraph.SuspendLayout();
            this.gbOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGraph
            // 
            this.pnlGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGraph.Location = new System.Drawing.Point(322, 12);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.Size = new System.Drawing.Size(450, 373);
            this.pnlGraph.TabIndex = 0;
            // 
            // gbGraph
            // 
            this.gbGraph.Controls.Add(this.button1);
            this.gbGraph.Controls.Add(this.btnRemoveArcs);
            this.gbGraph.Controls.Add(this.lstArcs);
            this.gbGraph.Controls.Add(this.lblEdge);
            this.gbGraph.Controls.Add(this.btnAddNode);
            this.gbGraph.Location = new System.Drawing.Point(12, 6);
            this.gbGraph.Name = "gbGraph";
            this.gbGraph.Size = new System.Drawing.Size(304, 243);
            this.gbGraph.TabIndex = 1;
            this.gbGraph.TabStop = false;
            this.gbGraph.Text = "Grafo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Criar Arestas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCreateEdges_click);
            // 
            // btnRemoveArcs
            // 
            this.btnRemoveArcs.Location = new System.Drawing.Point(202, 209);
            this.btnRemoveArcs.Name = "btnRemoveArcs";
            this.btnRemoveArcs.Size = new System.Drawing.Size(96, 23);
            this.btnRemoveArcs.TabIndex = 10;
            this.btnRemoveArcs.Text = "Limpar Arcos";
            this.btnRemoveArcs.UseVisualStyleBackColor = true;
            this.btnRemoveArcs.Click += new System.EventHandler(this.btnRemoveArcs_Click);
            // 
            // lstArcs
            // 
            this.lstArcs.FormattingEnabled = true;
            this.lstArcs.Location = new System.Drawing.Point(47, 82);
            this.lstArcs.Name = "lstArcs";
            this.lstArcs.Size = new System.Drawing.Size(251, 121);
            this.lstArcs.TabIndex = 9;
            // 
            // lblEdge
            // 
            this.lblEdge.AutoSize = true;
            this.lblEdge.Location = new System.Drawing.Point(4, 58);
            this.lblEdge.Name = "lblEdge";
            this.lblEdge.Size = new System.Drawing.Size(40, 13);
            this.lblEdge.TabIndex = 6;
            this.lblEdge.Text = "Aresta:";
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(122, 19);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(85, 23);
            this.btnAddNode.TabIndex = 2;
            this.btnAddNode.Text = "Criar Grafo";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnCreateGraph_Click);
            // 
            // gbOperations
            // 
            this.gbOperations.Controls.Add(this.btnShowPath);
            this.gbOperations.Controls.Add(this.txtPath);
            this.gbOperations.Controls.Add(this.lblPath);
            this.gbOperations.Controls.Add(this.btnShowNeighbours);
            this.gbOperations.Controls.Add(this.cmbNodeNeighbourhood);
            this.gbOperations.Controls.Add(this.lblNoodeNeighbourhood);
            this.gbOperations.Location = new System.Drawing.Point(12, 255);
            this.gbOperations.Name = "gbOperations";
            this.gbOperations.Size = new System.Drawing.Size(304, 130);
            this.gbOperations.TabIndex = 2;
            this.gbOperations.TabStop = false;
            this.gbOperations.Text = "Operações";
            // 
            // btnShowPath
            // 
            this.btnShowPath.Location = new System.Drawing.Point(202, 86);
            this.btnShowPath.Name = "btnShowPath";
            this.btnShowPath.Size = new System.Drawing.Size(96, 23);
            this.btnShowPath.TabIndex = 15;
            this.btnShowPath.Text = "Validar Caminho";
            this.btnShowPath.UseVisualStyleBackColor = true;
            this.btnShowPath.Click += new System.EventHandler(this.btnShowPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(47, 60);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(251, 20);
            this.txtPath.TabIndex = 14;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 63);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(29, 13);
            this.lblPath.TabIndex = 13;
            this.lblPath.Text = "Nós:";
            // 
            // btnShowNeighbours
            // 
            this.btnShowNeighbours.Location = new System.Drawing.Point(122, 24);
            this.btnShowNeighbours.Name = "btnShowNeighbours";
            this.btnShowNeighbours.Size = new System.Drawing.Size(176, 23);
            this.btnShowNeighbours.TabIndex = 12;
            this.btnShowNeighbours.Text = "Mostrar Vizinhos";
            this.btnShowNeighbours.UseVisualStyleBackColor = true;
            this.btnShowNeighbours.Click += new System.EventHandler(this.btnShowNeighbours_Click);
            // 
            // cmbNodeNeighbourhood
            // 
            this.cmbNodeNeighbourhood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeNeighbourhood.FormattingEnabled = true;
            this.cmbNodeNeighbourhood.Location = new System.Drawing.Point(47, 25);
            this.cmbNodeNeighbourhood.Name = "cmbNodeNeighbourhood";
            this.cmbNodeNeighbourhood.Size = new System.Drawing.Size(69, 21);
            this.cmbNodeNeighbourhood.TabIndex = 11;
            // 
            // lblNoodeNeighbourhood
            // 
            this.lblNoodeNeighbourhood.AutoSize = true;
            this.lblNoodeNeighbourhood.Location = new System.Drawing.Point(17, 28);
            this.lblNoodeNeighbourhood.Name = "lblNoodeNeighbourhood";
            this.lblNoodeNeighbourhood.Size = new System.Drawing.Size(24, 13);
            this.lblNoodeNeighbourhood.TabIndex = 0;
            this.lblNoodeNeighbourhood.Text = "Nó:";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 400);
            this.Controls.Add(this.gbOperations);
            this.Controls.Add(this.gbGraph);
            this.Controls.Add(this.pnlGraph);
            this.Name = "Principal";
            this.Text = "Grafos";
            this.gbGraph.ResumeLayout(false);
            this.gbGraph.PerformLayout();
            this.gbOperations.ResumeLayout(false);
            this.gbOperations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGraph;
        private System.Windows.Forms.GroupBox gbGraph;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Label lblEdge;
        private System.Windows.Forms.Button btnRemoveArcs;
        private System.Windows.Forms.ListBox lstArcs;
        private System.Windows.Forms.GroupBox gbOperations;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnShowNeighbours;
        private System.Windows.Forms.ComboBox cmbNodeNeighbourhood;
        private System.Windows.Forms.Label lblNoodeNeighbourhood;
        private System.Windows.Forms.Button btnShowPath;
        private System.Windows.Forms.Button button1;
    }
}

