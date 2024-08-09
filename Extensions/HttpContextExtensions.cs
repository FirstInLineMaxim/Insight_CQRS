using CQRS.Core.Commands;
using CQRS.Core.Queries;

namespace CQRS.Extensions
{
    public static class HttpContextExtensions
    {
        public static ICommandHandler<T> GetCommandHandler<T>(this HttpContext context) => context.RequestServices.GetRequiredService<ICommandHandler<T>>();

        public static Task SendCommand<T>(this HttpContext context, T command)
        {
            return context.GetCommandHandler<T>().Handle(command,context.RequestAborted);
        }


        public static IQueryHandler<T,TResult> GetQueryHandler<T,TResult>(this HttpContext context) => context.RequestServices.GetRequiredService<IQueryHandler<T,TResult>>();

        public static Task<TResult> SendQuery<T,TResult>(this HttpContext context,T query) => context.GetQueryHandler<T,TResult>().Handle(query,context.RequestAborted);     
    }
}
