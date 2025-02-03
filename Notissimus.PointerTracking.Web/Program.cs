using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);
// TODO: delete
// {
//     var services = builder.Services;
//     services.AddSwaggerGen();
//     services.AddEndpointsApiExplorer();
// }

var app = builder.Build();
// TODO: delete
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

var fileExts = new FileExtensionContentTypeProvider();
fileExts.Mappings[".module.js"] = "module";

app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = fileExts, });

app.MapGet("api/api-uri", GetUri);

app.Run();

return;

UriDto GetUri()
{
    return new UriDto
    {
        // TODO: move to appsettings.json
        Uri = new Uri("http://localhost:8081"),
    };
}

class UriDto
{
    public Uri Uri { get; set; }
}