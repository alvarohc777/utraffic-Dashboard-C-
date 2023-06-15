using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Serilog;
namespace Solicitudes.Filters;

public class LogActionFilter : IActionFilter
{
  private readonly ILogger<LogActionFilter> _logger;

  public LogActionFilter(ILogger<LogActionFilter> logger)
  {
    _logger = logger;
  }

  public void OnActionExecuting(ActionExecutingContext context)
  {
    var actionName = context.ActionDescriptor.DisplayName;
    var currentTime = DateTime.Now;

    _logger.LogInformation("Executing {ActionName} at {CurrentTime}", actionName, currentTime);
  }
  public void OnActionExecuted(ActionExecutedContext context)
  {
    var actionName = context.ActionDescriptor.DisplayName;
    var currentTime = DateTime.Now;
    _logger.LogInformation("Executed {ActionName} at {CurrentTime}", actionName, currentTime);
  }
}

public class LogActionFilterAsync : IAsyncActionFilter
{
    private readonly ILogger<LogActionFilter> _logger;

    public LogActionFilterAsync(ILogger<LogActionFilter> logger)
    {
        _logger = logger;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        var currentTime = DateTime.Now;
        _logger.LogInformation("Executing Async {ActionName} at {CurrentTime}", actionName, currentTime);

        var executedContext = await next();

        actionName = executedContext.ActionDescriptor.DisplayName;
        currentTime = DateTime.Now;
        _logger.LogInformation("Executed Async {ActionName} at {CurrentTime}", actionName, currentTime);
    }
}