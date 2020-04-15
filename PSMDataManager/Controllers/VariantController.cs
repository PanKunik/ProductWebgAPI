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
    public class VariantController : ApiController
    {
        // GET: api/Variant
        public List<VariantModel> Get()
        {
            VariantData data = new VariantData();

            return data.GetVariants();
        }

        // GET: api/Variant/5
        public VariantModel Get(int id)
        {
            VariantData data = new VariantData();

            return data.GetVariantById(id).First();
        }

        // POST: api/Variant
        // TODO: Passing in VariantModel instead VariantDBModel
        public void Post(VariantDBModel variant)
        {
            VariantData data = new VariantData();

            data.SaveVariant(variant);
        }
    }
}
