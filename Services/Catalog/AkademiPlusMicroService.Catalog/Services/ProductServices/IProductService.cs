using AkademiPlusMicroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMicroService.Catalog.Dtos.ProductDtos;
using AkademiPlusMicroService.Shared.Dtos;

namespace AkademiPlusMicroService.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<CreateProductDto>>> GetAllProducts();
        Task<Response<ResultProductDto>> GetCategoryById(string id);
        Task<Response<NoContent>> CreateCategory(CreateProductDto createProductDto);
        Task<Response<NoContent>> UpdateCategory(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteCategory(string id);
    }
}
