var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
builder.Services.AddControllers();
=======
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
>>>>>>> d8107e5b6abb07adf686cf510def205e4bc129e0
builder.Services.AddOpenApi();

var app = builder.Build();

<<<<<<< HEAD
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
=======
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
>>>>>>> d8107e5b6abb07adf686cf510def205e4bc129e0
