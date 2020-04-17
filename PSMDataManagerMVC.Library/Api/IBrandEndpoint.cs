using PSMDataManagerMVC.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSMDataManagerMVC.Library.Api
{
    public interface IBrandEndpoint
    {
        Task<List<BrandModel>> GetAll();
    }
}