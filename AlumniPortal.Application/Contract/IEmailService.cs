using AlumniPortal.Domain.Settings;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
