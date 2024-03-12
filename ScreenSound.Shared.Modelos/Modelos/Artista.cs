﻿namespace ScreenSound.Shared.Modelos.Modelos;

public class Artista
{
    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    public virtual ICollection<AvaliacaoArtista> Avaliacoes { get; set; } = new List<AvaliacaoArtista>();
    public Artista()
    {
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }
    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }

    public void AdicionarNota(int pessoaId, int nota)
    {
        // nota = Math.Min(Math.Max(nota, 1), 5); exemplo do video - Atribui o valor minimo 1 e o valor maximo 5.
        nota = Math.Clamp(nota, 1, 5); // novidadde do .NET 8 que faz a expressão acima em um no metodo em uma passada. 
        Avaliacoes.Add(new AvaliacaoArtista() { ArtistaId = this.Id, PessoaId = pessoaId, Nota = nota });
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do artista {Nome}");
        foreach (var musica in Musicas)
        {
            Console.WriteLine($"Música: {musica.Nome} - Ano de lançamento: {musica.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}