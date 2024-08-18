using GoodHamburguer.API.Configurations;
using GoodHamburguer.API.Validator.Request;
using GoodHamburguer.Data.InMemoryContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<OrderRequestValidator>();

builder.Services.AddDbContext<SandwichContext>(options => options.UseInMemoryDatabase("SandwichDb"));
builder.Services.AddDbContext<FriesContext>(options => options.UseInMemoryDatabase("FriesDb"));
builder.Services.AddDbContext<DrinkContext>(options => options.UseInMemoryDatabase("DrinkDb"));
builder.Services.AddDbContext<OrderContext>(options => options.UseInMemoryDatabase("OrderDb"));
builder.Services.AddDbContext<OrderSandwichContext>(options => options.UseInMemoryDatabase("OrderSandwichDb"));
builder.Services.AddDbContext<OrderFriesContext>(options => options.UseInMemoryDatabase("OrderFriesDb"));
builder.Services.AddDbContext<OrderDrinkContext>(options => options.UseInMemoryDatabase("OrderDrinkDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SandwichContext>();
    dbContext.Database.EnsureCreated();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FriesContext>();
    dbContext.Database.EnsureCreated();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DrinkContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
