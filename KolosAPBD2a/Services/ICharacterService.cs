using KolosAPBD2a.Models;
using KolosAPBD2a.RequestModels;
using KolosAPBD2a.ResponseModels;

namespace KolosAPBD2a.Services;

public interface ICharacterService
{
    Task<GetCharacterResonseModel> GetCharacterByIdAsync(int id);
    Task<IEnumerable<GetBackPackResponseModel>> AddProductsToBackPack(CreateBackPackRequestModel data, int id);
}