using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using GeneralKnowledge.Test.App.Models;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO: 
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted

            var csvFile = Resources.AssetImport;


            // https://joshclose.github.io/CsvHelper/
            // Install-Package CsvHelper

            var stringReader = new StringReader(csvFile);

            var csv = new CsvReader(stringReader);
            csv.Configuration.RegisterClassMap<CsvAssetMapp>();
            csv.Configuration.HasHeaderRecord = true;


            var records = csv.GetRecords<AssetModels>();

            // uncomment for pront result:
            //foreach (var data in records)
            //    {
            //        Console.WriteLine($"Asset: {data.Asset} , Country: {data.Country} , Type: {data.MimeType}");
            //    }
        }
    }

}
