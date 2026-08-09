namespace System.ServiceModel.Description;

internal static class ListenUriModeHelper
{
	public static bool IsDefined(ListenUriMode mode)
	{
		if (mode != ListenUriMode.Explicit)
		{
			return mode == ListenUriMode.Unique;
		}
		return true;
	}
}
