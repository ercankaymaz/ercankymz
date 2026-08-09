namespace System.DirectoryServices.AccountManagement;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class DirectoryObjectClassAttribute : Attribute
{
	public ContextType? Context
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public string ObjectClass
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public DirectoryObjectClassAttribute(string objectClass)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
