using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using System.IO;
using Microsoft.Crm.Sdk.Messages;
using System.Runtime.InteropServices;
using Microsoft.Xrm.Tooling.Connector;

namespace XRMSolutionDependencyChecker
{
    public partial class PluginControl : PluginControlBase
    {
        private Settings mySettings;
        private IOrganizationService sourceEnviornment;
        private Dictionary<int, Entity> sourceSolutions = new Dictionary<int, Entity>();
        private Dictionary<int, string> TypeIcon_Dictionary =
            new Dictionary<int, string>()
            {
                { 1, "Entity" },
                { 2, "Field" },
                { 3, "Relationship" },
                { 4, "Attribute Picklist Value" },
                { 5, "Attribute Lookup Value" },
                { 6, "View Attribute" },
                { 7, "Localized Label" },
                { 8, "Relationship Extra Condition" },
                { 9, "Option Set" },
                { 10, "Entity Relationship" },
                { 11, "Entity Relationship Role" },
                { 12, "Entity Relationship Relationships" },
                { 13, "Managed Property" },
                { 14, "Entity Key" },
                { 16, "Privilege" },
                { 17, "PrivilegeObjectTypeCode" },
                { 18, "Index" },
                { 20, "Role" },
                { 21, "Role Privilege" },
                { 22, "Display String" },
                { 23, "Display String Map" },
                { 24, "Form" },
                { 25, "Organization" },
                { 26, "View" },
                { 29, "Dialog/Workflow" },
                { 31, "Report" },
                { 32, "Report Entity" },
                { 33, "Report Category" },
                { 34, "Report Visibility" },
                { 35, "Attachment" },
                { 36, "Email Template" },
                { 37, "Contract Template" },
                { 38, "KB Article Template" },
                { 39, "Mail Merge Template" },
                { 44, "Duplicate Rule" },
                { 45, "Duplicate Rule Condition" },
                { 46, "Entity Map" },
                { 47, "Attribute Map" },
                { 48, "Ribbon Command" },
                { 49, "Ribbon Context Group" },
                { 50, "Ribbon Customization" },
                { 52, "Ribbon Rule" },
                { 53, "Ribbon Tab To Command Map" },
                { 55, "Ribbon Diff" },
                { 59, "Chart" },
                { 60, "View" },
                { 61, "Web Resource" },
                { 62, "Site Map" },
                { 63, "Connection Role" },
                { 64, "Complex Control" },
                { 65, "Hierachy Rule" },
                { 66, "Custom Control" },
                { 68, "Custom Control Default Config" },
                { 70, "Field Security Profile" },
                { 71, "Field Permission" },
                { 90, "Plugin Type"},
                { 91, "Plugin Assembly" },
                { 92, "SDK Message Processing Step" },
                { 93, "SDK Message Processing Step Image" },
                { 95, "Service Endpoint" },

            };

        public PluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            txt_OutputPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void LoadSolution_Button_Click(object sender, EventArgs e)
        {
            OpenSolution.ShowDialog();

            if (OpenSolution.SafeFileName == "OpenSolution")
                return;

            //if (ProgressPanel.Visible != true)
            //    this.Height = this.Height + ProgressPanel.Height;

            //ProgressPanel.Visible = true;

            //Progress_Label.Text = $"Opening...{OpenSolution.FileName + Environment.NewLine}";
            //Progress_Label.Refresh();

            byte[] SolutionFile = File.ReadAllBytes(OpenSolution.FileName);

            BackgroundProgressIndicator.RunWorkerAsync(SolutionFile);

            string Status = ShowMissingComponents(SolutionFile);

            if (Status == "Succeeded")
                output_txt.Text = $@"Found missing dependencies in target enviornment... {Environment.NewLine}{OpenSolution.FileName}. {Environment.NewLine}Output available at: {txt_OutputPath.Text}\dependencies.csv";
            else if (Status == "No Missing Components")
                output_txt.Text = $"There were no missing components in {Environment.NewLine + OpenSolution.SafeFileName}";
            else
                output_txt.Text = Status;
        }

        public string ShowMissingComponents(byte[] ExportedSolution)
        {
            try
            {
                SolutionComponents_ListView.Items.Clear();

                RetrieveMissingComponentsRequest GetMissingComponents_Request = new RetrieveMissingComponentsRequest
                {
                    CustomizationFile = ExportedSolution
                };

                RetrieveMissingComponentsResponse GetMissingComponents = (RetrieveMissingComponentsResponse)base.Service.Execute(GetMissingComponents_Request);

                if (GetMissingComponents.MissingComponents.Count() == 0)
                {
                    panel1.Visible = false;
                    return "No Missing Components";
                }
                    
                // Create csv string builder
                var csv = new StringBuilder();

                // Set headers on file
                csv.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                    "Dependent Component Type",
                    "Dependent Component Display Name",
                    "Dependent Component Schema Name",
                    "Dependent Component ID",
                    "Required Component Type",
                    "Required Component Display Name",
                    "Required Component Schema Name",
                    "Required Component ID"
                ));

                // loop
                foreach (MissingComponent MissingComponent in GetMissingComponents.MissingComponents)
                {
                    ListViewItem MissingComponent_ListViewItem = new ListViewItem(
                        (string.IsNullOrEmpty(MissingComponent.RequiredComponent.ParentDisplayName) ? "" : MissingComponent.RequiredComponent.ParentDisplayName + " (" + MissingComponent.RequiredComponent.ParentSchemaName + ") | ")
                         + (TypeIcon_Dictionary.ContainsKey(MissingComponent.RequiredComponent.Type) ? TypeIcon_Dictionary[MissingComponent.RequiredComponent.Type] : "Type Code: " + MissingComponent.RequiredComponent.Type.ToString())
                        + " | " + MissingComponent.RequiredComponent.DisplayName + " | " + MissingComponent.RequiredComponent.SchemaName
                    );

                    SolutionComponents_ListView.Items.Add(MissingComponent_ListViewItem);

                    csv.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                        $"{(TypeIcon_Dictionary.ContainsKey(MissingComponent.DependentComponent.Type) ? TypeIcon_Dictionary[MissingComponent.DependentComponent.Type] : "Type Code: " + MissingComponent.DependentComponent.Type.ToString())}",
                        $"{MissingComponent.DependentComponent.DisplayName}",
                        $"{MissingComponent.DependentComponent.SchemaName}",
                        $"{MissingComponent.DependentComponent.Id}",
                        $"{(TypeIcon_Dictionary.ContainsKey(MissingComponent.RequiredComponent.Type) ? TypeIcon_Dictionary[MissingComponent.RequiredComponent.Type] : "Type Code: " + MissingComponent.RequiredComponent.Type.ToString())}",
                        $"{MissingComponent.RequiredComponent.DisplayName}",
                        $"{MissingComponent.RequiredComponent.SchemaName}",
                        $"{MissingComponent.RequiredComponent.Id}"
                    ));
                }

                // write csv file
                File.WriteAllText($@"{txt_OutputPath.Text}\dependencies.csv", csv.ToString());

                if (panel1.Visible != true)
                    this.Height = this.Height + panel1.Height;

                panel1.Visible = true;

                return "Succeeded";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public string GetTypeIcon(int type)
        {
            if (TypeIcon_Dictionary.ContainsKey(type))
                return TypeIcon_Dictionary[type];
            else
                return "default";
        }

        private void SolutionComponents_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OpenSolution_Computer_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}