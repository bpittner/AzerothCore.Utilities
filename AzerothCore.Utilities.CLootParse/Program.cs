using System;
using System.IO;

namespace AzerothCore.Utilities.CLootParse
{
    // Parses CLoot HTML export files to extract item IDs (https://tbc.c70.ca/, https://wotlk.c70.ca/)).
    // Requires the HTML content to be formatted using prettier (https://prettier.io/) for proper line breaks.  

    // Usage: CLootParse.exe <path_to_input_folder>  
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFolder = args[0];

            DirectoryInfo inputDir = new DirectoryInfo(inputFolder);
            Directory.CreateDirectory("outputs");

            var files = inputDir.GetFiles();

            foreach (var file in files)
            {

                Console.WriteLine($"Processing file: {file.FullName}");
                using var reader = new StreamReader(file.FullName);

                var outFileName = $"outputs/{file.Name.Split(".")[0]}.txt";

                using var outputFile = new StreamWriter(outFileName);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("<a"))
                    {
                        string itemLine = reader.ReadLine();
                        string itemId = itemLine.Split("=")[2].Trim().Replace("\"","");

                        outputFile.WriteLine(itemId);
                        Console.WriteLine($"{itemId}");
                    }
                }
            }
        }
    }
}
