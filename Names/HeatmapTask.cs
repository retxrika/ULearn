using System;
using System.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var mounths = Enumerable.Range(1, 12).Select(x => x.ToString()).ToArray();
            var days = Enumerable.Range(2, 30).Select(x => x.ToString()).ToArray();

            var birthsCounts = new double[30, 12];

            foreach (var name in names)
                if (name.BirthDate.Day != 1)
                    birthsCounts[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;

            return new HeatmapData(
                "Пример карты интенсивностей",
                birthsCounts,
                days,
                mounths);
        }
    }
}