using RepoLiveSharpUpdateFailsWithMatBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RepoLiveSharpUpdateFailsWithMatBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        
        private readonly ILogger<MathController> logger;

        public MathController(ILogger<MathController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string Get(int a, int b)
        {
            return $"{a} - {b} = {a + b}";
        }
    }
}
