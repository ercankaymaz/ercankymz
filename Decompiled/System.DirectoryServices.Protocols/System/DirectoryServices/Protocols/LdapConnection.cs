using System.Net;

namespace System.DirectoryServices.Protocols;

public class LdapConnection : DirectoryConnection, IDisposable
{
	public AuthType AuthType
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

	public bool AutoBind
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

	public override NetworkCredential Credential
	{
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public LdapSessionOptions SessionOptions
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public override TimeSpan Timeout
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

	public LdapConnection(LdapDirectoryIdentifier identifier)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public LdapConnection(LdapDirectoryIdentifier identifier, NetworkCredential credential)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public LdapConnection(LdapDirectoryIdentifier identifier, NetworkCredential credential, AuthType authType)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public LdapConnection(string server)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public void Abort(IAsyncResult asyncResult)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public IAsyncResult BeginSendRequest(DirectoryRequest request, PartialResultProcessing partialMode, AsyncCallback callback, object state)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public IAsyncResult BeginSendRequest(DirectoryRequest request, TimeSpan requestTimeout, PartialResultProcessing partialMode, AsyncCallback callback, object state)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public void Bind()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public void Bind(NetworkCredential newCredential)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public void Dispose()
	{
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public DirectoryResponse EndSendRequest(IAsyncResult asyncResult)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	~LdapConnection()
	{
	}

	public PartialResultsCollection GetPartialResults(IAsyncResult asyncResult)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public override DirectoryResponse SendRequest(DirectoryRequest request)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public DirectoryResponse SendRequest(DirectoryRequest request, TimeSpan requestTimeout)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
