namespace System.Runtime.Versioning;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
internal sealed class TargetPlatformAttribute : Attribute
{
	public TargetPlatformAttribute(string platformName)
	{
	}
}
