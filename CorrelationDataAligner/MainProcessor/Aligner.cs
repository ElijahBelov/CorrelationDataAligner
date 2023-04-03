using CorrelationDataAligner.Data;
using CorrelationDataAligner.IO;
using System;
using System.IO;

namespace CorrelationDataAligner.MainProcessor
{
    class Aligner
    {

        // inputs:
        // original daily profits data file path
        // aligned daily profits data file path
        // alignment start date
        // aligment end date
        // switch to cut off the data past end date (start date is always extend/cut off)
        // switch to order the output file - desc or asc, default is asc
        // outputs: none
        public static void Align(string inputPath, string outputPath, string startDate, string endDate, string cutOffPastEnd, string sortDesc = null)
        {
            DateTime start = Converters.DateConverter.GetExcelDate(startDate);
            DateTime end = Converters.DateConverter.GetExcelDate(endDate);
            bool cut = Converters.BoolCoverter.GetBool(cutOffPastEnd);
            bool sort = Converters.BoolCoverter.GetBool(cutOffPastEnd);
            Align(inputPath, outputPath, start, end, cut, sort);
        }

        public static void Align(string inputFile, string outputFile, DateTime startDate, DateTime endDate, bool cutOffPastEnd = true, bool sortDesc = false)
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("No file at " + inputFile);
                return;
            }
            else
            {
                RecordCollection records = DailyProfitRecordReader.Read(inputFile);

                RecordCollection tempRecords = records.FillRecordFromBeginning(startDate);
                RecordCollection tempRecords2 = tempRecords.FillMiddle();
                RecordCollection newRecords = tempRecords2.FillRecordEnd(endDate, cutOffPastEnd);

                DailyProfitRecordWriter.Serialize(newRecords, outputFile);

            }
        }
    }
}
