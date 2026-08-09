using System.Security.Authentication;
using System.Security.Principal;

namespace System.ServiceModel.Channels;

internal static class TransportDefaults
{
	public const bool ExtractGroupsForWindowsAccounts = true;

	public const HostNameComparisonMode HostNameComparisonMode = HostNameComparisonMode.Exact;

	public const TokenImpersonationLevel ImpersonationLevel = TokenImpersonationLevel.Identification;

	public const bool ManualAddressing = false;

	public const long MaxReceivedMessageSize = 65536L;

	public const int MaxDrainSize = 65536;

	public const long MaxBufferPoolSize = 524288L;

	public const int MaxBufferSize = 65536;

	public const bool RequireClientCertificate = false;

	public const int MaxFaultSize = 65536;

	public const int MaxSecurityFaultSize = 16384;

	public const SslProtocols SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;

	public const int MaxRMFaultSize = 65536;

	public static MessageEncoderFactory GetDefaultMessageEncoderFactory()
	{
		return new BinaryMessageEncodingBindingElement().CreateMessageEncoderFactory();
	}
}
