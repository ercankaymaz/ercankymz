namespace System.ServiceModel.Description;

internal static class PrincipalPermissionModeHelper
{
	public static bool IsDefined(PrincipalPermissionMode principalPermissionMode)
	{
		return Enum.IsDefined(typeof(PrincipalPermissionMode), principalPermissionMode);
	}
}
