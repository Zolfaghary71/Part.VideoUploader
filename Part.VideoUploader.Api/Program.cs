using MediatR;
using Microsoft.EntityFrameworkCore;
using Part.VideoUploader.Infrastructure.Db;
using Part.VideoUploader.Infrastructure.Repository;
using Part.VideoUploader.Infrastructure.Storage;
using Part.VideoUploader.Service.Contracts.Infrastructure;
using Part.VideoUploader.Service.Features.Storage.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(UploadFileCommand).Assembly);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFileUploadInfoRepository, FileUploadInfoRepository>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost"; 
    options.InstanceName = "SampleInstance";
});

builder.Services.AddTransient<IStorageService, StorageService>();

var app = builder.Build();

app.Run();