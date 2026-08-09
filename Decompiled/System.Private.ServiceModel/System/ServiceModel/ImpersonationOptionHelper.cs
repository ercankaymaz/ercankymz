namespace System.ServiceModel;

internal static class ImpersonationOptionHelper
{
	public static bool IsDefined(ImpersonationOption option)
	{
		if (option != ImpersonationOption.NotAllowed && option != ImpersonationOption.Allowed)
		{
			return option == ImpersonationOption.Required;
		}
		return true;
	}

	internal static bool AllowedOrRequired(ImpersonationOption option)
	{
		if (option != ImpersonationOption.Allowed)
		{
			return option == ImpersonationOption.Required;
		}
		return true;
	}
}
