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
                { 10, "Relationship" },
                { 20, "Role" },
                { 26, "View" },
                { 29, "Dialog/Workflow" },
                { 59, "Chart" },
                { 60, "View" },
                { 61, "Web Resource" },
                { 90, "DLL Assembly"}
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
                    return "No Missing Components";

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
                        (TypeIcon_Dictionary.ContainsKey(MissingComponent.RequiredComponent.Type) ? TypeIcon_Dictionary[MissingComponent.RequiredComponent.Type] : "Type Code: " + MissingComponent.RequiredComponent.Type.ToString())
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

        private void btn_ConnectSource_Click(object sender, EventArgs e)
        {
            string connectionString = txt_Source_ConnectionString.Text;
            sourceEnviornment = new CrmServiceClient(connectionString);

            // Populate solutions in drop down
            string Query_Solutions = 
                @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                    <entity name='solution'>
                        <attribute name='friendlyname'/>
                        <attribute name='createdon'/>
                        <attribute name='solutionid'/>
                        <attribute name='uniquename'/>
                        <order attribute='createdon' descending='true'/>
                        <filter type='and'>
                            <condition attribute='isvisible' operator='eq' value='1' />
                        </filter>
                    </entity>
                </fetch>";
            EntityCollection Solutions = sourceEnviornment.RetrieveMultiple(new FetchExpression(Query_Solutions));

            Solutions_Combobox.Text = "Solutions from source enviornment";
            Solutions_Combobox.Refresh();

            Solutions_Combobox.Items.Clear();

            List<Entity> orderedEntities = Solutions.Entities.OrderBy(x => x.Attributes["friendlyname"]).ToList(); // sorts elements in ascending order depending on friendly name

            sourceSolutions.Clear();
            for (int i = 0; i < orderedEntities.Count; i++)
            {
                Solutions_Combobox.Items.Add((string)orderedEntities[i]["friendlyname"]);
                sourceSolutions.Add(i, orderedEntities[i]);
            }

            Solutions_Combobox.DropDownWidth = OpenSolution_xRM.Width;
        }

        private void Solutions_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ProgressPanel.Visible != true)
            //    this.Height = this.Height + ProgressPanel.Height;

            //ProgressPanel.Visible = true;

            int SelectedIndex = Solutions_Combobox.SelectedIndex;
            string SolutionName = (string)sourceSolutions[SelectedIndex]["uniquename"];
            Guid SolutionId = (Guid)sourceSolutions[SelectedIndex]["solutionid"];

            ExportSolutionRequest ExportSolution_Request = new ExportSolutionRequest
            {
                Managed = false,
                SolutionName = SolutionName
            };
            ExportSolutionResponse ExportedSolution = (ExportSolutionResponse)sourceEnviornment.Execute(ExportSolution_Request);

            string Status = ShowMissingComponents(ExportedSolution.ExportSolutionFile);

            if (Status == "Succeeded")
                output_txt.Text = $@"Found missing dependencies in target enviornment...{Environment.NewLine}{SolutionName}. {Environment.NewLine}Output available at: {txt_OutputPath.Text}\dependencies.csv";
            else if (Status == "No Missing Components")
                output_txt.Text = "There were no missing components in the target enviornment" + Environment.NewLine + SolutionName;
            else
                output_txt.Text = Status;
        }

        private void SolutionComponents_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}