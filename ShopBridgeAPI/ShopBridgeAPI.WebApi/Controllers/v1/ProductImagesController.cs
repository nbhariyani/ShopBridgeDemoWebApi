using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ShopBridgeAPI.Application.Exceptions;
using ShopBridgeAPI.Application.Features.Products.Commands.UploadProductImage;
using ShopBridgeAPI.Application.Features.Products.Queries.GetAllProducts;
using ShopBridgeAPI.Application.Features.Products.Queries.GetProductById;
using System.IO;
using System.Threading.Tasks;

namespace ShopBridgeAPI.WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    public class ProductImagesController : BaseApiController
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public ProductImagesController(IWebHostEnvironment webHostEnvironment)
        { _webHostEnvironment = webHostEnvironment; }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> ShowAllProductImages([FromQuery] GetAllProductsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllProductImagesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> UploadProductImage(int productId, [FromForm] ImageUpload imageUpload)
        {
            if (imageUpload.files.Length == 0)
                throw new ApiException($"Please select proper file.");

            string path = _webHostEnvironment.WebRootPath + "\\ProductImages\\" + productId.ToString() + "\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (System.IO.File.Exists(path + imageUpload.files.FileName))
                throw new ApiException($"Same file already exists.");

            UploadProductImageCommand command = new UploadProductImageCommand
            {
                ProductId = productId,
                ImageName = imageUpload.files.FileName
            };

            var result = await Mediator.Send(command);

            if (result.Data != 0)
            {
                using FileStream fileStream = System.IO.File.Create(path + imageUpload.files.FileName);
                await imageUpload.files.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                result.Message = "Upload Done.";
            }

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> DownloadProductImage(int productId, string imageNameOrId)
        {
            string path = _webHostEnvironment.WebRootPath + "\\ProductImages\\" + productId.ToString() + "\\";

            string filePath = path + imageNameOrId;

            if (!System.IO.File.Exists(filePath))
            {
                int.TryParse(imageNameOrId, out int imageId);
                if (imageId != 0)
                {
                    var result = await Mediator.Send(new GetProductImageByIdQuery { Id = imageId, ProductId = productId });
                    filePath = path + result.Data.ImageName;
                }
            }

            if (!System.IO.File.Exists(filePath))
                throw new ApiException($"Image not found.");

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }

    public class ImageUpload
    {
        public IFormFile files { get; set; }
    }
}
