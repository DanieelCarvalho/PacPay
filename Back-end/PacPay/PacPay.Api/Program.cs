using CleanArchitectureTraining.Application.Services;
using PacPay.Infra;
using PacPay.Infra.Contexto;

namespace PacPay.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfiguraInfraApp(builder.Configuration);
            builder.Services.ConfiguraAplicacaoApp();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            CriarBancoDeDados(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}