using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace VideoIndexProcessor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Usage: {Path.ChangeExtension(Path.GetFileName(Assembly.GetExecutingAssembly().Location), null)} <input file name> [<output file name>]");
            }

            var inputFileName = args[0];
            var outputFileName = args.Length > 1 ? args[1] : MakeOutputFileName(inputFileName);

            using var inputStream = File.OpenRead(inputFileName);
            using var outputStream = File.Create(outputFileName);
            var processor = new JsonProcessor();
            await processor.ExtractInstances(inputStream, outputStream);

            Console.WriteLine("Done");
        }

        private static string MakeOutputFileName(string inputFileName)
        {
            var ext = Path.GetExtension(inputFileName);
            var directory = Path.GetDirectoryName(inputFileName);
            var fileName = Path.ChangeExtension(Path.GetFileName(inputFileName), null);
            var outputFileName = Path.Combine(directory, fileName + "-output" + ext);
            if (!File.Exists(outputFileName)) return outputFileName;
            var i = 1;
            do
            {
                outputFileName = Path.Combine(directory, fileName + "-output" + i + ext);
            } while (File.Exists(outputFileName));

            return outputFileName;
        }
    }
}
