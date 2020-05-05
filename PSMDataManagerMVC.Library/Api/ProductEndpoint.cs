using PSMDataManagerMVC.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManagerMVC.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;
        public ProductEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/products"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<ProductModel> GetById(int Id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/products/{ Id }"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<ProductModel>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<ProductModel>> GetByCategory(int Id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/products/category/{ Id }"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<ProductModel>> GetByBrand(int Id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/products/brand/{ Id }"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task InsertNewProduct(ProductModel newProduct)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync<ProductModel>("/api/products", newProduct))
            {
                if(response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
