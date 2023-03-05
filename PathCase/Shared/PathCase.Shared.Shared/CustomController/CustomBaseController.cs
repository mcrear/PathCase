namespace PathCase.Shared.Shared.CustomController
{
    using Microsoft.AspNetCore.Mvc;
    using PathCase.Shared.Shared.Dtos;

    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
