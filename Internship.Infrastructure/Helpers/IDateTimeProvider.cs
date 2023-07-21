using Internship.Application.Common.Interfaces;

namespace Internship.Infrastructor.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}