using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Shared.Dados.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Shared.Dados.Banco;
public class ScreenSoundContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<AvaliacaoArtista> AvaliacaoArtistas { get; set; }  


    private string dbconnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public ScreenSoundContext()
    {

    }

    public ScreenSoundContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(dbconnectionString)
            .UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Musica>()
            .HasMany(c => c.Generos)
            .WithMany(C => C.Musicas);

        modelBuilder.Entity<AvaliacaoArtista>()
            .HasKey(a => new { a.ArtistaId, a.PessoaId });

    }
}
