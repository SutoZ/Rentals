using Microsoft.AspNetCore.Mvc;

namespace Rental.Host.Controllers;

[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
[ApiController]
public class CustomControllerBase : ControllerBase
{

}