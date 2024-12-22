using Hangfire;
using Hangfire.MySql;
using SpyCheif.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.CreateSecretServices();
builder.Services.AddCors(option => option.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

string connection = "Server=localhost;Database=Hangfire;Uid=root;Pwd=123456789;Allow User Variables=True";
builder.Services.AddHangfire(config => config.UseStorage(new MySqlStorage(connection, new MySqlStorageOptions())));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

//app.UseMiddleware(typeof(ValidationMiddleware));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseCors();
app.MapControllers();

app.Run();
