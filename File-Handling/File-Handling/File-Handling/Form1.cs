using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Hide();
            Helpers.FilePrompter fp = new Helpers.FilePrompter();
            fp.multiselect = false;
            fp.title = "Pick a File";
            List<String>  selectedFilePaths = fp.PromptForFiles(); // <- non-static version
            // List<String> selectedFilePaths = Helpers.PromptForFiles(); // <- static version
            // https://stackoverflow.com/questions/18867180/check-if-list-is-empty-in-c-sharp
            if (selectedFilePaths?.Any() != false)
            {
                MessageBox.Show($"Selected Files:\n{string.Join("\n", selectedFilePaths)}");
                Helpers.FileInformation finfo = new Helpers.FileInformation();
                MessageBox.Show($"File info:\n{string.Join("\n", finfo.GetInfo(selectedFilePaths.First()))}");
            }
       
            
            MessageBox.Show("Done");
            this.Close();
        }
    }
}
 


public class Helpers
{
    public class FilePrompter
    {
        public string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string title = "Select File";
        public string filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        public bool multiselect = true;

        public List<string> PromptForFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = initialDirectory;
            openFileDialog.Filter = filter;
            openFileDialog.Multiselect = multiselect;

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> selectedFileNames = new List<string>(openFileDialog.FileNames);
                return selectedFileNames;
            }
            else
            {
                Console.WriteLine("User canceled the operation");
                // Return an empty list
                return new List<string>();
            }
        }
    }// class FilePrompter
    public class FileInformation
    {
        public List<String> GetInfo(string filePath)
        {
            List<string> fileInformation = new List<string>();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Get file information
                FileInfo fileInfo = new FileInfo(filePath);

                // Get file size in bytes
                long fileSizeInBytes = fileInfo.Length;

                // Get file creation time
                DateTime creationTime = fileInfo.CreationTime;

                // Get last modification time
                DateTime lastModifiedTime = fileInfo.LastWriteTime;

                // Convert file size to kilobytes or megabytes for better readability
                double fileSizeInKB = fileSizeInBytes / 1024.0;
                double fileSizeInMB = fileSizeInKB / 1024.0;

                // Add file information to the list
                fileInformation.Add($"File Size: {fileSizeInBytes} bytes");
                fileInformation.Add($"File Size (KB): {fileSizeInKB} KB");
                fileInformation.Add($"File Size (MB): {fileSizeInMB} MB");
                fileInformation.Add($"Creation Time: {creationTime}");
                fileInformation.Add($"Last Modified Time: {lastModifiedTime}");
            }
            else
            {
                // fileInformation.Add("File does not exist.");
                return new List<string>();
            }
            return fileInformation;
        }
    }// class FileInfo
}// class Helpers

