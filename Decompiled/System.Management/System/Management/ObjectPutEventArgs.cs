namespace System.Management;

public class ObjectPutEventArgs : ManagementEventArgs
{
	public ManagementPath Path
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ObjectPutEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
