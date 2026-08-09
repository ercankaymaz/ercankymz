using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public static class TcpMessageLimits
{
	public const int MessageTypeAndSize = 8;

	public const int MinBufferSize = 8192;

	public const int MinBodySize = 1;

	public const int MaxBufferSize = 147456;

	public const int MaxErrorReasonLength = 4096;

	public const int MaxEndpointUrlLength = 4096;

	public const int MaxCertificateSize = 7500;

	public const int MaxSecurityPolicyUriSize = 256;

	public const int BaseHeaderSize = 12;

	public const int SymmetricHeaderSize = 16;

	public const int SequenceHeaderSize = 8;

	public const int CertificateThumbprintSize = 20;

	public const int StringLengthSize = 4;

	public const uint MinSequenceNumber = 4294966271u;

	public const uint MaxRolloverSequenceNumber = 1024u;

	public const int DefaultMaxBufferSize = 65535;

	public const int DefaultMaxChunkCount = 16;

	public const int DefaultMaxMessageSize = 1048560;

	public const int DefaultDiscoveryMaxMessageSize = 65535;

	public const int DefaultChannelLifetime = 60000;

	public const int DefaultSecurityTokenLifeTime = 3600000;

	public const int MinSecurityTokenLifeTime = 60000;

	public const int MinTimeBetweenReconnects = 0;

	public const int MaxTimeBetweenReconnects = 120000;

	public const double TokenRenewalPeriod = 0.75;

	public const double TokenActivationPeriod = 0.95;

	public const int KeySizeExtraPadding = 2048;
}
