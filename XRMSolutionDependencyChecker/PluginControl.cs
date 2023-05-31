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
using System.IO.Compression;
using Microsoft.Crm.Sdk.Messages;
using System.Runtime.InteropServices;
using Microsoft.Xrm.Tooling.Connector;
using XrmToolBox.Extensibility.Args;
using System.Xml;
using System.Windows.Controls;
using System.Web.Services.Description;

namespace XRMSolutionDependencyChecker
{
    public partial class PluginControl : PluginControlBase
    {
        private const string loadMessage = "Checking for dependencies...";
        private Settings mySettings;
        private readonly Dictionary<int, string> TypeIcon_Dictionary =
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
                { 150, "Routing Rule" },
                { 151, "Routing Rule Item" },
                { 152, "SLA" },
                { 153, "SLA Item" },
                { 154, "Convert Rule"},
                { 155, "Convert Rule Item" },
                { 161, "Mobile Offline Profile" },
                { 162, "Mobile Offline Profile Item" },
                { 165, "Similarity Rule" },
                { 166, "Data Source Mapping"},
                { 201, "SDKMessage" },
                { 202, "SDKMessageFilter" },
                { 203, "SdkMessagePair" },
                { 204, "SdkMessageRequest" },
                { 205, "SdkMessageRequestField" },
                { 206, "SdkMessageResponse" },
                { 207, "SdkMessageResponseField" },
                { 208, "Import Map" },
                { 210, "WebWizard" },
                { 300, "Canvas App" },
                { 371, "Connector" },
                { 372, "Connector" },
                { 380, "Environment Variable Definition" },
                { 381, "Environment Variable Value" },
                { 400, "AI Project Type" },
                { 401, "AI Project" },
                { 402, "AI Configuration" },
                { 430, "Entity Analytics Configuration" },
                { 431, "Attribute Image Configuration" },
                { 432, "Entity Image Configuration" }

            };
        /// <summary>
        /// Initialize component
        /// </summary>
        public PluginControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load settings and initial plugin components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            LogInfo("=====START NEW EXECUTION=====");
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

            mcDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;

            PerformAutoScale();
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

