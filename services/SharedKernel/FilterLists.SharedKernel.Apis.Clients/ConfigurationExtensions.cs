﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace FilterLists.SharedKernel.Apis.Clients
{
    public static class ConfigurationExtensions
    {
        public static void AddApiClients(this IServiceCollection services)
        {
            // TODO: use SystemTextJsonContentSerializer() once less feature-limited
            services.AddRefitClient<IDirectoryApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://directory-api"));
        }
    }
}