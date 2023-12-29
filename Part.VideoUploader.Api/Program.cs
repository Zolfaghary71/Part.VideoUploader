using MediatR;
using Part.VideoUploader.Service.Features.Storage.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(UploadFileCommand).Assembly);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; 
    options.InstanceName = "SampleInstance";
});

var app = builder.Build();

app.Run();