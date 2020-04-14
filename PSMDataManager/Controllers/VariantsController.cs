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
        public List<VariantModel> Get()
        {
            VariantData data = new VariantData();

            return data.GetVariants();
        }

        // GET: api/Variants/5
        public VariantModel Get(int id)
        {
            VariantData data = new VariantData();

            return data.GetVariantById(id).First();
        }
    }
}
