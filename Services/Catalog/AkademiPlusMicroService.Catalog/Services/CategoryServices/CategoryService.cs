using AkademiPlusMicroService.Catalog.Dtos.CategoryDtos;
using AkademiPlusMicroService.Catalog.Models;
using AkademiPlusMicroService.Catalog.Settings;
using AkademiPlusMicroService.Shared.Dtos;
using AutoMapper;
using MongoDB.Driver;

namespace AkademiPlusMicroService.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<ResultCategoryDto>>> GetAllCategories()
        {
            var values = await _categoryCollection.Find(x=>true).ToListAsync();
            return Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(values), 200);
        }

        public async Task<Response<ResultCategoryDto>> GetCategoryById(string id)
        {
            var values = await _categoryCollection.Find<Category>(x=>x.CategoryId==id).FirstOrDefaultAsync();
            if (values == null)
            {
                return Response<ResultCategoryDto>.Fail("Kategori bulunamadı.", 404);
            }
            else
            {
                return Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(values), 200);
            }
        }

        public async Task<Response<NoContent>> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            var result =
                await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId,
                    values);
            if (result == null)
            {
                return Response<NoContent>.Fail("Kategori Bulunamadı", 404);
            }
            else
            {
                return Response<NoContent>.Success(204);
            }
        }

        public async Task<Response<NoContent>> DeleteCategory(string id)
        {
            var values = await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
            return Response<NoContent>.Success(204);
        }
    }
}
