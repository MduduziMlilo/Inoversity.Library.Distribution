using InoversityLibrary.Application.Interfaces;

namespace InoversityLibrary.Infrastructure.Infrastructure.Services;

public class DateTimeService: IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}