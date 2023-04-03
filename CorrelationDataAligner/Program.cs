using CorrelationDataAligner.MainProcessor;
using System;

namespace CorrelationDataAligner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");

            // inputs:
            // original daily profits data file path
            // aligned daily profits data file path
            // alignment start date
            // aligment end date
            // switch to cut off the data past end date (start date is always extend/cut off)
            // switch to order the output file - desc or asc, default is asc
            // outputs: none

            if (args.Length < 3)
            {
                PrintArgs();
                Environment.Exit(1);
            }

            Aligner.Align(args[0], args[1], args[2], args[3], args[4], args[5]);

            Console.WriteLine("done");
            Console.ReadLine();
        }

        private static void PrintArgs()
        {
            Console.WriteLine("Use six arguments: input path, output path, Excel start date, Excel end date, cut, sort");
        }
    }
}
