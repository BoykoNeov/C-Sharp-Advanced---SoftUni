namespace SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Launcher
    {
        public static void Main()
        {
            string sourceFile = "../sliceMe.mp4";
            string destinationDirectory = "../Split parts/";
            string assembledFilePath = "../sliceMe-assembled.mp4";
            int partsCount = 5;

            //sourceFile = Console.ReadLine();
            //destinationDirectory = Console.ReadLine();
            //assembledFilePath = Console.ReadLine();
            // partsCount = int.Parse(Console.ReadLine());
            List<string> slicedFilesPaths = new List<string>();

            // Another genius wrote the task definition...
            slicedFilesPaths = Split(sourceFile, destinationDirectory, partsCount);

            Console.WriteLine("Sliced!");
            Console.ReadLine();

            Assemble(slicedFilesPaths, assembledFilePath);

            Console.WriteLine("Assembled!");
        }

        private static void Assemble(List<string> slicedFilesPaths, string assembleDir)
        {
            for (int i = 0; i < slicedFilesPaths.Count; i++)
            {
                using (FileStream reader = new FileStream(slicedFilesPaths[i], FileMode.Open))
                {
                    using (FileStream writer = new FileStream(assembleDir, FileMode.Append))
                    {
                        byte[] buffer = new byte[reader.Length];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        private static List<string> Split(string sourceFilePath, string destinationDir, int parts)
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            List<string> slicedFilesPaths = new List<string>();

            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                double partSize = Math.Ceiling((double)reader.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    using (FileStream writer = new FileStream(destinationDir + $"Part-{i}", FileMode.Create))
                    {
                        byte[] buffer = new byte[(int)partSize];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, readBytes);
                        slicedFilesPaths.Add(destinationDir + $"Part-{i}");
                    }
                }
            }

            return slicedFilesPaths;
        }
    }
}