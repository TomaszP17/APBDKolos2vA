using KolosAPBD2a.Models;

namespace KolosAPBD2a.ResponseModels;

public class GetCharacterResonseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<GetItemResponseModel> BackPackItems { get; set; }
    public List<GetCharacterTitleResponseModel> Titles { get; set; }
    
}