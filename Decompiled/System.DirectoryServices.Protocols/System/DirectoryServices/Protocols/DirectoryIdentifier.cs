namespace System.DirectoryServices.Protocols;

public abstract class DirectoryIdentifier
{
	protected DirectoryIdentifier()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
