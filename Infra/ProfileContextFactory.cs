﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra
{
    public class ProfileContextFactory : IDesignTimeDbContextFactory<WriteContext>

    {
        public WriteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WriteContext>();
            optionsBuilder.UseSqlite("Data Source=./ProfileDb.db;Cache=Shared");

            return new WriteContext(optionsBuilder.Options);
        }
    }
}