using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using picpay_desafio_backend.Application.Interfaces;
using picpay_desafio_backend.Application.Mappings;
using picpay_desafio_backend.Application.Services;
using picpay_desafio_backend.Domain.Interfaces;
using picpay_desafio_backend.Infra.Data.Context;
using picpay_desafio_backend.Infra.Data.Repositories;
using picpay_desafio_backend.Infra.Data.Seed;

namespace picpay_desafio_backend.IoC
{
	public static class DependencyInjectionAPI
	{
		public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
		{
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ISeedUsers, SeedUsers>();
            services.AddScoped<ISeedTransactions, SeedTransactions>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();
            services.AddScoped<INotificacaoService, NotificacaoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
	}
}

