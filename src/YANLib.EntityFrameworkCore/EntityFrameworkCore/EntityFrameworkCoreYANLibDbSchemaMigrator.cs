﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YANLib.Data;
using Volo.Abp.DependencyInjection;

namespace YANLib.EntityFrameworkCore;

public class EntityFrameworkCoreYANLibDbSchemaMigrator
    : IYANLibDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreYANLibDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the YANLibDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<YANLibDbContext>()
            .Database
            .MigrateAsync();
    }
}