        /// <summary>
        /// On click of the Open Solution button, load a file explorer dialog. 
        /// Once the file is selected, store in a byte array and check for errors
        /// Finally check for solution dependencies, the main purpose of the plugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSolution_Button_Click(object sender, EventArgs e)
        {
            outputText.Visible = true;
            outputText.Text = "";
            mcPanel.Visible = false;
            mcDataGridView.Rows.Clear(); //clear grid if button clicked to load solution

            byte[] SolutionFile = null;

            OpenSolution.ShowDialog();

            //Check if a file was set or if dialog was simply closed, if closed, return
            if (OpenSolution.SafeFileName == "OpenSolution")
            {
                return;
            }

            // If file isn't a zip, stop here
            if (!OpenSolution.SafeFileName.Contains(".zip"))
            {
                outputText.Text = "Error: Expected solution is not a .zip"+Environment.NewLine;
                return;
            }

            //Get version of solution loaded
            string fileVersion=solutionVersion(OpenSolution.FileName);
            LogInfo("File Version: " + fileVersion);
            string connectionVersion = targetVersion();
            LogInfo("Connection Version: "+connectionVersion);


            if (parseVersion(fileVersion)>parseVersion(connectionVersion))
            {
                outputText.Text += "Solution loaded is a version greater than the target connection. Unable to determine missing components" + Environment.NewLine;
                outputText.Text += "Solution Version: " +fileVersion+ Environment.NewLine;
                outputText.Text += "Connection Version: "+connectionVersion + Environment.NewLine;
                return;
            }


            WorkAsync(new WorkAsyncInfo
            {
                Message = loadMessage,
                IsCancelable = true,
                Work = (worker, eventargs) =>
                {
                    object missingComponents;
                    try
                    {
                        SolutionFile = File.ReadAllBytes(OpenSolution.FileName);
                        missingComponents = CheckMissingComponent(SolutionFile);
                    }
                    catch (Exception mcExcept)
                    {
                        outputText.Text += "Failed to read solution, check solution is valid." + Environment.NewLine + "Exception:"+Environment.NewLine+mcExcept.ToString() + Environment.NewLine; ;
                        return;
                    }

                    eventargs.Result = missingComponents;
                },
                PostWorkCallBack = eventargs =>
                {
                    string Status;

                    //Check if empty object then return
                    if (eventargs.Result.GetType()!=typeof(MissingComponent[]))
                    {
                        outputText.Text += "Unable to find missing components."+Environment.NewLine+"Result:"+Environment.NewLine+eventargs.Result.ToString();
                        return;
                    }

                    MissingComponent[] missingComponents = (MissingComponent[])eventargs.Result;

                    //If none found, write to message and return
                    if (missingComponents.Count() == 0)
                    {
                        mcPanel.Visible = false;
                        outputText.Text = "No missing components"+Environment.NewLine;
                        return;
                    }
                    //Otherwise, make objects visible and write components found
                    mcPanel.Visible = true;
                    outputText.Text = "Missing Components Found"+Environment.NewLine;

                    #region Write to Grid
                    Status = WriteGrid(missingComponents);
                    
                    if (Status != "Success")
                    {
                        outputText.Text += "FAIL: Failed to check for missing dependencies" + Environment.NewLine + Status + Environment.NewLine;
                        return;
                    }
                    else
                    {
                        outputText.Text += "Write Grid Success"+Environment.NewLine;
                    }

                    #endregion Write to Grid

                    #region Write to CSV
                    //Check conditions before writing to CSV
                    if (String.IsNullOrEmpty(txt_OutputPath.Text))
                    {
                        outputText.Text += "No output path entered. No CSV file generated"+Environment.NewLine;
                    }

                    Status = WriteCSV(missingComponents);

                    if (Status !="Success")
                    {
                        outputText.Text += "Error writing to CSV"+Environment.NewLine;
                    }
                    else
                    {
                        outputText.Text += "Write CSV success" + Environment.NewLine;
                    }
                    #endregion Write to CSV 

                    return;
                },
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        /// <summary>
        /// Checks version of target connection
        /// </summary>
        /// <returns></returns>
        private string targetVersion()
        {
            LogInfo("Starting check version");
            RetrieveVersionRequest request = new RetrieveVersionRequest();
            RetrieveVersionResponse response = (RetrieveVersionResponse)Service.Execute(request);
            string version = response.Version;
            LogInfo("Version found");
            return version;
        }

        /// <summary>
        /// Parse Version to Double
        /// </summary>
        /// <returns></returns>
        private Double parseVersion(string version)
        {
            string subVersion = version.Substring(0, version.IndexOf(".") + 1);
            Double parsedVersion = Double.Parse(subVersion);
            return parsedVersion;
        }

        /// <summary>
        /// Write missing components to the grid
        /// </summary>
        /// <param name="missingComponents"></param>
        /// <returns></returns>
        public string WriteGrid(MissingComponent[] missingComponents)
        {
            try
            {
                LogInfo("Begin writing to grid");
                int screen_width = Screen.PrimaryScreen.Bounds.Width;
                int gridHeight = this.mcDataGridView.Height;
                int gridWidth = screen_width - 25;

                // loop
                foreach (MissingComponent MissingComponent in missingComponents)
                {
                    LogInfo("Write component: "+MissingComponent.RequiredComponent.DisplayName.ToString());

                    //Build row
                    string[] row =
                    {
                        (TypeIcon_Dictionary.ContainsKey(MissingComponent.DependentComponent.Type) ? TypeIcon_Dictionary[MissingComponent.DependentComponent.Type] : "Type Code: " + MissingComponent.DependentComponent.Type.ToString()),
                        MissingComponent.DependentComponent.DisplayName,
                        MissingComponent.DependentComponent.SchemaName,
                        MissingComponent.RequiredComponent.ParentDisplayName,
                        MissingComponent.RequiredComponent.ParentSchemaName,
                        (TypeIcon_Dictionary.ContainsKey(MissingComponent.RequiredComponent.Type) ? TypeIcon_Dictionary[MissingComponent.RequiredComponent.Type] : "Type Code: " + MissingComponent.RequiredComponent.Type.ToString()),
                        MissingComponent.RequiredComponent.DisplayName,
                        MissingComponent.RequiredComponent.SchemaName
                    };
                    mcDataGridView.Rows.Add(row);

                    //Increment grid height
                    gridHeight += 1;

                }
                this.mcDataGridView.Height = gridHeight;
                this.mcPanel.Width = gridWidth;
                this.mcPanel.Height = gridHeight;

                return "Success";
            }
            catch (Exception e)
            {
                LogInfo("Write Grid Failure "+e.ToString());
                mcPanel.Visible = false; //hide grid panel
                return "Failure";
            }
        }
        /// <summary>
        /// Extracts Solution Version from the file path specified to check if version is greater than connection
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string solutionVersion(string filePath)
        {
            LogInfo("Checking solution version" + Environment.NewLine);
            string version = "0.0";
            string fileContents="";
            try
            {
                //Extract solution.xml to check package version
                ZipArchive solutionZip = ZipFile.Open(filePath, System.IO.Compression.ZipArchiveMode.Read);
                foreach (ZipArchiveEntry entry in solutionZip.Entries)
                {
                    if (entry.Name.Equals("solution.xml"))
                    {
                        ZipArchiveEntry zipEntry = solutionZip.GetEntry(entry.Name);

                        using (System.IO.StreamReader sr = new System.IO.StreamReader(zipEntry.Open()))
                        {
                            //read the contents into a string
                            fileContents = sr.ReadToEnd();
                        }
                    }
                }
                LogInfo("Checking solution version | solution file read" + Environment.NewLine);
                //Read the SolutionPackageVersion attribute from the root
                XmlDocument solutionXML = new XmlDocument();
                solutionXML.LoadXml(fileContents);
                XmlElement root = solutionXML.DocumentElement;
                version = root.Attributes["SolutionPackageVersion"].Value;
            }
            catch (Exception e)
            {
                LogError("Error checking solution version" + e.ToString());
                throw;
            }
            LogInfo("Checking solution version | finished" + Environment.NewLine);
            return version;
        }
        /// <summary>
        /// Write missing components to CSV file
        /// </summary>
        /// <param name="missingComponents"></param>
        /// <returns></returns>
        public string WriteCSV(MissingComponent[] missingComponents)
        {
            LogInfo("Begin writing to CSV");

            // Create csv string builder
            var csv = new StringBuilder();

            try
            {
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
                foreach (MissingComponent MissingComponent in missingComponents)
                {
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
            }
            catch (Exception csvError)
            {
                LogInfo("ERROR: "+csvError);
                return "Failure";
            }

            // write csv file
            File.WriteAllText($@"{txt_OutputPath.Text}\SolutionDependencyChecker_" + DateTime.Now.ToString("yyyyMMdd") + ".csv", csv.ToString());

            LogInfo("Success writing to CSV");
            return "Success";
        }

        /// <summary>
        /// Output missing components to CSV file in user designated location and to in App grid
        /// </summary>
        /// <param name="ExportedSolution"></param>
        /// <returns> String signifiying if missing components were found or not </returns>
        public object CheckMissingComponent(byte[] ExportedSolution)
        {
            object missingComponents;
            try
            {
                RetrieveMissingComponentsRequest GetMissingComponents_Request = new RetrieveMissingComponentsRequest
                {
                    CustomizationFile = ExportedSolution
                };

                RetrieveMissingComponentsResponse GetMissingComponents = (RetrieveMissingComponentsResponse)base.Service.Execute(GetMissingComponents_Request);
                missingComponents = GetMissingComponents.MissingComponents;
                return missingComponents;
            }
            catch (DirectoryNotFoundException e)
            {
                LogInfo(e.ToString());
                missingComponents = new object();
                return missingComponents;
            }
            catch (Exception error)
            {
                LogInfo(error.ToString());
                missingComponents = new object();
                return missingComponents;
            }
        }
        /// <summary>
        /// Get the Icon for the type of component
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTypeIcon(int type)
        {
            if (TypeIcon_Dictionary.ContainsKey(type))
                return TypeIcon_Dictionary[type];
            else
                return "default";
        }
    }
}