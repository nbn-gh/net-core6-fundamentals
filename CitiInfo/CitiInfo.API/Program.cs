using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Logging Related
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// for supporting file type
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Marks the position in the middleware pipeline where a routing decision is made
app.UseRouting();

app.UseAuthorization();

// Marks the position in the middleware pipeline where the selected endpoint is executed
// Here we are using the attribute routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
