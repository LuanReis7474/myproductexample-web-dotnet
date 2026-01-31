using Microsoft.EntityFrameworkCore;
using myproductexameple_web_dotnet_infra;
using myproductexameple_web_dotnet_service;
using myproductexameple_web_dotnet_service.interfaces; // projeto infra com DbContext, Repos etc.

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (Postgres)
builder.Services.AddDbContext<MyProductExampleDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("myproductexameple-web-dotnet-infra") // opcional: onde ficam as migrations
    )
);

builder.Services.AddScoped<IPlanoContaService, PlanoContaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
// Registrar repositórios / serviços (exemplo)
//builder.Services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
//builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<ITransacaoService, TransacaoService>();

// AutoMapper, CORS, Swagger, etc.
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); // ajustar conforme segurança
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
