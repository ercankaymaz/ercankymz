namespace System.DirectoryServices.Protocols;

public class DirectoryNotificationControl : DirectoryControl
{
	public DirectoryNotificationControl()
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
