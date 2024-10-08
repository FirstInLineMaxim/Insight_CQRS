﻿using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Core.Queries
{
    public interface IQueryHandler<in T, TResult>
{
    Task<TResult> Handle(T query, CancellationToken ct);
}
 public static class QueryHandlerConfiguration
    {
        public static IServiceCollection AddQueryHandler<T,TResult,TQueryHandler>(this IServiceCollection services,Func<IServiceProvider,TQueryHandler>? configure= null) where TQueryHandler: class , IQueryHandler<T, TResult>
        {
            if(configure == null)
            {
                services.AddTransient<TQueryHandler,TQueryHandler>();
                services.AddTransient<IQueryHandler<T,TResult>,TQueryHandler>();
            }
            else
            {
               services.AddTransient<TQueryHandler,TQueryHandler>(configure);
                services.AddTransient<IQueryHandler<T,TResult>,TQueryHandler>(configure);
            }

            return services;
        }
    }
}
