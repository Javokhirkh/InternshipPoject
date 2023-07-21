namespace Internship.Application.Common.Interfaces;

public interface IDateTimeProvider
{ 
    DateTimeOffset Now { get; }
}