using picpay_desafio_backend.Infra.Data.Seed;
using picpay_desafio_backend.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureAPI(builder.Configuration);

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

SeedUserRoles(app);

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
    {
        var seedUsers = serviceScope.ServiceProvider.GetService<ISeedUsers>();
        var seedTransactions = serviceScope.ServiceProvider.GetService<ISeedTransactions>();

        seedUsers.removeUsers();
        seedUsers.seedUsers();

        seedTransactions.removeTransactions();

    }
}