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

            ///  FilePrompter Test (code block):
            /*
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
            */

            /// FolderPrompter (code block):
            Helpers.FolderPrompter folderPrompter = new Helpers.FolderPrompter();
            folderPrompter.Recursive = true;

            List<string> selectedFiles = folderPrompter.PromptForFolders();

            if (selectedFiles.Count > 0)
            {
                MessageBox.Show($"Selected Files:\n{string.Join("\n", selectedFiles)}");
            }

            MessageBox.Show("Done");
            this.Close();
        }
    }
}
 


public class Helpers
{
    public class FolderPrompter
    {
        public string InitialDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string Title { get; set; } = "Select Folder";
        public bool Recursive { get; set; } = false;


        private List<string> GetFilesInFolder(string folderPath)
        {
            List<string> filePaths = new List<string>();

            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Search for files in the folder
                SearchOption searchOption = Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                string[] files = Directory.GetFiles(folderPath, "*", searchOption);

                // Add the file paths to the list
                filePaths.AddRange(files);
            }
            else
            {
                Console.WriteLine("Selected folder does not exist.");
            }

            return filePaths;
        }

        public List<string> PromptForFolders()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // Set the title of the dialog
                folderDialog.Description = Title;

                // Show the dialog and check if the user clicked OK
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string selectedFolderPath = folderDialog.SelectedPath;

                    // Get the list of file paths in the selected folder
                    List<string> filesInFolder = GetFilesInFolder(selectedFolderPath);

                    return filesInFolder;
                }
                else
                {
                    // User canceled the operation
                    Console.WriteLine("User canceled the folder selection.");
                    return new List<string>();
                }
            }
        }

    }//  public class FolderPrompter

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
                // Console.WriteLine("User canceled the operation");
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

        // This seems to work aswell:
        public bool IsTextFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false; // File doesn't exist
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int byteRead;
                while ((byteRead = fileStream.ReadByte()) != -1)
                {
                    // Check for control characters or non-printable characters
                    if (byteRead < 32 && byteRead != 9 && byteRead != 10 && byteRead != 13)
                    {
                        return false; // Binary content detected
                    }
                }
            }

            return true; // Likely a text file
        }

        /*
        // Doesn't work on a chineese characters
        public bool IsTextFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return false; // File doesn't exist
            }

            byte[] buffer = new byte[4096]; // Adjust the buffer size based on your needs

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                // Check for common text file characteristics
                for (int i = 0; i < bytesRead; i++)
                {
                    byte currentByte = buffer[i];

                    // Check for control characters or non-printable characters
                    if (currentByte < 32 && currentByte != 9 && currentByte != 10 && currentByte != 13)
                    {
                        return false; // Binary content detected
                    }
                }

                // Check for a UTF-8 BOM (Byte Order Mark)
                if (bytesRead >= 3 && buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
                {
                    return true; // UTF-8 BOM found, likely a text file
                }

                // Check for a UTF-16 BOM
                if (bytesRead >= 2 && (buffer[0] == 0xFF && buffer[1] == 0xFE) || (buffer[0] == 0xFE && buffer[1] == 0xFF))
                {
                    return true; // UTF-16 BOM found, likely a text file
                }

                // Check for valid ASCII characters
                if (Encoding.ASCII.GetString(buffer, 0, bytesRead).Equals(Encoding.UTF8.GetString(buffer, 0, bytesRead)))
                {
                    return true; // Likely a text file
                }
            }

            return false; // Couldn't definitively determine file type
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
        }// public bool IsBinary

        public List<string> GetTextFileContents(string filePath)
        {
            List<string> fileContents = new List<string>();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Check if the file is a .txt file
                // if (!IsBinary(filePath)) // <- works fine
                if (IsTextFile(filePath))
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
    }// class FileInformation

}// class Helpers

