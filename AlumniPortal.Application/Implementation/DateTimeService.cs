using AlumniPortal.Application.Contract;
using System;

namespace AlumniPortal.Application.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}