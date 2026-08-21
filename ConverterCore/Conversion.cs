using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConverterCore
{
    public class RateTable
    {
        public Dictionary<string, double> Rates { get; set; }

        public static RateTable Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Rate file not found: " + path);

            return JsonConvert.DeserializeObject<RateTable>(File.ReadAllText(path));
        }
    }

    public class UnitConverter
    {
        private readonly RateTable _table;

        public UnitConverter(RateTable table)
        {
            _table = table;
        }

        public IEnumerable<string> Units
        {
            get { return _table.Rates.Keys; }
        }

        public double Convert(double value, string from, string to)
        {
            return value * _table.Rates[from] / _table.Rates[to];
        }
    }
}