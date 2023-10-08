using Utilities.Utilities.Interfaces;

namespace Utilities.Utilities;

public class DateTimeUtil : IDateTimeUtil
{
    public DateTime getUtcNow()
    {
        return DateTime.UtcNow;
    }
}