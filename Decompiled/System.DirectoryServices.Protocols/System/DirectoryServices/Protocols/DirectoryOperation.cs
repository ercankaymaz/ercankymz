namespace System.DirectoryServices.Protocols;

public abstract class DirectoryOperation
{
	protected DirectoryOperation()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
