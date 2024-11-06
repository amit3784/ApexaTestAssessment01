
namespace ApexaTechAssess.Api.ExternalSystems
{
    public interface ICustomExceptionLogger
    {
        Task InvokeAsync(HttpContext context, RequestDelegate next);
    }
}