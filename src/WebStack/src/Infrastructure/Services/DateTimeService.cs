using WebStack.Application.Common.Interfaces;

namespace WebStack.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
