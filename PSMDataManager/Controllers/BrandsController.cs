using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PSMDataManager.Controllers
{
    public class BrandsController : ApiController
    {
        // GET: /api/Brands
        [HttpGet]
        public List<BrandModel> Get()
        {
            BrandData data = new BrandData();

            return data.GetBrands();
        }

        // GET: /api/Brands/id
        [HttpGet]
        public BrandModel Get(int id)
        {
            BrandData data = new BrandData();

            return data.GetBrandById(id);
        }

        // POST: api/Brands
        [HttpPost]
        public void Post([FromBody]string brand)
        {
            BrandData data = new BrandData();

            data.SaveBrand(brand);
        }

        // PUT: api/Brands/id
        [HttpPut]
        public void Put(int id, [FromBody]string brand)
        {
            BrandData data = new BrandData();

            data.UpdateBrandById(id, brand);
        }

        // DELETE: api/Brands/id
        [HttpDelete]
        public void Delete(int id)
        {
            BrandData data = new BrandData();

            data.DeleteBrandById(id);
        }
    }
}
