using System.Collections;
using System.Collections.Generic;

namespace System.DirectoryServices.AccountManagement;

public class PrincipalSearchResult<T> : IEnumerable<T>, IEnumerable, IDisposable
{
	internal PrincipalSearchResult()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	public void Dispose()
	{
	}

	public IEnumerator<T> GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesAccountManagement_PlatformNotSupported);
	}
}
