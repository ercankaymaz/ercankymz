using System.Net;

namespace System.ServiceModel.Channels;

internal static class HttpTransportDefaults
{
	internal const bool AllowCookies = false;

	internal const AuthenticationSchemes AuthenticationScheme = AuthenticationSchemes.Anonymous;

	internal const bool BypassProxyOnLocal = false;

	internal const bool DecompressionEnabled = true;

	internal const HostNameComparisonMode HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

	internal const bool KeepAliveEnabled = true;

	internal const IWebProxy Proxy = null;

	internal const Uri ProxyAddress = null;

	internal const AuthenticationSchemes ProxyAuthenticationScheme = AuthenticationSchemes.Anonymous;

	internal const string Realm = "";

	internal const TransferMode TransferMode = TransferMode.Buffered;

	internal const bool UnsafeConnectionNtlmAuthentication = false;

	internal const bool UseDefaultWebProxy = true;

	internal const string UpgradeHeader = "Upgrade";

	internal const string ConnectionHeader = "Connection";

	internal const HttpMessageHandlerFactory MessageHandlerFactory = null;

	internal const string RequestInitializationTimeoutString = "00:00:00";

	internal const int DefaultMaxPendingAccepts = 0;

	internal const int MaxPendingAcceptsUpperLimit = 100000;

	internal static TimeSpan RequestInitializationTimeout => TimeSpanHelper.FromMilliseconds(0, "00:00:00");

	internal static WebSocketTransportSettings GetDefaultWebSocketTransportSettings()
	{
		return new WebSocketTransportSettings();
	}

	internal static MessageEncoderFactory GetDefaultMessageEncoderFactory()
	{
		return new TextMessageEncoderFactory(MessageVersion.Default, TextEncoderDefaults.Encoding, 64, 16, EncoderDefaults.ReaderQuotas);
	}
}
