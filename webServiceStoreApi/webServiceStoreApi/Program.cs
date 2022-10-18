using BusinessLayer.Interfaces;
using BusinessLayer.Repositories;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {

            //you can configure your custom policy
            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});

builder.Services.AddScoped<ICustomer, ICustomerRepository>();
builder.Services.AddScoped<IItem, IItemRepository>();
builder.Services.AddScoped<IInvoice, IInvoiceRepository>();


builder.Services.AddScoped<IArticulo, ArticuloRepository>();
builder.Services.AddScoped<ICliente, IClienteRepository>();
builder.Services.AddScoped<IFactura, FacturaRepository>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
//    dataContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}





app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
