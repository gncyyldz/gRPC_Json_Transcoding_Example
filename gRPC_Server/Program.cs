using gRPC_Server.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyMethod()
                                                                             .AllowAnyHeader()
                                                                             .AllowAnyOrigin()));

builder.Services.AddGrpc()
    .AddJsonTranscoding();

builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "gRPC Transcoding",
        Version = "v1"
    });

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "gRPC_Server.xml");
    options.IncludeXmlComments(filePath);
    options.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});

var app = builder.Build();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.MapGrpcService<MessageService>();
app.MapGrpcService<PersonService>();
app.MapGet("/", () => "");

app.Run();
