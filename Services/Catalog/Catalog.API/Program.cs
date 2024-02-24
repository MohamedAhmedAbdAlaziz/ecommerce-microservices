using Catalog.API.Data;
using Catalog.API.Repositoies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c=>c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title="catalog.API" , Version="v1"}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Catalog.API v1" ));
}
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
