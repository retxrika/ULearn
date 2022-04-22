using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            string[] dates = Enumerable.Range(1, 31).Select(x => x.ToString()).ToArray();
            var birthsCounts = new double[31];

            foreach (var e in names)
                if (e.Name == name && e.BirthDate.Day != 1)
                    birthsCounts[e.BirthDate.Day - 1]++;

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name), 
                dates,
                birthsCounts);
        }
    }
}