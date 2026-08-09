namespace System.DirectoryServices.Protocols;

public class SortRequestControl : DirectoryControl
{
	public SortKey[] SortKeys
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
		}
	}

	public SortRequestControl(params SortKey[] sortKeys)
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public SortRequestControl(string attributeName, bool reverseOrder)
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public SortRequestControl(string attributeName, string matchingRule, bool reverseOrder)
		: base(null, null, isCritical: false, serverSide: false)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public override byte[] GetValue()
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
