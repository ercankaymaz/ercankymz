namespace System.ServiceModel;

internal static class SessionModeHelper
{
	public static bool IsDefined(SessionMode sessionMode)
	{
		if (sessionMode != SessionMode.NotAllowed && sessionMode != SessionMode.Allowed)
		{
			return sessionMode == SessionMode.Required;
		}
		return true;
	}
}
