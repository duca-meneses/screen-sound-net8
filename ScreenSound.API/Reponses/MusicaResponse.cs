namespace ScreenSound.API.Reponses;

public record MusicaResponse(int Id, string Nome, int? AnoLancamento,
    int ArtistaId, string NomeArtista );
