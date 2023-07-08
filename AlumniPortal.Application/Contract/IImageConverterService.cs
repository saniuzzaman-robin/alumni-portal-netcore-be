using AlumniPortal.Domain.Auth;
using AlumniPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Contract
{
    public interface IImageConverterService
    {
        Task<string> ConvertAsync(string imageUri);
    }
}
