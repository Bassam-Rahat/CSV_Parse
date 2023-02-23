using LINQtoCSV;
using System;
using System.Collections.Generic;

namespace CSV_Parse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n\nSelect an option:");
                Console.WriteLine("1. Read a CSV file");
                Console.WriteLine("2. Write a new CSV file");
                Console.WriteLine("3. Quit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ReadCsvFile();
                        break;
                    case "2":
                        WriteCsvFile();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        break;
                }
            }
            }

        private static void WriteCsvFile()
        {
            var countryList = new List<Country>();

            while (true)
            {
                Console.Write("Enter country name (or '-1' to quit): ");
                var countryName = Console.ReadLine();
                if (countryName == "-1")
                {
                    break;
                }

                Console.Write("Enter country code: ");
                var countryCode = Console.ReadLine();

                Console.Write("Enter region: ");
                var region = Console.ReadLine();

                var country = new Country
                {
                    CountryName = countryName,
                    CountryCode = countryCode,
                    Region = region
                };

                countryList.Add(country);
            }

            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ','
            };

            var csvContext = new CsvContext();
            csvContext.Write(countryList, "country01.csv", csvFileDescription);

            Console.WriteLine("CSV File Created");
        }

        private static void ReadCsvFile()
        {
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };

            var csvContext = new CsvContext();
            var countries = csvContext.Read<Country>("country.csv", csvFileDescription);

            foreach (var country in countries)
            {
                Console.WriteLine($"{country.CountryName} | {country.CountryCode} | {country.Region}");
            }
        }
    }
}
