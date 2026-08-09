namespace System.DirectoryServices.Protocols;

public class PermissiveModifyControl : DirectoryControl
{
	public PermissiveModifyControl()
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
