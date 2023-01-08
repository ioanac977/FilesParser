using FilesParser.Factories;
using FilesParser.Factories.Creation;
using FilesParser.Factories.Reader;
using FilesParser.Services;
using System.IO.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add dependencies here
builder.Services.AddTransient<IFileSystem, FileSystem>();
builder.Services.AddTransient<ICompanyReader, CompanyReader>();
builder.Services.AddTransient<ICompanyParserFactory, CompanyParserFactory>();
builder.Services.AddTransient<ICompanyService, CompanyService>();



// Add other services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();