using FilesParser.Factories;
using FilesParser.Factories.Creation;
using FilesParser.Factories.Reader;
using FilesParser.Services;

var builder = WebApplication.CreateBuilder(args);

// Add dependencies here

builder.Services.AddTransient<ICompanyParserFactory, CompanyParserFactory>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
//builder.Services.AddTransient<ICompanySorterFactory, CompanySorterFactory>();

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();