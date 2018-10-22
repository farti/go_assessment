using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{
    public class AssetController : ApiController
    {
        // TODO:
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework

        private ApplicationDbContext _context;

        public AssetController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/asets
        public IEnumerable<Asset> GetAssets()
        {
            return _context.Assets.ToList();
        }

        // GET /api/asets/1
        public Asset GetAsset(int id)
        {
            var asset = _context.Assets.SingleOrDefault(a => a.Id == id);

            if (asset == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return asset;
        }

        // POST /api/assets
        [HttpPost]
        public Asset CreateAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Assets.Add(asset);
            _context.SaveChanges();

            return asset;
        }

        // PUT /api/assets/1
        [HttpPut]
        public void UpdateAssets(int id, Asset asset)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var assetInDb = _context.Assets.SingleOrDefault(a => a.Id == id);

            if (assetInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            assetInDb.AssetName = asset.AssetName;
            assetInDb.Country = asset.Country;
            assetInDb.MimeType = asset.MimeType;

            _context.SaveChanges();
        }

        // DELETE /api/assets/1
        [HttpDelete]
        public void DeleteAsset(int id)
        {
            var assetInDb = _context.Assets.SingleOrDefault(a => a.Id == id);

            if (assetInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Assets.Remove(assetInDb);
            _context.SaveChanges();
        }
    }
}
