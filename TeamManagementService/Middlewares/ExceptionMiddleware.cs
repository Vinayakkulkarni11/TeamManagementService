using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace TeamManagementService.Middlewares
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _requestDelegate { get; set; }
        public ILogger<ExceptionMiddleware> _logger { get; }

        public ExceptionMiddleware(RequestDelegate requestDelegate,ILogger<ExceptionMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
               await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Exception for {endpoint} at {RequestTime} with error {error}", context.Request.Path, DateTime.Now,ex.Message);
                response.Success = false;
                response.Message = ex.Message;
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response),Encoding.UTF8);                
                
            }
        }
    }
}
