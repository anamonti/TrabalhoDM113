var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGroup("/person").MapPersonApi();

app.Run();