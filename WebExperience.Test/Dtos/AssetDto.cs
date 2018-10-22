using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Dtos
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string Country { get; set; }
        public string MimeType { get; set; }
    }
}