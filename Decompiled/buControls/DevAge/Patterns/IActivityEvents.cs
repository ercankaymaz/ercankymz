using System;

namespace DevAge.Patterns;

public interface IActivityEvents
{
	void ActivityStarted(IActivity sender);

	void ActivityCompleted(IActivity sender);

	void ActivityException(IActivity sender, Exception exception);
}
