namespace System.DirectoryServices.AccountManagement;

public class AdvancedFilters
{
	protected internal AdvancedFilters(Principal p)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void AccountExpirationDate(DateTime expirationTime, MatchType match)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void AccountLockoutTime(DateTime lockoutTime, MatchType match)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	protected void AdvancedFilterSet(string attribute, object value, Type objectType, MatchType mt)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void BadLogonCount(int badLogonCount, MatchType match)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void LastBadPasswordAttempt(DateTime lastAttempt, MatchType match)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void LastLogonTime(DateTime logonTime, MatchType match)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void LastPasswordSetTime(DateTime passwordSetTime, MatchType match)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
