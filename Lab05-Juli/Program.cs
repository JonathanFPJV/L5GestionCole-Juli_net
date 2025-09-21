using Lab05_Juli.Models;
using Lab05_Juli.Repository;
using Lab05_Juli.Repository.Implements;
using Lab05_Juli.Service;
using Lab05_Juli.Service.Implements;
using Lab05_Juli.UnitOfWork;
using Lab05_Juli.UnitOfWork.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1️ Agregar servicios de controllers
builder.Services.AddControllers();

// 2️ Configurar EF Core con MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GestioncoleContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//registro del maper
builder.Services.AddAutoMapper(typeof(Program));
// Registro del repositorio generico
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// Registro de Repositorios
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
//Registro del Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//registro de los servicios

builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaAservice>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJs",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // URL de tu aplicación Next.js
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
// 3 Configurar Swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gestión Cole",
        Description = "API REST para gestionar estudiantes, cursos, matrículas, profesores y evaluaciones.",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "soporte@gestioncole.com"
        }
    });

    // Incluir comentarios XML (si activaste <GenerateDocumentationFile>true</GenerateDocumentationFile> en el .csproj)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    }
});

var app = builder.Build();

// 4 Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    // Swagger UI disponible en / (root)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gestión Cole v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowNextJs");
app.UseAuthorization();

// 5 Mapear controladores (ya no usaremos WeatherForecast en minimal API)
app.MapControllers();

app.Run();