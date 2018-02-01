using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Copy_Binary_File
{
    class CopyBinaryFile
    {
        private const string path = "../../Files/";

        static void Main()
        {
            Console.WriteLine($"Copy file '{path}image.png'");
            Console.WriteLine($"To file '{path}imageCopy.png'");

            var sourceFilePath = $"{path}image.png";
            var copyFilePath = $"{path}imageCopy.png";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) break;

                        copyFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
