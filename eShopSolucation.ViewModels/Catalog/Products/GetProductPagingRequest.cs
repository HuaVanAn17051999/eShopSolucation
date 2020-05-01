using eShopSolucation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.ViewModels.Catalog.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryId { get; set; }
    }
}
