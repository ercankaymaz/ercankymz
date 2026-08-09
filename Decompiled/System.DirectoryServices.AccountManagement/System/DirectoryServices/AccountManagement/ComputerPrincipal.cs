namespace System.DirectoryServices.AccountManagement;

[DirectoryRdnPrefix("CN")]
public class ComputerPrincipal : AuthenticablePrincipal
{
	public PrincipalValueCollection<string> ServicePrincipalNames
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
		}
	}

	public ComputerPrincipal(PrincipalContext context)
		: base(null)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public ComputerPrincipal(PrincipalContext context, string samAccountName, string password, bool enabled)
		: base(null)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static PrincipalSearchResult<ComputerPrincipal> FindByBadPasswordAttempt(PrincipalContext context, DateTime time, MatchType type)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static PrincipalSearchResult<ComputerPrincipal> FindByExpirationTime(PrincipalContext context, DateTime time, MatchType type)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static ComputerPrincipal FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static ComputerPrincipal FindByIdentity(PrincipalContext context, string identityValue)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static PrincipalSearchResult<ComputerPrincipal> FindByLockoutTime(PrincipalContext context, DateTime time, MatchType type)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static PrincipalSearchResult<ComputerPrincipal> FindByLogonTime(PrincipalContext context, DateTime time, MatchType type)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public new static PrincipalSearchResult<ComputerPrincipal> FindByPasswordSetTime(PrincipalContext context, DateTime time, MatchType type)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
