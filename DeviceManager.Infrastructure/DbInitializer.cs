using Bogus;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Enums;
using DeviceManager.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Infrastructure;

public static class DbInitializer
{
    public static async Task SeedAsync(DeviceManagerDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.Clientes.Any())
        {
            var clienteFaker = new Faker<Cliente>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Nome, f => f.Company.CompanyName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber("##9########"))
                .RuleFor(c => c.Status, f => f.PickRandom(true, false));

            var clientes = clienteFaker.Generate(5); // 5 clientes

            var dispositivos = new List<Dispositivo>();
            var eventos = new List<Evento>();
            var random = new Random();

            foreach (var cliente in clientes)
            {
                for (int i = 0; i < 2; i++) // 2 dispositivos por cliente
                {
                    var dispositivo = new Dispositivo
                    {
                        Id = Guid.NewGuid(),
                        Serial = $"SRL-{Guid.NewGuid().ToString()[..8]}",
                        IMEI = new Faker().Random.AlphaNumeric(15).ToUpper(),
                        DataAtivacao = DateTime.UtcNow.AddDays(-random.Next(1, 365)),
                        ClienteId = cliente.Id
                    };

                    dispositivos.Add(dispositivo);

                    for (int j = 0; j < 5; j++) // 5 eventos por dispositivo
                    {
                        eventos.Add(new Evento
                        {
                            Id = Guid.NewGuid(),
                            DispositivoId = dispositivo.Id,
                            Tipo = new Faker().PickRandom<TipoEvento>(),
                            DataHora = DateTime.UtcNow.AddDays(-random.Next(0, 7))
                        });
                    }
                }
            }

            context.Clientes.AddRange(clientes);
            context.Dispositivos.AddRange(dispositivos);
            context.Eventos.AddRange(eventos);
            await context.SaveChangesAsync();
        }
    }
}
