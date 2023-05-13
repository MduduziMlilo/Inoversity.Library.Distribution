using InoversityLibrary.Application.Extensions;
using InoversityLibrary.DataAccess.Extensions;
using InoversityLibrary.Infrastructure.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("DocumentsOrigins",
    policy => { policy.WithOrigins("https://localhost:7100").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors("DocumentsOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();