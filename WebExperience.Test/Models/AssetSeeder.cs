using CsvHelper;
using GeneralKnowledge.Test.App;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace WebExperience.Test.Models
{
    public class AssetSeeder : DropCreateDatabaseAlways<ApplicationDbContext>
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

            records.ForEach(x=> context.Assets.Add(x));
            base.Seed(context);
        }
    }
}