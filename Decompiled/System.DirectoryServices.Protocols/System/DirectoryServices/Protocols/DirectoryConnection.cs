using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace System.DirectoryServices.Protocols;

public abstract class DirectoryConnection
{
	public X509CertificateCollection ClientCertificates
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public virtual NetworkCredential Credential
	{
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public virtual DirectoryIdentifier Directory
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public virtual TimeSpan Timeout
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

	protected DirectoryConnection()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public abstract DirectoryResponse SendRequest(DirectoryRequest request);
}
