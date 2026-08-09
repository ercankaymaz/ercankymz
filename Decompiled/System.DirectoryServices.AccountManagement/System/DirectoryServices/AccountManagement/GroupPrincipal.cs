namespace System.DirectoryServices.AccountManagement;

[DirectoryRdnPrefix("CN")]
public class GroupPrincipal : Principal
{
	public GroupScope? GroupScope
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

	public bool? IsSecurityGroup
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

	public PrincipalCollection Members
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public GroupPrincipal(PrincipalContext context)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public GroupPrincipal(PrincipalContext context, string samAccountName)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public override void Dispose()
	{
	}

	public new static GroupPrincipal FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static GroupPrincipal FindByIdentity(PrincipalContext context, string identityValue)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalSearchResult<Principal> GetMembers()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public PrincipalSearchResult<Principal> GetMembers(bool recursive)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
