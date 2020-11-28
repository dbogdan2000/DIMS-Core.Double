using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using FileIO = System.IO.File;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("file")]
    public class FileWriterController : BaseController
    {
        public FileWriterController(IMapper mapper, ILogger<FileWriterController> logger): base(mapper, logger)
        {

        }

        [HttpPost("users-write")]
        public async Task<IActionResult> UsersWriter(string data)
        {
            StreamWriter streamWriter = null;
            const string fileName = "users.csv";

            try
            {
                // TODO: Task # 11
                // You need to create file in current directory

                // TODO: Task # 12
                // You need to write data in file using stream
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
            }
            finally
            {
                _logger.LogInformation("stream was closed");
                streamWriter?.Close();
            }

            return Json(new { Message = "Data was successfully saved", StatusCode = 201 });
        }

        public async Task<IActionResult> TasksWriter(string data)
        {
            StreamWriter streamWriter = null;
            const string fileName = "tasks.csv";

            // TODO: Task # 13
            // You need to implement this method as UsersWriter

            try
            {

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            finally
            {

            }

            return Json(new { Message = "Data was successfully saved", StatusCode = 201 });
        }
    }
}
