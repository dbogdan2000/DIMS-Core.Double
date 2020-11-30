using AutoMapper;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS_Core.Controllers
{
    [Route("json")]
    public class JsonFileWriterController : BaseController
    {
        public JsonFileWriterController(IMapper mapper, ILogger logger) : base(mapper, logger)
        {
        }

        [HttpPost("users")]
        public async Task<IActionResult> UsersWriter(UserProfileViewModel[] userProfileViewModels)
        {
            
        }
    }
}
