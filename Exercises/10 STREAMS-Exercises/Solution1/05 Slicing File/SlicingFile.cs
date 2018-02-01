using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Slicing_File
{
    class SlicingFile
    {
        private const string path = "../../Files/";
        private static List<string> listFileParts = new List<string>();

        static void Main()
        {
            Console.Write("Enter number of parts [int]: ");
            int partsCount = int.Parse(Console.ReadLine());

            SliceFileIntoParts(partsCount);
            AssembleFileFromParts();
        }
        private static void AssembleFileFromParts()
        {
            Console.WriteLine($"Assembling file parts into '{path}assembledVideo.mp4'");

            var buffer = new byte[4096];
            using (var assembledVideo = new FileStream($"{path}assembledVideo.mp4", FileMode.Create))
            {
                for (int i = 0; i < listFileParts.Count; i++)
                {
                    using (var reader = new FileStream(listFileParts[i], FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            assembledVideo.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void SliceFileIntoParts(int partsCount)
        {
            Console.WriteLine($"Slicing file '{path}sliceMe.mp4' into {partsCount} parts");

            var buffer = new byte[4096];
            using (var sourceFile = new FileStream($"{path}sliceMe.mp4", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);
                for (int i = 0; i < partsCount; i++)
                {
                    var filePartName = $"{path}Part-{i}.mp4";
                    listFileParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        int totalBytes = 0;
                        while (totalBytes < partSize)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }
    }
}
