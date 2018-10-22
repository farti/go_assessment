using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper.Configuration;

namespace WebExperience.Test.Models
{
    public sealed class CsvAssetMapp : ClassMap<Asset>
    {
        public CsvAssetMapp()
        {
            Map(x => x.AssetName).Name("file_name");
            Map(x => x.Country).Name("country");
            Map(x => x.MimeType).Name("mime_type");
        }
    }
}