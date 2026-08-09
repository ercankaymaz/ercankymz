using Microsoft.Extensions.Logging;

namespace Xbim.Common.Step21;

public static class LogEventIds
{
	public static EventId ParserFailure = new EventId(200, "ParserFailure");

	public static EventId FailedPropertySetter = new EventId(201, "FailedPropertySetter");

	public static EventId FailedEntity = new EventId(202, "FailedEntity");
}
