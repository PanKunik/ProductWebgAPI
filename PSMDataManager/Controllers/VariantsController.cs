using Microsoft.Ajax.Utilities;
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
    public class VariantsController : ApiController
    {
        // GET: api/Variants
        [HttpGet]
        public List<VariantDBModel> Get()
        {
            VariantData data = new VariantData();

            return data.GetVariants();
        }

        // GET: api/Variants/id
        [HttpGet]
        public VariantDBModel Get(int id)
        {
            VariantData data = new VariantData();

            return data.GetVariantById(id).First();
        }

        // GET: api/variants/product/{id}
        [HttpGet]
        [Route("api/variants/product/{productId}")]
        public List<VariantModel> GetVariantsOfProduct(int productId)
        {
            VariantData data = new VariantData();

            return data.GetVariantsOfProduct(productId);
        }

        // GET: api/variants/price/{minPrice}/{maxPrice}
        [HttpGet]
        [Route("api/variants/price/{minPrice}/{maxPrice}")]
        public List<VariantModel> GetVariantsInPriceRange(int minPrice, int? maxPrice = null)
        {
            VariantData data = new VariantData();

            return data.GetVariantsInPriceRange(minPrice, maxPrice);
        }

        // POST: api/Variants
        [HttpPost]
        public void Post(VariantModel variant)
        {
            VariantData data = new VariantData();

            data.SaveVariant(variant);
        }

        // PUT: api/Variants/id
        [HttpPut]
        public void Put(int id, [FromBody]VariantModel variant)
        {
            VariantData data = new VariantData();

            data.UpdateVariant(id, variant);
        }

        // DELETE: api/Variants/id
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
