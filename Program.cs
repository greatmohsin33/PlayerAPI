using PlayerAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=players.db"));
var app = builder.Build();
app.MapControllers();
app.Run();
