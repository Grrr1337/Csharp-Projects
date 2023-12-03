using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Hide();
            Helpers.PromptForFiles();
            MessageBox.Show("Done");
            this.Close();
        }
    }
}


public class Helpers
{
    private static string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    public static void PromptForFile()
    {
        // Create an instance of the OpenFileDialog
        OpenFileDialog openFileDialog = new OpenFileDialog();

        // Set the title of the dialog
        openFileDialog.Title = "Select a File";

        // Set the initial directory
        openFileDialog.InitialDirectory = initialDirectory;

        // Filter the types of files to be displayed
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

        // Allow the user to select multiple files (optional)
        openFileDialog.Multiselect = false;

        // Show the dialog and check if the user clicked OK
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Get the selected file name
            string selectedFileName = openFileDialog.FileName;

            // Display the selected file name
            Console.WriteLine("Selected File: " + selectedFileName);
        }
        else
        {
            Console.WriteLine("User canceled the operation");
        }
    }

    public static void PromptForFiles()
    {
        // Create an instance of the OpenFileDialog
        OpenFileDialog openFileDialog = new OpenFileDialog();

        // Set the title of the dialog
        openFileDialog.Title = "Select Files";

        // Set the initial directory
        openFileDialog.InitialDirectory = initialDirectory;

        // Filter the types of files to be displayed
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

        // Allow the user to select multiple files
        openFileDialog.Multiselect = true;

        // Show the dialog and check if the user clicked OK
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Get an array of selected file names
            string[] selectedFileNames = openFileDialog.FileNames;

            // Display the selected file names
            Console.WriteLine("Selected Files:");
            foreach (string fileName in selectedFileNames)
            {
                Console.WriteLine(fileName);
            }
        }
        else
        {
            Console.WriteLine("User canceled the operation");
        }
    }
}// class Helpers

