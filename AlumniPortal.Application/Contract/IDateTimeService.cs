using System;

namespace AlumniPortal.Application.Contract
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
