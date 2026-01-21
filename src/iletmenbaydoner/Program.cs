using iletmenbaydoner.Business.Abstract;
using iletmenbaydoner.Business.Concrete;
using iletmenbaydoner.DataAccess.Abstract;
using iletmenbaydoner.DataAccess.Concrete.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<iletmenbaydonerDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CloudBeaverContext")));

builder.Services.AddScoped<IClientDal, EfClientRepository>();
builder.Services.AddScoped<IClientService, ClientManager>();

builder.Services.AddScoped<IBranchDal, EfBranchRepository>();
builder.Services.AddScoped<IBranchService, BranchManager>();

builder.Services.AddScoped<IProductGroupDal, EfProductGroupRepository>();
builder.Services.AddScoped<IProductGroupService, ProductGroupManager>();

builder.Services.AddScoped<IProductGroupTypeDal, EfProductGroupTypeRepository>();
builder.Services.AddScoped<IProductGroupTypeService, ProductGroupTypeManager>();

builder.Services.AddScoped<IBranchProductDal, EfBranchProductRepository>();
builder.Services.AddScoped<IBranchProductService, BranchProductManager>();

builder.Services.AddScoped<IOrderHeaderDal, EfOrderHeaderRepository>();
builder.Services.AddScoped<IOrderHeaderService, OrderHeaderManager>();

builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
