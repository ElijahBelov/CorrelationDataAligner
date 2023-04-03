using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelationDataAligner.Data
{
    class DailyProfitRecord
    {
        public DailyProfitRecord(string strategyName, string instrument, DateTime date, double dailyProfit)
        {
            StrategyName = strategyName;
            Date = date;
            Instrument = instrument;
            DailyProfit = dailyProfit;
        }

        public string StrategyName { get;}
        public DateTime Date { get;}
        public string Instrument { get;}
        public double DailyProfit { get;}
    }
}
