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

                List<String> txtContents = finfo.GetTextFileContents(selectedFilePaths.First());
                if (txtContents?.Any() != false)
                {
                    MessageBox.Show($"File text contents:\n{string.Join("\n", txtContents)}");
                }
                    

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
        /*
        private bool IsTextFile(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLower();

            // Check if the file has a .txt extension
            return extension == ".txt";
        }
        */

        // checking if the file is non-binary instead:
        // https://stackoverflow.com/questions/4744890/c-sharp-check-if-file-is-text-based
        public bool IsBinary(string filePath, int requiredConsecutiveNul = 1)
        {
            const int charsToCheck = 8000;
            const char nulChar = '\0';

            int nulCount = 0;

            using (var streamReader = new StreamReader(filePath))
            {
                for (var i = 0; i < charsToCheck; i++)
                {
                    if (streamReader.EndOfStream)
                        return false;

                    if ((char)streamReader.Read() == nulChar)
                    {
                        nulCount++;

                        if (nulCount >= requiredConsecutiveNul)
                            return true;
                    }
                    else
                    {
                        nulCount = 0;
                    }
                }
            }

            return false;
        }

        public List<string> GetTextFileContents(string filePath)
        {
            List<string> fileContents = new List<string>();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Check if the file is a .txt file
                if (!IsBinary(filePath))
                {
                    try
                    {
                        // Read all lines from the text file
                        fileContents.AddRange(File.ReadAllLines(filePath));
                    }
                    catch (Exception ex)
                    {
                        // fileContents.Add($"Error reading text file: {ex.Message}");
                        return null;
                    }
                }
                else
                {
                    // fileContents.Add("File is not a .txt file.");
                    return null;
                }
            }
            else
            {
                // fileContents.Add("File does not exist.");
                return null;
            }

            return fileContents;
        }

        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLower();

            // Check if the file has a common image extension
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }

        public List<String> GetInfo(string filePath)
        {
            List<string> fileInformation = new List<string>();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeInBytes = fileInfo.Length;
                DateTime creationTime = fileInfo.CreationTime;
                DateTime lastModifiedTime = fileInfo.LastWriteTime;

                // Convert file size to kilobytes or megabytes for better readability
                double fileSizeInKB = fileSizeInBytes / 1024.0;
                double fileSizeInMB = fileSizeInKB / 1024.0;

                // Get file attributes
                FileAttributes attributes = File.GetAttributes(filePath);

                // Check if specific attributes are present
                bool isReadOnly = (attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
                bool isHidden = (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;


                // Add file information to the list
                fileInformation.Add($"File Size: {fileSizeInBytes} bytes");
                fileInformation.Add($"File Size (KB): {fileSizeInKB} KB");
                fileInformation.Add($"File Size (MB): {fileSizeInMB} MB");
                fileInformation.Add($"Creation Time: {creationTime}");
                fileInformation.Add($"Last Modified Time: {lastModifiedTime}");
                fileInformation.Add($"Read-Only: {isReadOnly}");
                fileInformation.Add($"Hidden: {isHidden}");


                // Get additional information for image files
                if (IsImageFile(filePath))
                {
                    Image image = Image.FromFile(filePath);

                    // Get image dimensions
                    int width = image.Width;
                    int height = image.Height;

                    // Get image bit depth
                    int bitDepth = Image.GetPixelFormatSize(image.PixelFormat);

                    // Get image resolution (DPI)
                    float horizontalResolution = image.HorizontalResolution;
                    float verticalResolution = image.VerticalResolution;


                    // Add image-specific information to the list
                    fileInformation.Add($"Image Width: {width} pixels");
                    fileInformation.Add($"Image Height: {height} pixels");
                    fileInformation.Add($"Image Bit Depth: {bitDepth} bits per pixel");

                    fileInformation.Add($"Image Resolution (Horizontal): {horizontalResolution} DPI");
                    fileInformation.Add($"Image Resolution (Vertical): {verticalResolution} DPI");
                  
 
                    // Dispose of the image to release resources
                    image.Dispose();
                }

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

