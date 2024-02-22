using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "The Beatles", "The Beatles foi uma banda de rock inglesa, formada na cidade de Liverpool em 1960. Com os integrantes John Lennon, Paul McCartney, George Harrison e Ringo Starr, o grupo tornou-se altamente reconhecido como o melhor e mais bem sucedido da era do rock.", "https://live.staticflickr.com/4125/4835865032_1e1951085b_b.jpg" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Nirvana", "Nirvana foi uma banda norte-americana de rock formada pelo vocalista e guitarrista Kurt Cobain e pelo baixista Krist Novoselic em Aberdeen no ano de 1987. O grupo obteve grande sucesso no movimento grunge de Seattle no início dos anos 1990.", "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/aa4eb728-5871-4e5c-904e-eaeb17bfe13f/d4qcjxb-9fc1b093-2be3-4f72-9b7f-6a662cd148d9.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2FhNGViNzI4LTU4NzEtNGU1Yy05MDRlLWVhZWIxN2JmZTEzZlwvZDRxY2p4Yi05ZmMxYjA5My0yYmUzLTRmNzItOWI3Zi02YTY2MmNkMTQ4ZDkuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Qb4TrIVDSkgaYyRTZEQy8o--a62mA7s_73vtir40vbo" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Avenged SevenFold", "Avenged Sevenfold, também conhecida pela abreviação A7X, é uma banda de heavy metal americana formada em 1999 na cidade de Huntington Beach, Califórnia. O grupo é composto atualmente pelo vocalista M. Shadows, o guitarrista base Zacky Vengeance, o guitarrista solo Synyster Gates, o baixista Johnny Christ e o baterista Brooks Wackerman.", "https://live.staticflickr.com/4104/5019866055_d66a3bc187.jpg" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Imagine Dragons", "Imagine Dragons é uma banda de rock alternativo originária de Las Vegas, Nevada, EUA. Formada em 2008, a banda ganhou destaque com seu som distintivo e letras emocionais. Os membros fundadores incluem o vocalista Dan Reynolds, o guitarrista Wayne Sermon, o baixista Ben McKee e o baterista Daniel Platzman. Juntos, eles criaram uma mistura única de rock, pop e eletrônica, que cativou fãs em todo o mundo", "https://i.etsystatic.com/36622473/r/il/86ed45/4088535174/il_fullxfull.4088535174_pb4j.jpg" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Linkin Park", "Linkin Park é uma banda de rock dos Estados Unidos formada em Agoura Hills, Califórnia. A formação atual da banda inclui o vocalista e multi-instrumentista Mike Shinoda, o guitarrista Brad Delson, o baixista Dave Farrell, o DJ Joe Hahn e o baterista Rob Bourdon, todos membros fundadores", "https://upload.wikimedia.org/wikipedia/commons/7/74/Linkin_Park_2017_logo_after_Bennington%27s_death.svg" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Post Malone", "Post Malone, cujo nome verdadeiro é Austin Richard Post, é um cantor, rapper, compositor, empresário, produtor musical e ator norte-americano. Ele nasceu em Syracuse, Nova York, em 4 de julho de 1995. Conhecido por suas tatuagens, composições introspectivas e estilo vocal lacônico, Post Malone ganhou aclamação por misturar uma variedade de gêneros musicais. Sua música abrange elementos do hip-hop, rock, pop e R&B.", "https://ih1.redbubble.net/image.5146690635.1405/raf,750x1000,075,t,101010:01c5ca27c6.jpg" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Blur", "Blur é uma banda britânica de britpop e rock alternativo. Formada em 1989, em Londres, o grupo é composto pelo vocalista Damon Albarn, o guitarrista Graham Coxon, o baixista Alex James e o baterista Dave Rowntree", "https://static.wikia.nocookie.net/blur-band/images/9/95/Blur-01.jpg/revision/latest?cb=20150915204855" });
                         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
