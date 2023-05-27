using Cqrs.Hosts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Controllers
{
    public class MetaController : ControllerBase
    {
        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(StartUp).Assembly;

            var lastUpdate = System.IO.File.GetLastWriteTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {lastUpdate}");
        }
    }
}
