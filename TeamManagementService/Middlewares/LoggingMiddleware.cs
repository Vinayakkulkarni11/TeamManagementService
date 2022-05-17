using System.Text;

namespace TeamManagementService.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next,ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {            
            var request = await FormatRequest(context.Request);

            
            var originalBodyStream = context.Response.Body;

            
            using (var responseBody = new MemoryStream())
            {                
                context.Response.Body = responseBody;
                
                await _next(context);
                
                var response = await FormatResponse(context.Response);

                _logger.LogInformation("request for {endpoint} at {RequestTime} with {request}",context.Request.Path,DateTime.Now, request);
                _logger.LogInformation("Response for {endpoint} at {RequestTime} with {response}", context.Request.Path, DateTime.Now, response);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            //This line allows us to set the reader for the request back at the beginning of its stream.
            request.EnableBuffering();

            string bodyAsText;
            var body = request.Body;

            using (var reader = new StreamReader(
                request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true))
                {
                bodyAsText = await reader.ReadToEndAsync();
                request.Body = body;  
                request.Body.Position = 0;
                }

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            //We need to read the response stream from the beginning...
            response.Body.Seek(0, SeekOrigin.Begin);

            //...and copy it into a string
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            //We need to reset the reader for the response so that the client can read it.
            response.Body.Seek(0, SeekOrigin.Begin);

            //Return the string for the response, including the status code (e.g. 200, 404, 401, etc.)
            return $"{response.StatusCode}: {text}";
        }
    }
}
