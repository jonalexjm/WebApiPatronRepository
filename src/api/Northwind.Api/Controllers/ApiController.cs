using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;


namespace Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    
    public abstract class ApiController : ControllerBase
    {
    }
}
