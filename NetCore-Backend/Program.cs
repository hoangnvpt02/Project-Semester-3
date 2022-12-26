using NetCore_Backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corspolicy",
        policy =>
        {
            policy.WithOrigins("https://localhost:5002") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);


var app = builder.Build();
app.UseCors("corspolicy");
startup.Configure(app, builder.Environment);
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
