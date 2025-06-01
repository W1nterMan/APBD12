using APBD12.Data;
using APBD12.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//adding controllers
builder.Services.AddControllers();

//adding dbcontext
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);    

//adding services
builder.Services.AddScoped<ITripsService,TripsService>();
builder.Services.AddScoped<IClientsService,ClientsService>();
builder.Services.AddScoped<IClientTripService,ClientTripService>();

var app = builder.Build();

app.UseAuthentication();

app.MapControllers();

app.Run();