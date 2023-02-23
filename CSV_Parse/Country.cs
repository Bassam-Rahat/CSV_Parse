using LINQtoCSV;
using System;

namespace CSV_Parse
{
    [Serializable]
    public class Country
    {
        [CsvColumn(Name = "name", FieldIndex = 1)]
        public string CountryName { get; set; }

        [CsvColumn(Name = "country-code", FieldIndex = 2)]
        public string CountryCode { get; set; }

        [CsvColumn(Name = "region", FieldIndex = 3)]
        public string Region { get; set; }
    }
}
