using PSMDataManager.Library.DataAccess;
using PSMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PSMDataManager.Controllers
{
    public class BrandController : ApiController
    {
        // GET: /api/Brand
        public List<BrandModel> Get()
        {
            BrandData data = new BrandData();

            return data.GetBrands();
        }

        // GET: /api/Brand/id
        public BrandModel Get(int id)
        {
            BrandData data = new BrandData();

            return data.GetBrandById(id);
        }

        // POST: api/Brand
        public void Post([FromBody]string brand)
        {
            BrandData data = new BrandData();

            data.SaveBrand(brand);
        }

        // PUT: api/Brand/id
        public void Put(int id, [FromBody]string brand)
        {
            BrandData data = new BrandData();

            data.UpdateBrandById(id, brand);
        }

        // DELETE: api/Brand/id
        public void Delete(int id)
        {
            BrandData data = new BrandData();

            data.DeleteBrandById(id);
        }
    }
}
