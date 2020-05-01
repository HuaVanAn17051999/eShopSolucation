using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public decimal Id { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }

        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { get; set; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string  LanguageId { set; get; }
    }

}
