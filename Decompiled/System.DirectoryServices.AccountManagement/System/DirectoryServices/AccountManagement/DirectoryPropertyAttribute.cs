namespace System.DirectoryServices.AccountManagement;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class DirectoryPropertyAttribute : Attribute
{
	public ContextType? Context
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public string SchemaAttributeName
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public DirectoryPropertyAttribute(string schemaAttributeName)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
