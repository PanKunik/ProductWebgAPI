using PSMDataManagerMVC.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSMDataManagerMVC.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}