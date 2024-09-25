using Microsoft.AspNetCore.Mvc;

namespace Web
{
    public abstract class ControllerBase
    {
        protected ControllerBase() { }

        // Access to HTTP context (for request and response)
        public HttpContext HttpContext { get; }

        // To create an Ok (HTTP 200) response
        [NonAction]
        public OkObjectResult Ok(object value)
        {
            return new OkObjectResult(value);
        }

        // To create a BadRequest (HTTP 400) response
        [NonAction]
        public BadRequestObjectResult BadRequest(object error)
        {
            return new BadRequestObjectResult(error);
        }

        // To create a NotFound (HTTP 404) response
        [NonAction]
        public NotFoundResult NotFound()
        {
            return new NotFoundResult();
        }

        // To create a CreatedAtAction (HTTP 201) response with URI and value
        [NonAction]
        public CreatedAtActionResult CreatedAtAction(
            string actionName,
            object routeValues,
            object value)
        {
            return new CreatedAtActionResult(actionName, null, routeValues, value);
        }

        // Other utility methods for common HTTP responses...
    }
}

