using Microsoft.AspNetCore.Builder;
using MS.MediCenter.WebAPI.Middlewares;

namespace MS.MediCenter.WebAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseErrorHandlerException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
