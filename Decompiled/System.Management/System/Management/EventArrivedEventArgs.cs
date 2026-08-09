namespace System.Management;

public class EventArrivedEventArgs : ManagementEventArgs
{
	public ManagementBaseObject NewEvent
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal EventArrivedEventArgs()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
