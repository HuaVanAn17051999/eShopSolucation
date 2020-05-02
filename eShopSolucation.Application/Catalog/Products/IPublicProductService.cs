
using eShopSolucation.ViewModels.Catalog.Products;
using eShopSolucation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolucation.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
        //Task<List<ProductViewModel>> GetAll(string languageId);
    }
}
