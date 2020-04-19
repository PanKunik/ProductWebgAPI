using PSMDataManagerMVC.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSMDataManagerMVC.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetById(int Id);
        Task<List<ProductModel>> GetByCategory(int Id);
        Task<List<ProductModel>> GetByBrand(int Id);
        Task InsertNewProduct(ProductModel newProduct);
    }
}