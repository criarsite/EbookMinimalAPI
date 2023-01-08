var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






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


List<Ebook> ebooks = new()
{
    new(){Id = 1, Title = "Blazor Pro", Year= 2022},
    new(){Id = 2, Title = ".Net Pro", Year= 2021},
    new(){Id = 3, Title = "C# Pro", Year= 2020},
    new(){Id = 4, Title = "Developer Pro", Year= 2019},
    new(){Id = 5, Title = "Development Pro", Year= 2018},
};

app.MapGet("/api/ebooks", () =>
{
    return Results.Ok(ebooks);
});

app.MapGet("/api/ebooks/{id:int}", (int id) =>
{
    return Results.Ok(ebooks.Single(e => e.Id == id));
});

app.MapPost("/api/ebooks/", (Ebook ebook) =>
{
    ebooks.Add(ebook);
    return Results.Ok(ebooks);

});

app.MapPut("/api/ebooks", (Ebook ebook) =>
{
    Ebook foundEbook = ebooks.Single(e => e.Id == ebook.Id);
    
});

app.MapDelete("/api/ebooks/{id:int}", (int id) =>
{
    ebooks.Remove(ebooks.Single( e => e.Id == id));
    return Results.Ok(ebooks);

});


app.Run();




public class Ebook
{
    public int Id {get; set;}
    public string Title {get; set;}
    public int Year {get; set;}
}
