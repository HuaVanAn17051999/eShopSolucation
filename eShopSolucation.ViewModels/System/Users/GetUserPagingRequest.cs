using eShopSolucation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
