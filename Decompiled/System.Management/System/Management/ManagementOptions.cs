using System.ComponentModel;

namespace System.Management;

[TypeConverter(typeof(ExpandableObjectConverter))]
public abstract class ManagementOptions : ICloneable
{
	public static readonly TimeSpan InfiniteTimeout;

	public ManagementNamedValueCollection Context
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	public TimeSpan Timeout
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ManagementOptions()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public abstract object Clone();
}
