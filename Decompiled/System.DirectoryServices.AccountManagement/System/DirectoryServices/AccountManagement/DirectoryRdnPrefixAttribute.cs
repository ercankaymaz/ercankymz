namespace System.DirectoryServices.AccountManagement;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class DirectoryRdnPrefixAttribute : Attribute
{
	public ContextType? Context
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public string RdnPrefix
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public DirectoryRdnPrefixAttribute(string rdnPrefix)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
