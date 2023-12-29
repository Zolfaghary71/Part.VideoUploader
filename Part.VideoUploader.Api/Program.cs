using MediatR;
using Part.VideoUploader.Infrastructure.RabbitMq;
using Part.VideoUploader.Infrastructure.Storage;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.Storage.Commands;
using Part.VideoUploader.Service.Features.UploadQueue.Command;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(UploadFileCommand).Assembly);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; 
    options.InstanceName = "SampleInstance";
});

builder.Services.AddTransient<IQueue<EnqueueVideoUploadCommand>, RabbitMqQueue<EnqueueVideoUploadCommand>>();
builder.Services.AddTransient<IStorageService, StorageService>();

var app = builder.Build();

app.Run();