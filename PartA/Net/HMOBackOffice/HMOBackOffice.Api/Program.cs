using HMOBackOffice.Api.Mapping;
using HMOBackOffice.Core.Mapping;
using HMOBackOffice.Core.Repository;
using HMOBackOffice.Core.Service;
using HMOBackOffice.Data;
using HMOBackOffice.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IVaccinationForMemberService, VaccinationForMemberService>();
builder.Services.AddScoped<IVaccinationForMemberRepository, VaccinationForMemberRepository>();
builder.Services.AddScoped<IVaccinationService, VaccinationService>();
builder.Services.AddScoped<IVaccinationRepository, VaccinationRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(ApiMappingProfile), typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(p => p
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
