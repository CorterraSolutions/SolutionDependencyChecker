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
            this.SolutionComponents_ListView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Solutions_Combobox = new System.Windows.Forms.ComboBox();
            this.OpenSolution_Computer = new System.Windows.Forms.GroupBox();
            this.LoadSolution_Button = new System.Windows.Forms.Button();
            this.OpenSolution = new System.Windows.Forms.OpenFileDialog();
            this.txt_Source_ConnectionString = new System.Windows.Forms.TextBox();
            this.btn_ConnectSource = new System.Windows.Forms.Button();
            this.OpenSolution_xRM = new System.Windows.Forms.GroupBox();
            this.smallPluginLabel1 = new System.Windows.Forms.Label();
            this.txt_OutputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.output_txt = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.OpenSolution_Computer.SuspendLayout();
            this.OpenSolution_xRM.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoLabel
            // 
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(207, 22);
            this.InfoLabel.Text = "Missing Components in enviornment:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.toolStrip2.Size = new System.Drawing.Size(584, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
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
            this.SolutionComponents_ListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SolutionComponents_ListView.FullRowSelect = true;
            this.SolutionComponents_ListView.GridLines = true;
            this.SolutionComponents_ListView.LabelWrap = false;
            this.SolutionComponents_ListView.LargeImageList = this.ComonentIcons;
            this.SolutionComponents_ListView.Location = new System.Drawing.Point(4, 23);
            this.SolutionComponents_ListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SolutionComponents_ListView.Name = "SolutionComponents_ListView";
            this.SolutionComponents_ListView.Size = new System.Drawing.Size(574, 237);
            this.SolutionComponents_ListView.SmallImageList = this.ComonentIcons;
            this.SolutionComponents_ListView.TabIndex = 1;
            this.SolutionComponents_ListView.UseCompatibleStateImageBehavior = false;
            this.SolutionComponents_ListView.View = System.Windows.Forms.View.List;
            this.SolutionComponents_ListView.SelectedIndexChanged += new System.EventHandler(this.SolutionComponents_ListView_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.SolutionComponents_ListView);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Location = new System.Drawing.Point(12, 271);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 266);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // Solutions_Combobox
            // 
            this.Solutions_Combobox.FormattingEnabled = true;
            this.Solutions_Combobox.Location = new System.Drawing.Point(120, 48);
            this.Solutions_Combobox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Solutions_Combobox.Name = "Solutions_Combobox";
            this.Solutions_Combobox.Size = new System.Drawing.Size(258, 21);
            this.Solutions_Combobox.TabIndex = 3;
            this.Solutions_Combobox.SelectedIndexChanged += new System.EventHandler(this.Solutions_Combobox_SelectedIndexChanged);
            // 
            // OpenSolution_Computer
            // 
            this.OpenSolution_Computer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSolution_Computer.Controls.Add(this.LoadSolution_Button);
            this.OpenSolution_Computer.Location = new System.Drawing.Point(12, 41);
            this.OpenSolution_Computer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenSolution_Computer.Name = "OpenSolution_Computer";
            this.OpenSolution_Computer.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenSolution_Computer.Size = new System.Drawing.Size(584, 56);
            this.OpenSolution_Computer.TabIndex = 11;
            this.OpenSolution_Computer.TabStop = false;
            this.OpenSolution_Computer.Text = "Open a solution from your computer (Must be a .zip file exported from xRM)";
            // 
            // LoadSolution_Button
            // 
            this.LoadSolution_Button.Location = new System.Drawing.Point(4, 27);
            this.LoadSolution_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadSolution_Button.Name = "LoadSolution_Button";
            this.LoadSolution_Button.Size = new System.Drawing.Size(100, 25);
            this.LoadSolution_Button.TabIndex = 1;
            this.LoadSolution_Button.Text = "Open Solution...";
            this.LoadSolution_Button.UseVisualStyleBackColor = true;
            this.LoadSolution_Button.Click += new System.EventHandler(this.LoadSolution_Button_Click);
            // 
            // OpenSolution
            // 
            this.OpenSolution.FileName = "OpenSolution";
            // 
            // txt_Source_ConnectionString
            // 
            this.txt_Source_ConnectionString.Location = new System.Drawing.Point(96, 22);
            this.txt_Source_ConnectionString.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Source_ConnectionString.Name = "txt_Source_ConnectionString";
            this.txt_Source_ConnectionString.Size = new System.Drawing.Size(374, 20);
            this.txt_Source_ConnectionString.TabIndex = 15;
            // 
            // btn_ConnectSource
            // 
            this.btn_ConnectSource.Location = new System.Drawing.Point(4, 45);
            this.btn_ConnectSource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ConnectSource.Name = "btn_ConnectSource";
            this.btn_ConnectSource.Size = new System.Drawing.Size(112, 22);
            this.btn_ConnectSource.TabIndex = 16;
            this.btn_ConnectSource.Text = "Connect to Source";
            this.btn_ConnectSource.UseVisualStyleBackColor = true;
            this.btn_ConnectSource.Click += new System.EventHandler(this.btn_ConnectSource_Click);
            // 
            // OpenSolution_xRM
            // 
            this.OpenSolution_xRM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenSolution_xRM.Controls.Add(this.smallPluginLabel1);
            this.OpenSolution_xRM.Controls.Add(this.btn_ConnectSource);
            this.OpenSolution_xRM.Controls.Add(this.txt_Source_ConnectionString);
            this.OpenSolution_xRM.Controls.Add(this.Solutions_Combobox);
            this.OpenSolution_xRM.Location = new System.Drawing.Point(12, 109);
            this.OpenSolution_xRM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenSolution_xRM.Name = "OpenSolution_xRM";
            this.OpenSolution_xRM.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenSolution_xRM.Size = new System.Drawing.Size(584, 83);
            this.OpenSolution_xRM.TabIndex = 17;
            this.OpenSolution_xRM.TabStop = false;
            this.OpenSolution_xRM.Text = "Open a solution from source xRM";
            // 
            // smallPluginLabel1
            // 
            this.smallPluginLabel1.AutoSize = true;
            this.smallPluginLabel1.Location = new System.Drawing.Point(2, 22);
            this.smallPluginLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.smallPluginLabel1.Name = "smallPluginLabel1";
            this.smallPluginLabel1.Size = new System.Drawing.Size(91, 13);
            this.smallPluginLabel1.TabIndex = 22;
            this.smallPluginLabel1.Text = "Connection String";
            // 
            // txt_OutputPath
            // 
            this.txt_OutputPath.Location = new System.Drawing.Point(70, 11);
            this.txt_OutputPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_OutputPath.Name = "txt_OutputPath";
            this.txt_OutputPath.Size = new System.Drawing.Size(520, 20);
            this.txt_OutputPath.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Output To";
            // 
            // output_txt
            // 
            this.output_txt.AutoSize = true;
            this.output_txt.Location = new System.Drawing.Point(12, 198);
            this.output_txt.Name = "output_txt";
            this.output_txt.Size = new System.Drawing.Size(0, 13);
            this.output_txt.TabIndex = 25;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.output_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_OutputPath);
            this.Controls.Add(this.OpenSolution_xRM);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenSolution_Computer);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1042, 562);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.OpenSolution_Computer.ResumeLayout(false);
            this.OpenSolution_xRM.ResumeLayout(false);
            this.OpenSolution_xRM.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BackgroundProgressIndicator;
        private System.Windows.Forms.ToolStripLabel InfoLabel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ImageList ComonentIcons;
        private System.Windows.Forms.ListView SolutionComponents_ListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Solutions_Combobox;
        private System.Windows.Forms.GroupBox OpenSolution_Computer;
        private System.Windows.Forms.Button LoadSolution_Button;
        private System.Windows.Forms.OpenFileDialog OpenSolution;
        private System.Windows.Forms.TextBox txt_Source_ConnectionString;
        private System.Windows.Forms.Button btn_ConnectSource;
        private System.Windows.Forms.GroupBox OpenSolution_xRM;
        private System.Windows.Forms.Label smallPluginLabel1;
        private System.Windows.Forms.TextBox txt_OutputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label output_txt;
    }
}
