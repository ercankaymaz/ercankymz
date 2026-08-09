namespace System.Runtime.Versioning;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
internal sealed class UnsupportedOSPlatformGuardAttribute : Attribute
{
	public UnsupportedOSPlatformGuardAttribute(string platformName)
	{
	}
}
