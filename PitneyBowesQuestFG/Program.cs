using Microsoft.EntityFrameworkCore;
using PitneyBowesQuestFG.DB;
using PitneyBowesQuestFG.Repository_Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Serilog
var logger = new LoggerConfiguration()
	.WriteTo.Console() // moja twórczosc
	.ReadFrom.Configuration(builder.Configuration)
	.Enrich.FromLogContext()
	.CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//* Serilog
builder.Services.AddDbContext<InMemoryDBContext>(options => options.UseInMemoryDatabase("AdressBookDB"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await CreateDB(app);

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

async Task CreateDB(IHost host)
{
    await using var scope = host.Services.CreateAsyncScope();
    var services = scope.ServiceProvider;
	try
	{
		var context = services.GetRequiredService<InMemoryDBContext>();
		await Seeder.Seed(context);
	}
	catch (Exception)
	{
		//TO DO
		//serilog
		throw;
	}
}