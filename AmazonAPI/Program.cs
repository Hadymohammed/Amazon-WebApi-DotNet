using System.Text;
using AmazonAPI.Data;
using AmazonAPI.Data.Repository;
using AmazonAPI.Data.Repository.Services;
using AmazonAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var DbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DbConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "Amazon",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AmazonAPIAmazon"))
    };
});


// Add Repositories
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductPhotoService, ProductPhotoService>();
builder.Services.AddScoped<IProductTagService, ProductTagService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IWishListItemService, WishListItemService>();

var app = builder.Build();

AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
