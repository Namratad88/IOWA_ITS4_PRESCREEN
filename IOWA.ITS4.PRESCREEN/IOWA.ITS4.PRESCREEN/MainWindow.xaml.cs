using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using IOWA.ITS4.PRESCREEN.BUSINESSLOGIC;
using IOWA.ITS4.PRESCREEN.DATAOBJECTS;
using IOWA.ITS4.PRESCREEN.Validations;

namespace IOWA.ITS4.PRESCREEN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void onClick_CheckAdjacency(object sender, RoutedEventArgs e)
        {
            outputBlock.Text = "";
            labelError.Content = "";
            //Validate the Input
            Boolean validation = false;
            InputValidationRule ivr = new InputValidationRule();
            string errorMessage = "";
            validation = ivr.validationRule(textBoxMapID.Text, textBoxAdjacentMapID.Text, ref errorMessage);

            if (validation)
            {
                //Store the Inputs in the Input Data Object
                AdjacencyChecker_IP countyInputs = new AdjacencyChecker_IP();
                AdjacencyChecker_OP countyNamesOutput = new AdjacencyChecker_OP();
                countyInputs.mapID = Convert.ToInt32(textBoxMapID.Text);
                countyInputs.adjacentMapID = Convert.ToInt32(textBoxAdjacentMapID.Text);
                countyInputs.connectionString = readSetting();

                //Both inputs are same show message
                if (countyInputs.mapID == countyInputs.adjacentMapID)
                {

                    errorMessage = "Both inputs are the same";
                    labelError.Content = errorMessage;

                }
                else if (countyInputs.mapID == 0 || countyInputs.adjacentMapID == 0)
                {

                    errorMessage = "County code cannot be 0";
                    labelError.Content = errorMessage;

                }
                else
                {

                    //Call the Adjacency function
                    CountyMain_BL bl = new CountyMain_BL();
                   // countyInputs.connectionString = "Server=localhost;Database=IOWA.ITS4;Trusted_Connection=True;";
                    Boolean adjacencyResult = bl.get_countyAdjacency(ref countyInputs);

                    //Function to get County Names
                    bl.get_countyNames(ref countyInputs, ref countyNamesOutput);

                    if (adjacencyResult)
                    {
                        string resultTextPass = countyNamesOutput.adjacentCountyName + " is adjacent to " + countyNamesOutput.countyName + ".";
                        outputBlock.Text = resultTextPass;
                    }
                    else
                    {
                        string resultTextFail = countyNamesOutput.adjacentCountyName + " is not adjacent to " + countyNamesOutput.countyName + ".";
                        outputBlock.Text = resultTextFail;
                    }
                }
            }
            else
            {
                labelError.Content = errorMessage;
            }
        }
       

        //Function to get the connection string from the DBSetting.txt file
        private string readSetting()
        {
            String connectionString = "";
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                string[] dbSettingData = File.ReadAllLines(projectDirectory + "\\DBSetting.txt");
                for (int i = 0; i < dbSettingData.Length; i++)
                {
                    connectionString = dbSettingData[i];

                    if (connectionString[0] == '#')
                    {
                        continue;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            return connectionString;

        }
    }
}
    
   

