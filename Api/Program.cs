global using Api;
global using Api.Controllers;
global using Api.Models;
global using Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNpgsql<PharmacyContext>(builder.Configuration.GetConnectionString("PostgresConnection"));
builder.Services.AddScoped<IAsyncRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<IAsyncRepository<Doctor>, DoctorRepository>();
builder.Services.AddScoped<IAsyncRepository<Pharmacy>, PharmacyRepository>();
builder.Services.AddScoped<IAsyncRepository<Prescription>, PrescriptionRepository>();
builder.Services.AddScoped<IAuditLogger, AuditLogger>();

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DefaultModelExpandDepth(-1));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
