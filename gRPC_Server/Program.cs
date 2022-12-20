using gRPC_Server.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpc()
    .AddJsonTranscoding();

var app = builder.Build();

app.MapGrpcService<MessageService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
