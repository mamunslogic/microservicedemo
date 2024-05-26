using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("BasketDB");
});

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
    (options => options.Address = new Uri(builder.Configuration.GetValue<string>("GrpcSettings:DiscountGrpcUrl")));
builder.Services.AddScoped<DiscountGrpcService>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//builder.WebHost.ConfigureKestrel(options => options.ListenAnyIP(5004, o => o.Protocols = HttpProtocols.Http2));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
