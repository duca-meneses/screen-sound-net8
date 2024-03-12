namespace ScreenSound.API.Reponse;

public record ArtistaResponse(int Id, string Nome, string Bio, string? FotoPerfil)
{
    public double Classificacao { get; set; }
};
