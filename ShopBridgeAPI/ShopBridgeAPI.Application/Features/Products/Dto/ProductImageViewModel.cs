using ShopBridgeAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridgeAPI.Application.Features.Products.Dto
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageName { get; set; }

    }
}
