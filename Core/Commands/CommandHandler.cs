namespace CQRS.Core.Commands
{
          public interface ICommandHandler<in T>
    {
        Task Handle(T command, CancellationToken cancellationToken = default);
    }
    public delegate Task CommandHandler<in T>(T command, CancellationToken cancellationToken = default);   
    
    public static class CommandHandlerConfiguration
    {
            public static IServiceCollection AddCommandHandler<T, TCommandHandler>(
        this IServiceCollection services,
        Func<IServiceProvider, TCommandHandler>? configure = null
    ) where TCommandHandler : class, ICommandHandler<T>
    {
        if (configure == null)
        {
            services.AddTransient<TCommandHandler, TCommandHandler>();
            services.AddTransient<ICommandHandler<T>, TCommandHandler>();
        }
        else
        {
            services.AddTransient<TCommandHandler, TCommandHandler>(configure);
            services.AddTransient<ICommandHandler<T>, TCommandHandler>(configure);
        }

        services
            .AddTransient<Func<T, CancellationToken, Task>>(
                sp => sp.GetRequiredService<ICommandHandler<T>>().Handle
            )
            .AddTransient<CommandHandler<T>>(
                sp => sp.GetRequiredService<ICommandHandler<T>>().Handle
            );

        return services;
    }
    }
}
