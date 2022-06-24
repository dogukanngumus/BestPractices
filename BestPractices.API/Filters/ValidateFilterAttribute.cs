using BestPractices.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestPractices.API.Filters;

public class ValidateFilterAttribute:ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var erros = context.ModelState.Values.SelectMany(x => x.Errors).ToList().Select(x=> x.ErrorMessage);
            context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400,erros.ToList()));
        }
    }
}