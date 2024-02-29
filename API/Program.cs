using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.ServiceRegistrations;
using DataAccess.ServiceRegistrations;
using Core.ServiceRegistrations;
using Core.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:3000")
    .WithOrigins("https://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()));


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacDataAccessModule());
        builder.RegisterModule(new AutofacBusinessModule());
        builder.RegisterModule(new AutofacCoreModule());
    });

builder.Services.AddServiceRegistrations(new ICoreModule[] {
    new DataAccessModule(),
    new BusinessModule(),
    new CoreModule()
});


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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
