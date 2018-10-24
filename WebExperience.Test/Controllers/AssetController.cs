using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using WebExperience.Test.Dtos;
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
        public async Task<IEnumerable<Asset>> GetAssets()
        {
            var assets = await _context.Assets
                .ToListAsync();

            return assets;
        }

        // GET /api/asets/1
        public async Task<IHttpActionResult> GetAsset(int id)
        {
            var asset = await _context.Assets
                .SingleOrDefaultAsync(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Asset, AssetDto>(asset));
        }

        // POST /api/assets
        [HttpPost]
        public async Task<IHttpActionResult> CreateAsset(AssetDto assetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var asset = Mapper.Map<AssetDto, Asset>(assetDto);
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            assetDto.Id = asset.Id;

            return Created(new Uri(Request.RequestUri + "/" + asset.Id), assetDto);
        }

        // PUT /api/assets/1
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAssets(int id, AssetDto assetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var assetInDb = await _context.Assets
                .SingleOrDefaultAsync(a => a.Id == id);

            if (id != assetDto.Id)
            {
                return BadRequest();
            }

            if (assetInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(assetDto, assetInDb);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE /api/assets/1
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsset(int id)
        {
            var assetInDb = await _context.Assets
                .SingleOrDefaultAsync(a => a.Id == id);

            if (assetInDb == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(assetInDb);
            _context.SaveChangesAsync();

            return Ok();
        }
    }
}
