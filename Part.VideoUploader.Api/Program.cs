using MediatR;
using Part.VideoUploader.Service.Features.Storage.Commands;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(UploadFileCommand).Assembly);
var app = builder.Build();


app.Run();