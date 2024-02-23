using ScreenSound.Web.Reponses;
using ScreenSound.Web.Requests;
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

    public async Task AddArtistaAsync(ArtistaRequest artista)
    {
        await _httpClient.PostAsJsonAsync("artistas", artista);
    }

    public async Task DeleteArtistaAsync(int id)
    {
        await _httpClient.DeleteAsync($"artistas/{id}");    
    }

    public async Task<ArtistaReponse?> GetArtistaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<ArtistaReponse>($"artistas/{nome}");
    }

    public async Task UpdateArtistaAsync(ArtistaRequestEdit artista)
    {
        await _httpClient.PutAsJsonAsync($"artistas", artista);
    }

}
