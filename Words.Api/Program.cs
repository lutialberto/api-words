using Microsoft.EntityFrameworkCore;
using Words.Api.Mappers;
using Words.DataAccess;
using Words.DataAccess.Repositories;
using Words.Model.Entities;
using Words.Model.Repositories;
using Words.Model.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add services
builder.Services.AddScoped<IWordService, WordService>();
builder.Services.AddScoped<IWordPermutationWrongGuessesService, WordPermutationWrongGuessesService>();
builder.Services.AddScoped<IWordWordleWrongGuessService, WordWordleWrongGuessService>();

//add repositories
builder.Services.AddDbContext<WordsDBContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=words;Trusted_Connection=True;Encrypt=no;"));
builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<IWordPermutationExpressionRepository, WordPermutationExpressionRepository>();
builder.Services.AddScoped<IWordPermutationWrongGuessesRepository, WordPermutationWrongGuessesRepository>();
builder.Services.AddScoped<IWordWordleWrongGuessRepository, WordWordleWrongGuessRepository>();

//add mappers
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<WordProfile>();
    cfg.AddProfile<PaginationProfile>();
},
AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
