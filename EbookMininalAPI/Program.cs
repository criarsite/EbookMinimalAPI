using EbookMininalAPI.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEbookServices, EbookServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.

 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 

app.MapGet("/api/ebooks", async (IEbookServices ebookService) =>
{
    return Results.Ok(await ebookService.GetAll());
});

app.MapGet("/api/ebooks/{id:int}", async (int id, IEbookServices ebookService) =>
{    
    return Results.Ok( await ebookService.GetById(id));
});

app.MapPost("/api/ebooks/",  async (Ebook ebook, IEbookServices ebookService) =>
{
    ebookService.Insert(ebook);
    return Results.Ok(await ebookService.GetAll());
});
 

app.MapDelete("/api/ebooks/{id:int}", async (int id, IEbookServices ebookService) =>
{
     ebookService.Delete(id);
    return Results.Ok(await ebookService.GetAll());
});


app.Run();

