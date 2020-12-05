using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("file")]
    public class FileReaderController : BaseController
    {
        private readonly Dictionary<FileExtensions, string> _extensions =
            new Dictionary<FileExtensions, string>
            {
                {
                    FileExtensions.JSON, ".json"
                },
                {
                    FileExtensions.XML, ".xml"
                }
            };

        public FileReaderController(IMapper mapper, ILogger<FileReaderController> logger) : base(mapper, logger)
        {
        }

        /// <summary>
        /// format: json, xml
        /// objects in submitted file: users
        /// </summary>
        /// <returns></returns>
        [HttpPost("users-submit")]
        public async Task<IActionResult> SubmitUsers()
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();

            // TODO: Task # 7
            // You have to read data from the file as stream, so you need to deserialize it.
            // Don't forget that this is unmanaged resources, so you have to handle it correctly.


            if (file != null)
            {
                string output = null /*stream result*/;

                if (file.Name.EndsWith(_extensions[FileExtensions.JSON]))
                {
                    // TODO: Task # 8
                    // You need to implement JSON deserialization. You can use JsonConvert for example.
                }

                if (file.Name.EndsWith(_extensions[FileExtensions.XML]))
                {
                    // TODO: Task # 9
                    // You need to implement XML deserialization. You can use XmlSerializer for example.
                }
            }

            return Json(new
                        {
                            Message = "Data was successfully deserialized and saved",
                            StatusCode = 201
                        });
        }

        /// <summary>
        /// format: json, xml
        /// objects in submitted file: tasks
        /// </summary>
        /// <returns></returns>
        [HttpPost("tasks-submit")]
        public async Task<IActionResult> SubmitTasks()
        {
            // TODO: Task # 10
            // You need to implement this method like SubmitUsers

            // You have to use correct model here in deserialization

            return Json(new
                        {
                            Message = "Data was successfully deserialized and saved",
                            StatusCode = 201
                        });
        }
    }
}