using WebApplication1.Models;

WebApplication app = WebApplication.Create(args);


app.MapGet("/", () => "Hello World! by " + app.Configuration["Data:Author"]);

app.MapPost("/api/registra-reporte", (HttpRequest request) =>
{
    if(!request.Form.Files.Any())
    {
        return Results.BadRequest("At least 1 file is needed.");
    }

    foreach(var file in request.Form.Files)
    {
        app.Logger.LogInformation(file.FileName);
    }

    return Results.Ok($"Imagenes: {request.Form.Files.Count}");
});

app.Run();
