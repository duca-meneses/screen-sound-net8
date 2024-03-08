using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Reponse;
using ScreenSound.API.Requests;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndpointsArtistas(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("artistas")
            .RequireAuthorization().WithTags("Artistas");

        #region Endpoint Artistas
        groupBuilder.MapGet("", ([FromServices] DAL<Artista> dal) =>
        {
            var listaDeArtista = dal.Listar();
            if (listaDeArtista is null)
            {
                return Results.NotFound();
            }
            var listaDeArtistaResponse = EntityListToResponse(listaDeArtista);
            return Results.Ok(listaDeArtistaResponse);

        }).RequireAuthorization();

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(artista);
        });

        groupBuilder.MapPost("", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var nome = artistaRequest.nome.Trim();
            var imagemArtista = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

            var path = Path.Combine(env.ContentRootPath,"wwwroot", "FotosPerfil", imagemArtista);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(artistaRequest.fotoPerfil!));
            using FileStream fs = new(path, FileMode.Create);
            await ms.CopyToAsync(fs);

            var artista = new Artista(artistaRequest.nome, artistaRequest.bio)
            {
                FotoPerfil = $"/FotosPerfil/{imagemArtista}"
            };

            dal.Adicionar(artista);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artista = dal.RecuperarPor(a => a.Id == id);
            if (artista is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(artista);
            return Results.NoContent();
        });

        groupBuilder.MapPut("", ([FromServices] DAL<Artista> dal, 
            [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
        
            var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.Id);
            if (artistaAAtualizar is null)
            {
                return Results.NotFound();
            }
            artistaAAtualizar.Nome = artistaRequestEdit.nome;
            artistaAAtualizar.Bio = artistaRequestEdit.bio;

            dal.Atualizar(artistaAAtualizar);
            return Results.Ok();
        });
        #endregion

    }

    private static ICollection<ArtistaResponse> EntityListToResponse(IEnumerable<Artista> listaDeArtistas)
    {
        return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
    }

    private static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    }
}
