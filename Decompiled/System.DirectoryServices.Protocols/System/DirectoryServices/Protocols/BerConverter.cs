namespace System.DirectoryServices.Protocols;

public static class BerConverter
{
	public static object[] Decode(string format, byte[] value)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}

	public static byte[] Encode(string format, params object[] value)
	{
		throw new PlatformNotSupportedException(System.SR.DirectoryServicesProtocols_PlatformNotSupported);
	}
}
