using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace GeneralKnowledge.Test.App.Models
{
    public sealed class CsvAssetMapp : ClassMap<AssetModels>
    {
        public CsvAssetMapp()
           
        {
            Map(x => x.Asset).Name("file_name");
            Map(x => x.Country).Name("country");
            Map(x => x.MimeType).Name("mime_type");
        }
    }
}
