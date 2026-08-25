var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.MapGet("/", () => $"Hello World! ");

app.MapGet("/banana", () => "voce chamou o metodo Banana");


app.Run();