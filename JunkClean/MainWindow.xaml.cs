using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace JunkClean
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> paths = new List<string>()
            {
                Path.GetTempPath(),
                "C:\\Windows\\Temp",
                "C:\\Windows\\Prefetch"
            };
            try
            {
                foreach (string path in paths)
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.EnumerateFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {
                            // Log or handle the exception as needed
                            //Console.WriteLine($"Unable to delete file: {file.FullName}. Exception: {ex.Message}");
                        }
                    }
                    foreach (DirectoryInfo dir in di.EnumerateDirectories())
                    {
                        try
                        {
                            dir.Delete(true);
                        }
                        catch
                        {
                            // Log or handle the exception as needed
                            //Console.WriteLine($"Unable to delete directory: {dir.FullName}. Exception: {ex.Message}");
                        }
                    }
                }
                MessageBox.Show("Junk files cleaned successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please go to prefetch and accept folder access permission\n" +
                    "then re run this program");
            }

        }
    }
}
