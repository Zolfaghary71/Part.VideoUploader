﻿using Part.VideoUploader.Domain;

namespace Part.VideoUploader.Infrastructure.Db;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<FileUploadInfo> FileUploadInfos { get; set; }

}
