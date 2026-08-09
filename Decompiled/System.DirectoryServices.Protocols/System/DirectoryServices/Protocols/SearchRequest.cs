using System.Collections.Specialized;

namespace System.DirectoryServices.Protocols;

public class SearchRequest : DirectoryRequest
{
	public DereferenceAlias Aliases
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public StringCollection Attributes
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public string DistinguishedName
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public object Filter
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public SearchScope Scope
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public int SizeLimit
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public TimeSpan TimeLimit
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public bool TypesOnly
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public SearchRequest()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public SearchRequest(string distinguishedName, string ldapFilter, SearchScope searchScope, params string[] attributeList)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
