using Microsoft.AspNetCore.Mvc;

namespace WikiSumBackend.API.Controllers;

[ApiController]
[Route("/")]
public class RootController : ControllerBase
{
    [HttpGet]
    public IActionResult GetRoutes()
    {
        var routes = new[]
        {
            new
            {
                method = "GET",
                endpoint = "/",
                description = "Overview of all API routes"
            },
            new
            {
                method = "GET",
                endpoint = "/api/health",
                description = "Check API health"
            },
            new
            {
                method = "GET",
                endpoint = "/api/webpage",
                description = "Get all webpages"
            },
            new
            {
                method = "GET",
                endpoint = "/api/webpage/{id}",
                description = "Get a webpage with chapters and summaries"
            },
            new
            {
                method = "POST",
                endpoint = "/api/webpage",
                description = "Create a webpage with chapters and summaries"
            },
            new
            {
                method = "PUT",
                endpoint = "/api/webpage/{id}",
                description = "Update a webpage with chapters and summaries"
            },
            new
            {
                method = "DELETE",
                endpoint = "/api/webpage/{id}",
                description = "Delete a webpage"
            }
        };

        return Ok(new
        {
            name = "WikiSum API",
            version = "1.0",
            message = "Welcome to the WikiSum API!",
            routes
        });
    }
}
