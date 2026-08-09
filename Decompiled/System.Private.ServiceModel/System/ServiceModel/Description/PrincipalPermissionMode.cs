namespace System.ServiceModel.Description;

public enum PrincipalPermissionMode
{
	None,
	UseWindowsGroups,
	UseAspNetRoles,
	Custom,
	Always
}
