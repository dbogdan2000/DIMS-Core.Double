using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;

        /// <summary>
        /// Base constructor which need to implement in each child class.
        /// </summary>
        /// <param name="mapper">DI mapper</param>
        /// <param name="logger">Here need generic variant of logger ILogger where T is current controller.</param>
        protected BaseController(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}