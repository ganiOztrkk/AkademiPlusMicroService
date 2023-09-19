using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AkademiPlusMicroService.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
