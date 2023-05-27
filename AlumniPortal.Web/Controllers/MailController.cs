using AlumniPortal.Application.Contract;
using AlumniPortal.Domain.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlumniPortal.Controllers
{
    [ApiController]
    [Route("api/Mail")]
    public class MailController : ControllerBase
    {
        private readonly IEmailService mailService;
        public MailController(IEmailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }

    }
}