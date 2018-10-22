using System.Collections.Generic;
using CsvHelper;
using GeneralKnowledge.Test.App;
using System.Data.Entity;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using WebGrease.Css.Extensions;

namespace WebExperience.Test.Models
{
    public class AssetSeeder : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            var csvFile = Resources.AssetImport;

            var stringReader = new StringReader(csvFile);

            var csv = new CsvReader(stringReader);
            csv.Configuration.RegisterClassMap<CsvAssetMapp>();
            csv.Configuration.HasHeaderRecord = true;

            var records = csv
                .GetRecords<Asset>()
                .ToList();

            foreach (var record in records)
            {
                context.Assets.Add(record);
            }
            context.SaveChanges();
        }

    }
}