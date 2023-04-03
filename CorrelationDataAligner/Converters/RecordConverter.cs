using CorrelationDataAligner.Data;
using System;

namespace CorrelationDataAligner.Converters
{
    internal class RecordConverter
    {
        internal static DailyProfitRecord GetRecord(string line)
        {
            string[] data = line.Split(',');

            DateTime date = DateConverter.GetExcelDate(data[2]);

            double profit = double.Parse(data[3]);

            return new DailyProfitRecord(data[0], data[1], date, profit);
        }

        internal static string GetLine(DailyProfitRecord record)
        {
            return String.Join(",", record.StrategyName, record.Instrument, DateConverter.GetString(record.Date), String.Format("{0:0.00}", record.DailyProfit));
        }
    }
}