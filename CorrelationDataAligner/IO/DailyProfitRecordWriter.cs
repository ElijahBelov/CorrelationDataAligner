using CorrelationDataAligner.Converters;
using CorrelationDataAligner.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelationDataAligner.IO
{
    class DailyProfitRecordWriter
    {
        internal static void Serialize(RecordCollection records, string outputFile)
        {
            if (String.IsNullOrEmpty(outputFile))
                return;

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach (var record in records.GetRecords())
                    {
                        string line = RecordConverter.GetLine(record);
                        writer.WriteLine(line);
                    } 
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }
    }
}
