using ScreenSound.Web.Reponses;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class ArtistasAPI
{
    private readonly HttpClient _httpClient;

    public ArtistasAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<ArtistaReponse>?> GetArtistasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ArtistaReponse>>("artistas");
    }
}
