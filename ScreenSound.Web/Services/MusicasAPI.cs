using ScreenSound.Web.Reponses;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class MusicasAPI
{
    private readonly HttpClient _httpClient;

    public MusicasAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<MusicaResponse>?> GetMusicasAysnc()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
    }
}
