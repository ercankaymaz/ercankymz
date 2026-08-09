namespace System.DirectoryServices.Protocols;

public class DirSyncResponseControl : DirectoryControl
{
	public byte[] Cookie
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public bool MoreData
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public int ResultSize
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	internal DirSyncResponseControl()
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
