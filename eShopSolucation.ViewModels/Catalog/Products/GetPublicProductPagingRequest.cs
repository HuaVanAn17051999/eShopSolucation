
using eShopSolucation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
        public string LanguageId { get; set; }
    }
}
