using Microsoft.AspNetCore.StaticFiles;

namespace MouseTracking.Api;

internal static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseStaticServer(this IApplicationBuilder app)
    {
        var fileExts = new FileExtensionContentTypeProvider();
        fileExts.Mappings[".module.js"] = "module";

        app.UseDefaultFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider = fileExts
        });

        return app;
    }
}