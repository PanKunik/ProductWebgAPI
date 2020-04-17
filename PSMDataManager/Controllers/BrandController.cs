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
    }
}
