
namespace ApexaTechAssess.Api.ExternalSystems
{
    /// <summary>
    /// Custom exception logger interface
    /// </summary>
    public interface ICustomExceptionLogger
    {
        /// <summary>
        /// Task to invoke request delegate
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        Task InvokeAsync(HttpContext context, RequestDelegate next);
    }
}