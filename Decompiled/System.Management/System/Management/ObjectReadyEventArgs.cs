namespace System.Management;

public class ObjectReadyEventArgs : ManagementEventArgs
{
	public ManagementBaseObject NewObject
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ObjectReadyEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
