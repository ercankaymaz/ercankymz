namespace System.DirectoryServices.AccountManagement;

public class PrincipalContext : IDisposable
{
	public string ConnectedServer
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public string Container
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public ContextType ContextType
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public string Name
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public ContextOptions Options
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public string UserName
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public PrincipalContext(ContextType contextType)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalContext(ContextType contextType, string name)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalContext(ContextType contextType, string name, string container)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalContext(ContextType contextType, string name, string container, ContextOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalContext(ContextType contextType, string name, string container, ContextOptions options, string userName, string password)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalContext(ContextType contextType, string name, string userName, string password)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalContext(ContextType contextType, string name, string container, string userName, string password)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void Dispose()
	{
	}

	public bool ValidateCredentials(string userName, string password)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public bool ValidateCredentials(string userName, string password, ContextOptions options)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
