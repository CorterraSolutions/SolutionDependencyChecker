using System.Windows.Forms;

namespace XRMSolutionDependencyChecker
{
    partial class PluginControl 
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginControl));
            this.BackgroundProgressIndicator = new System.ComponentModel.BackgroundWorker();
            this.InfoLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ComonentIcons = new System.Windows.Forms.ImageList(this.components);
            //this.SolutionComponents_ListView = new System.Windows.Forms.ListView();
            this.SolutionComponents_DataGrid = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenSolution_Computer = new System.Windows.Forms.GroupBox();
            this.LoadSolution_Button = new System.Windows.Forms.Button();
            this.OpenSolution = new System.Windows.Forms.OpenFileDialog();
            this.txt_OutputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.output_txt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.OpenSolution_Computer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComonentIcons
            // 
            this.ComonentIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ComonentIcons.ImageStream")));
            this.ComonentIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ComonentIcons.Images.SetKeyName(0, "Entity");
            this.ComonentIcons.Images.SetKeyName(1, "BussinessRule");
            this.ComonentIcons.Images.SetKeyName(2, "SLA");
            this.ComonentIcons.Images.SetKeyName(3, "PlugIn");
            this.ComonentIcons.Images.SetKeyName(4, "Process");
            this.ComonentIcons.Images.SetKeyName(5, "Workflow");
            this.ComonentIcons.Images.SetKeyName(6, "default");
            this.ComonentIcons.Images.SetKeyName(7, "LoadingIcon");
            // 
            // SolutionComponents_ListView
            // 
            //this.SolutionComponents_ListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            //| System.Windows.Forms.AnchorStyles.Right)));
            //this.SolutionComponents_ListView.FullRowSelect = true;
            //this.SolutionComponents_ListView.GridLines = true;
            //this.SolutionComponents_ListView.LabelWrap = false;
            //this.SolutionComponents_ListView.LargeImageList = this.ComonentIcons;
            //this.SolutionComponents_ListView.Location = new System.Drawing.Point(8, 44);
            //this.SolutionComponents_ListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            //this.SolutionComponents_ListView.Name = "SolutionComponents_ListView";
            //this.SolutionComponents_ListView.Size = new System.Drawing.Size(1916, 550);
            //this.SolutionComponents_ListView.SmallImageList = this.ComonentIcons;
            //this.SolutionComponents_ListView.TabIndex = 2;
            //this.SolutionComponents_ListView.UseCompatibleStateImageBehavior = false;
            //this.SolutionComponents_ListView.View = System.Windows.Forms.View.List;
            //this.SolutionComponents_ListView.SelectedIndexChanged += new System.EventHandler(this.SolutionComponents_ListView_SelectedIndexChanged);
            // 
            // output_txt
            // 
            this.output_txt.AutoSize = true;
            this.output_txt.Location = new System.Drawing.Point(24, 410);
            this.output_txt.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.output_txt.Name = "output_txt";
            this.output_txt.Size = new System.Drawing.Size(200, 90);
            this.output_txt.TabIndex = 25;
            // 
            // InfoLabel
            // 
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(417, 32);
            this.InfoLabel.Text = "Missing Components in enviornment:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Size = new System.Drawing.Size(1908, 35);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            //
            // SolutionComponents_DataGrid
            //
            this.SolutionComponents_DataGrid.PreferredColumnWidth = 200;
            this.SolutionComponents_DataGrid.Name = "SolutionComponents_GridView";
            this.SolutionComponents_DataGrid.ReadOnly = true;
            this.SolutionComponents_DataGrid.Location = new System.Drawing.Point(24, 40);
            this.SolutionComponents_DataGrid.Size = new System.Drawing.Size(3320, 1000);
            this.SolutionComponents_DataGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.panel1.Controls.Add(this.SolutionComponents_ListView);
            this.panel1.Controls.Add(this.SolutionComponents_DataGrid);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(24, this.output_txt.Height + this.output_txt.Location.Y);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1940, 1080);
            this.panel1.MinimumSize = new System.Drawing.Size(1940, 1080);
            this.panel1.AutoScroll = true;
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // OpenSolution_Computer
            // 
            this.OpenSolution_Computer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSolution_Computer.Controls.Add(this.LoadSolution_Button);
            this.OpenSolution_Computer.Location = new System.Drawing.Point(24, 222);
            this.OpenSolution_Computer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OpenSolution_Computer.Name = "OpenSolution_Computer";
            this.OpenSolution_Computer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OpenSolution_Computer.Size = new System.Drawing.Size(1170, 110);
            this.OpenSolution_Computer.MinimumSize = new System.Drawing.Size(1170, 110);
            this.OpenSolution_Computer.TabIndex = 11;
            this.OpenSolution_Computer.TabStop = false;
            this.OpenSolution_Computer.Text = "Open a solution from your computer (Must be a .zip file exported from xRM)";
            this.OpenSolution_Computer.Enter += new System.EventHandler(this.OpenSolution_Computer_Enter);
            // 
            // LoadSolution_Button
            // 
            this.LoadSolution_Button.Location = new System.Drawing.Point(8, 32);
            this.LoadSolution_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadSolution_Button.Name = "LoadSolution_Button";
            this.LoadSolution_Button.Size = new System.Drawing.Size(200, 58);
            this.LoadSolution_Button.TabIndex = 1;
            this.LoadSolution_Button.Text = "Open Solution...";
            this.LoadSolution_Button.UseVisualStyleBackColor = true;
            this.LoadSolution_Button.Click += new System.EventHandler(this.LoadSolution_Button_Click);
            // 
            // OpenSolution
            // 
            this.OpenSolution.FileName = "OpenSolution";
            // 
            // txt_OutputPath
            // 
            this.txt_OutputPath.Location = new System.Drawing.Point(134, 358);
            this.txt_OutputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_OutputPath.Name = "txt_OutputPath";
            this.txt_OutputPath.Size = new System.Drawing.Size(1036, 31);
            this.txt_OutputPath.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 362);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Output To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(870, 61);
            this.label2.TabIndex = 27;
            this.label2.Text = "XRM Solution Dependency Checker";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 76);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1274, 107);
            this.textBox1.TabIndex = 28;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_OutputPath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenSolution_Computer);
            //this.Controls.Add(this.toolStrip2);
            //this.Controls.Add(this.SolutionComponents_DataGrid);
            this.AutoScroll = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(2084, 1081);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.OpenSolution_Computer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BackgroundProgressIndicator;
        private System.Windows.Forms.ToolStripLabel InfoLabel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ImageList ComonentIcons;
        //private System.Windows.Forms.ListView SolutionComponents_ListView;
        private System.Windows.Forms.DataGrid SolutionComponents_DataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox OpenSolution_Computer;
        private System.Windows.Forms.Button LoadSolution_Button;
        private System.Windows.Forms.OpenFileDialog OpenSolution;
        private System.Windows.Forms.TextBox txt_OutputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label output_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
