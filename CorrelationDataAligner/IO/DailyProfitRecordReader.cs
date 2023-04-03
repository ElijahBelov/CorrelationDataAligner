using CorrelationDataAligner.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelationDataAligner.IO
{
    class DailyProfitRecordReader
    {
        internal static RecordCollection Read(string inputFile)
        {

            List<DailyProfitRecord> collection = new List<DailyProfitRecord>();

            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        collection.Add(Converters.RecordConverter.GetRecord(line));
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Could not read file at " + inputFile);
                Console.WriteLine(exp.Message);
            }

            return new RecordCollection(collection);
        }
    }
}
