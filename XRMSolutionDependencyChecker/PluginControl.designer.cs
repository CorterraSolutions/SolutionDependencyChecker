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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackgroundProgressIndicator = new System.ComponentModel.BackgroundWorker();
            this.ComonentIcons = new System.Windows.Forms.ImageList(this.components);
            this.output_txt = new System.Windows.Forms.Label();
            this.OpenSolution_Computer = new System.Windows.Forms.GroupBox();
            this.LoadSolution_Button = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.OpenSolution = new System.Windows.Forms.OpenFileDialog();
            this.txt_OutputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.InfoLabel = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SolutionComponents_DataGridView = new System.Windows.Forms.DataGridView();
            this.OpenSolution_Computer.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionComponents_DataGridView)).BeginInit();
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
            // output_txt
            // 
            this.output_txt.Location = new System.Drawing.Point(20, 379);
            this.output_txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.output_txt.Name = "output_txt";
            this.output_txt.Size = new System.Drawing.Size(0, 20);
            this.output_txt.TabIndex = 25;
            // 
            // OpenSolution_Computer
            // 
            this.OpenSolution_Computer.Controls.Add(this.LoadSolution_Button);
            this.OpenSolution_Computer.Controls.Add(this.checkBox1);
            this.OpenSolution_Computer.Controls.Add(this.checkBox2);
            this.OpenSolution_Computer.Location = new System.Drawing.Point(18, 188);
            this.OpenSolution_Computer.MinimumSize = new System.Drawing.Size(878, 88);
            this.OpenSolution_Computer.Name = "OpenSolution_Computer";
            this.OpenSolution_Computer.Size = new System.Drawing.Size(962, 88);
            this.OpenSolution_Computer.TabIndex = 11;
            this.OpenSolution_Computer.TabStop = false;
            this.OpenSolution_Computer.Text = "Open a solution from your computer (Must be a .zip file)";
            this.OpenSolution_Computer.Enter += new System.EventHandler(this.OpenSolution_Computer_Enter);
            // 
            // LoadSolution_Button
            // 
            this.LoadSolution_Button.ForeColor = System.Drawing.Color.Black;
            this.LoadSolution_Button.Location = new System.Drawing.Point(6, 26);
            this.LoadSolution_Button.Name = "LoadSolution_Button";
            this.LoadSolution_Button.Size = new System.Drawing.Size(150, 46);
            this.LoadSolution_Button.TabIndex = 1;
            this.LoadSolution_Button.Text = "Open Solution...";
            this.LoadSolution_Button.UseVisualStyleBackColor = true;
            this.LoadSolution_Button.Click += new System.EventHandler(this.LoadSolution_Button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(180, 26);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(188, 46);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Show Dependent Component";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(368, 26);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(188, 46);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Show Parent Component";
            // 
            // OpenSolution
            // 
            this.OpenSolution.FileName = "OpenSolution";
            // 
            // txt_OutputPath
            // 
            this.txt_OutputPath.Location = new System.Drawing.Point(100, 298);
            this.txt_OutputPath.Name = "txt_OutputPath";
            this.txt_OutputPath.Size = new System.Drawing.Size(778, 26);
            this.txt_OutputPath.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Output To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(561, 46);
            this.label2.TabIndex = 27;
            this.label2.Text = "Solution Dependency Checker";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 71);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(956, 99);
            this.textBox1.TabIndex = 28;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(1650, 38);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(309, 33);
            this.InfoLabel.Text = "Missing Components in environment:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.SolutionComponents_DataGridView);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(18, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1650, 393);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // SolutionComponents_DataGridView
            // 
            this.SolutionComponents_DataGridView.AllowUserToAddRows = false;
            this.SolutionComponents_DataGridView.AllowUserToDeleteRows = false;
            this.SolutionComponents_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SolutionComponents_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SolutionComponents_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SolutionComponents_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SolutionComponents_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SolutionComponents_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.SolutionComponents_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SolutionComponents_DataGridView.EnableHeadersVisualStyles = false;
            this.SolutionComponents_DataGridView.GridColor = System.Drawing.Color.DarkGray;
            this.SolutionComponents_DataGridView.Location = new System.Drawing.Point(0, 38);
            this.SolutionComponents_DataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.SolutionComponents_DataGridView.Name = "SolutionComponents_DataGridView";
            this.SolutionComponents_DataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SolutionComponents_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SolutionComponents_DataGridView.RowHeadersWidth = 30;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.SolutionComponents_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.SolutionComponents_DataGridView.RowTemplate.Height = 28;
            this.SolutionComponents_DataGridView.Size = new System.Drawing.Size(1650, 355);
            this.SolutionComponents_DataGridView.TabIndex = 2;
            this.SolutionComponents_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // PluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.output_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_OutputPath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenSolution_Computer);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PluginControl";
            this.Size = new System.Drawing.Size(1671, 775);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.OpenSolution_Computer.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionComponents_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BackgroundProgressIndicator;
        private System.Windows.Forms.ImageList ComonentIcons;
        private System.Windows.Forms.GroupBox OpenSolution_Computer;
        private System.Windows.Forms.Button LoadSolution_Button;
        private System.Windows.Forms.OpenFileDialog OpenSolution;
        private System.Windows.Forms.TextBox txt_OutputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label output_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private ToolStrip toolStrip2;
        private ToolStripLabel InfoLabel;
        private Panel panel1;
        private DataGridView SolutionComponents_DataGridView;
    }
}
