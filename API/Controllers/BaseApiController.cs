using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    //We need to give it the API controller attribute and Route. 
    //adding the api/ is optional but conventional
    [ApiController]
    [Route("api/[controller]")]

    //since this is a controller, you need to derive from ControllerBase, if it shows error,
    //click on command + . and select using for the base.
    public class BaseApiController : ControllerBase
    {
        
    }
}