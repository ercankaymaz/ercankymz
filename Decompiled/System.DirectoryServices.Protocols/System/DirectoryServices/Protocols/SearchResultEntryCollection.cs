using System.Collections;

namespace System.DirectoryServices.Protocols;

public class SearchResultEntryCollection : ReadOnlyCollectionBase
{
	public SearchResultEntry this[int index]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	internal SearchResultEntryCollection()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public bool Contains(SearchResultEntry value)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public void CopyTo(SearchResultEntry[] values, int index)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public int IndexOf(SearchResultEntry value)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
