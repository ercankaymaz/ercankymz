namespace System.Management;

public class DeleteOptions : ManagementOptions
{
	public DeleteOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public DeleteOptions(ManagementNamedValueCollection context, TimeSpan timeout)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public override object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
