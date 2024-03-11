using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScreenSound.API.Endpoints;
using ScreenSound.Shared.Dados.Banco;
using ScreenSound.Shared.Dados.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
        .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
        .UseLazyLoadingProxies();
});

builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<ScreenSoundContext>();

builder.Services.AddAuthorization();

builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddTransient<DAL<Genero>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure< Microsoft.AspNetCore.Http.Json.JsonOptions >(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([builder.Configuration["BackendURL"] ?? "https://localhost:7203",
            builder.Configuration["FrontendURL"] ?? "https://localhost:7198"])
            .AllowAnyMethod()
            .SetIsOriginAllowed(pol => true)
            .AllowAnyHeader()
            .AllowCredentials()));



var app = builder.Build();

app.UseCors("wasm");

app.UseStaticFiles();
app.UseAuthorization();


app.AddEndpointsArtistas();
app.AddEndpointsMusicas();
app.AddEndpointsGeneros();

app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autoriza��o");

app.MapPost("auth/logout", async ([FromServices] SignInManager<PessoaComAcesso> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Autoriza��o");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
