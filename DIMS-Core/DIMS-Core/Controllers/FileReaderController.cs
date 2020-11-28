using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Common.Enums;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DIMS_Core.Controllers
{
    [Route("file")]
    public class FileReaderController : BaseController
    {
        private Dictionary<FileExtensions, string> extensions = new Dictionary<FileExtensions, string>
        { { FileExtensions.JSON, ".json" }, { FileExtensions.XML, ".xml" } };

        public FileReaderController(IMapper mapper):base(mapper)
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

                if (file.Name.EndsWith(extensions[FileExtensions.JSON]))
                {
                    // TODO: Task # 8
                    // You need to implement JSON deserialization. You can use JsonConvert for example.
                }

                if (file.Name.EndsWith(extensions[FileExtensions.XML]))
                {
                    // TODO: Task # 9
                    // You need to implement XML deserialization. You can use XmlSerializer for example.
                }
            }

            return Json(new { Message = "Data was successfully desirialized and saved", StatusCode = 201 });
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

            return Json(new { Message = "Data was successfully desirialized and saved", StatusCode = 201 });
        }
    }
}
