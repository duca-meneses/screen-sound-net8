﻿using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Reponses;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class GeneroExtensions
{
    public static void AddEndpointsGeneros(this WebApplication app)
    {
        app.MapPost("/Generos", ([FromServices] DAL<Genero> dal,
            [FromBody] GeneroRequest generoRequest) => 
        {
            dal.Adicionar(RequestToEntity(generoRequest));
            return Results.Ok();

        });
        app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
        {
            var listaGeneros = dal.Listar();
            if (listaGeneros is null)
            {
                return Results.NotFound();
            }
            var listaGeneroResponse = EntityListToResponseList(listaGeneros);
            return Results.Ok(listaGeneroResponse);
        });

        app.MapGet("/Generos/{nome}", ([FromServices] DAL<Genero> dal, string nome) =>
        {
            var genero = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (genero is not null)
            {
                var response = EntityToResponse(genero!);
                return Results.Ok(response);
            }
            return Results.NotFound("Gênero não encontrado.");
        });

        app.MapDelete("/Generos/{id}", ([FromServices] DAL<Genero> dal, int id) =>
        {
            var genero = dal.RecuperarPor(a => a.Id == id);
            if (genero is null)
            {
                return Results.NotFound("Gênero para exclusão não encontrado.");
            }
            dal.Deletar(genero);
            return Results.NoContent();
        });
    }
    private static Genero RequestToEntity(GeneroRequest generoRequest)
    {
        return new Genero() { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };
    }

    private static ICollection<GeneroResponse> EntityListToResponseList(IEnumerable<Genero> generos)
    {
        return generos.Select(a => EntityToResponse(a)).ToList();
    }

    private static GeneroResponse EntityToResponse(Genero genero)
    {
        return new GeneroResponse(genero.Id, genero.Nome!, genero.Descricao!);
    }
}
