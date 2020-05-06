using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolucation.Application.Catalog.Products;
using eShopSolucation.ViewModels.Catalog.ProductImages;
using eShopSolucation.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolucation.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductsController(IProductService ProductService)
        {
        
            _ProductService = ProductService;

        }
        //[HttpGet("{languageId}")]
        //public async Task<IActionResult> GetAll(string languageId)
        //{
        //    var product = await _publicProductService.GetAll(languageId);
        //    return Ok(product);
        //}

        //localhost:port/products?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetPaging  (string languageId, [FromQuery]GetPublicProductPagingRequest request)
        {
            var product = await _ProductService.GetAllByCategoryId(languageId,request);
            return Ok(product);
        }
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _ProductService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find Product");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _ProductService.Create(request);
            if (productId == 0)
                return BadRequest(); /*trả về lỗi 400*/

            var product = await _ProductService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId}, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _ProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest(); /*trả về lỗi 400*/

            return Ok();
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _ProductService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest(); /*trả về lỗi 400*/

            return Ok();
        }   

        //HttpPatch là update một phần của bản ghi 
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var isSuccessful = await _ProductService.UpdatePrice(id, newPrice);
            if (isSuccessful)
                return Ok();
            return BadRequest(); /*trả về lỗi 400*/
        }

        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId,[FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _ProductService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest(); /*trả về lỗi 400*/

            var image = await _ProductService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }
        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ProductService.UpdateImage(imageId,request);
            if (result == 0)
                return BadRequest(); /*trả về lỗi 400*/

            return Ok();
        }
        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ProductService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest(); /*trả về lỗi 400*/

            return Ok();
        }
        [HttpGet("images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _ProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find Product");
            return Ok(image);
        }
    }
}