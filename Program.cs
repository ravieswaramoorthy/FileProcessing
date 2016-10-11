using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessingFile;
using System.IO;

namespace ConsoleFile
{
    class Program
    {
        static void Main(string[] args)
        {



           FileProcess fp = new FileProcess(@"C:\dataload\data.csv", @"C:\dataload\ResultFile\NameResult.csv", @"C:\dataload\ResultFile\AdressResult.csv");
           
            fp.ProcessFile();
            List<Result> results = fp.Results;

            foreach (Result r in results)
                Console.WriteLine("Step : " + r.Title + ", IsSucess: " + r.IsSucess + ", Message: " + r.ErrorMessage);


            Console.ReadKey();
        }
    }
}
