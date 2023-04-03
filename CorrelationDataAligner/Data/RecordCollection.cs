using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CorrelationDataAligner.Data
{
    class RecordCollection
    {
        private ImmutableList<DailyProfitRecord> records;
        private string strategyName;
        private string instrument;

        public RecordCollection(IEnumerable<DailyProfitRecord> collection)
        {
            this.records = ImmutableList<DailyProfitRecord>.Empty.AddRange(collection);

            this.strategyName = IsEmpty ? String.Empty : records[0].StrategyName;
            this.instrument = IsEmpty ? String.Empty : records[0].Instrument;

        }

        internal bool IsEmpty {
            get { return records.Count == 0; }
        }

        internal IEnumerable<DailyProfitRecord> GetRecords()
        {
            return records;
        }

        internal RecordCollection FillRecordFromBeginning(DateTime startDate)
        {
            if (IsEmpty)
                return this;

            List<DailyProfitRecord> list = GetMutable(records);

            list.RemoveAll((p) => p.Date.Date < startDate.Date);

            DateTime currentDate = list[0].Date.Date;
            while (currentDate > startDate.Date)
            {
                currentDate = currentDate.AddDays(-1);
                list.Insert(0, EmptyRecord(currentDate));

            }

            return new RecordCollection(list);
        }

        private DailyProfitRecord EmptyRecord(DateTime currentDate)
        {
            return new DailyProfitRecord(strategyName, instrument, currentDate, 0);
        }

        internal RecordCollection FillRecordEnd(DateTime endDate, bool cutOffPastEnd)
        {
            if (IsEmpty)
                return this;

            List<DailyProfitRecord> list = GetMutable(records);

            if (cutOffPastEnd) { 
                list.RemoveAll((p) => p.Date.Date > endDate.Date);
            }

            if (list.Count != 0)
            {
                DateTime currentDate = list[list.Count - 1].Date.Date;
                while (currentDate < endDate.Date)
                {
                    currentDate = currentDate.AddDays(1);
                    list.Add(EmptyRecord(currentDate));
                }
            }

            return new RecordCollection(list);
        }

        internal RecordCollection FillMiddle()
        {
            if (IsEmpty)
                return this;

            List<DailyProfitRecord> list = GetMutable(records);

            DateTime currentDate = list[0].Date;
            DateTime endDate = list[list.Count - 1].Date.Date;

            int c = 0;
            int end = (endDate - currentDate).Days;


            while (c < end - 1) {
                currentDate = currentDate.AddDays(1);

                if (list[c + 1].Date.Date > currentDate.Date)
                {

                    list.Insert(c + 1, EmptyRecord(currentDate));
                }

                c++;
            }

            return new RecordCollection(list);
        }

        private static List<DailyProfitRecord> GetMutable(ImmutableList<DailyProfitRecord> records)
        {
            List<DailyProfitRecord> list = new List<DailyProfitRecord>(records);
            list.Sort((p, q) => p.Date.CompareTo(q.Date));
            return list;
        }
    }
}
