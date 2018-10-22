using System.Collections.Generic;
using CsvHelper;
using GeneralKnowledge.Test.App;
using System.Data.Entity;
using System.EnterpriseServices;
using System.IO;
using System.Linq;

namespace WebExperience.Test.Models
{
    public class AssetSeeder : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            GetAsset().ForEach(a => context.Assets.Add(a));

            GetAssetFromCsv().ForEach(x => context.Assets.Add(x));

            base.Seed(context);
        }

        private static List<Asset> GetAssetFromCsv()
        {
            var csvFile = Resources.AssetImport;

            var stringReader = new StringReader(csvFile);

            var csv = new CsvReader(stringReader);
            csv.Configuration.RegisterClassMap<CsvAssetMapp>();
            csv.Configuration.HasHeaderRecord = true;

            var records = csv
                .GetRecords<Asset>()
                .ToList();

            return records;
        }

        private static List<Asset> GetAsset()
        {
            var asset = new List<Asset>
            {
                new Asset
                {
                    AssetName = "płyta",
                    Country = "Polska",
                    MimeType = "beton"
                },
                new Asset()
                {
                    AssetName = "rura",
                    Country = "Piemcy",
                    MimeType = "PCV"
                }
            };
            return asset;
        }
    }
}