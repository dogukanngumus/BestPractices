using BestPractices.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class CustomBaseController:ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
    {
        if (response.StatusCode == 204)
        {
            return new ObjectResult(null)
            {
                StatusCode = 204
            };
        }

        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}