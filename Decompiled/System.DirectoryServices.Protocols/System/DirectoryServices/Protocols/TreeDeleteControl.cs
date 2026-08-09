namespace System.DirectoryServices.Protocols;

public class TreeDeleteControl : DirectoryControl
{
	public TreeDeleteControl()
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
