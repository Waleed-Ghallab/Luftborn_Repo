using DAL.EF;
using DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Modelinterface.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string txt = "";
builder.Services.AddCors(op =>
{
    op.AddPolicy(txt, op =>
    {
        op.AllowAnyOrigin();  //to allow ajax requests from any outer domain
        op.AllowAnyHeader();
        op.AllowAnyMethod();
    });
});

builder.Services.AddDbContext<App_dbcontext>(op =>
{
    op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"),
        b=>b.MigrationsAssembly(typeof(App_dbcontext).Assembly.FullName));
}
);

//ignore reference loop while serializing objects => max. 3levels
builder.Services.AddControllers().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

//register iBaseRepository
builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));

//register Unit Of Work
//builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(txt);

app.Run();
