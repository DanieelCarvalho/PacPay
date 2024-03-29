using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PacPay.App.Servicos;
using PacPay.Infra;
using PacPay.Infra.Contexto;

namespace PacPay.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfiguraInfraApp(builder.Configuration);
            builder.Services.ConfiguraAplicacaoApp();
            builder.Services.Autenticacao(builder.Configuration);
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                x =>
                {
                    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                    });

                    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                },
                            },
                           new List<string>()
                        },
                    });
                }
                );

            var app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            CriarBancoDeDados(app);

            app.UseSwagger();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void CriarBancoDeDados(WebApplication app)
        {
            try
            {
                var escopoDeServico = app.Services.CreateScope();
                var dbContexto = escopoDeServico.ServiceProvider.GetService<AppDbContexto>();

                dbContexto?.Database.EnsureCreated();
                dbContexto?.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}