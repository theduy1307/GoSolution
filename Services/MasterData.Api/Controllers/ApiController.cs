using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace MasterData.Api.Controllers;

[ApiVersion("1")]
[Route("api/{version:apiVersion}/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    
}