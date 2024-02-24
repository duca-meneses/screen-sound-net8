namespace ScreenSound.API.Reponse;

public record MusicaResponse(int Id, string Nome, int? AnoLancamento,
    int ArtistaId, string NomeArtista);
