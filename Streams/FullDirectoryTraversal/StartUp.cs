namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Lists files sorted by extensions in all subdirs of a given directory
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            string targetDir = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(targetDir);

            Dictionary<string, List<FileInfo>> extensionsAndFiles = new Dictionary<string, List<FileInfo>>();
            extensionsAndFiles = GetDirListing(dirInfo, extensionsAndFiles);

            string desktopPathfile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

            using (StreamWriter writer = new StreamWriter(desktopPathfile))
            {
                if (extensionsAndFiles.Count > 0)
                {
                    foreach (KeyValuePair<string, List<FileInfo>> extension in extensionsAndFiles.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
                    {
                        writer.WriteLine(extension.Key);

                        foreach (FileInfo fileInfo in extension.Value.OrderBy(f => f.Length))
                        {
                            writer.WriteLine($"--{fileInfo.Name} - {fileInfo.Length / 1000}kB");
                        }
                    }
                }
                else
                {
                    writer.WriteLine("No files in directory!");
                }
            }
        }

        public static Dictionary<string, List<FileInfo>> GetDirListing(DirectoryInfo dirToBeListed, Dictionary<string, List<FileInfo>> extensionsAndFiles)
        {
            FileInfo[] files = null;

            try
            {
                files = dirToBeListed.GetFiles("*.*");

                foreach (FileInfo fileInfo in files)
                {
                    string currentFileExt = Path.GetExtension(fileInfo.FullName);

                    if (!extensionsAndFiles.ContainsKey(currentFileExt))
                    {
                        extensionsAndFiles.Add(currentFileExt, new List<FileInfo>());
                        extensionsAndFiles[currentFileExt].Add(fileInfo);
                    }
                    else
                    {
                        extensionsAndFiles[currentFileExt].Add(fileInfo);
                    }
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such directory!");
            }

            DirectoryInfo[] dirs = dirToBeListed.GetDirectories();

            foreach(DirectoryInfo dir in dirs)
            {
                GetDirListing(dir, extensionsAndFiles);
            }

            return extensionsAndFiles;
        }
    }
}