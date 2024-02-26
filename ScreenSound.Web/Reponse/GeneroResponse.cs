namespace ScreenSound.Web.Reponse;

public record GeneroResponse(int Id, string Nome, string Descricao)
{
    public override string ToString()
    {
        return $"{this.Nome}";
    }
}
