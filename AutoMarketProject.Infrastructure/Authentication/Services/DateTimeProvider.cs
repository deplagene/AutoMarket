using AutoMarketProject.Application.Common.Services;

namespace AutoMarketProject.Infrastructure.Authentication.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}