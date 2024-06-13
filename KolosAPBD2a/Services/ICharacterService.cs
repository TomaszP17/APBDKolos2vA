using KolosAPBD2a.RequestModels;
using KolosAPBD2a.ResponseModels;

namespace KolosAPBD2a.Services;

public interface ICharacterService
{
    Task<GetCharacterResonseModel> GetCharacterByIdAsync(int id);
    Task AddProductsToBackPack(CreateBackPackRequestModel data, int id);
}