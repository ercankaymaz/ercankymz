using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class Profiles
{
	public const string UaTcpTransport = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";

	public const string UaWssTransport = "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary";

	public const string HttpsBinaryTransport = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";

	public const string PubSubUdpUadpTransport = "http://opcfoundation.org/UA-Profile/Transport/pubsub-udp-uadp";

	public const string PubSubMqttUadpTransport = "http://opcfoundation.org/UA-Profile/Transport/pubsub-mqtt-uadp";

	public const string PubSubMqttJsonTransport = "http://opcfoundation.org/UA-Profile/Transport/pubsub-mqtt-json";

	public const string JwtUserToken = "http://opcfoundation.org/UA/UserToken#JWT";

	public const string HttpsSecurityPolicyHeader = "OPCUA-SecurityPolicy";

	public static string NormalizeUri(string profileUri)
	{
		string.IsNullOrEmpty(profileUri);
		return profileUri;
	}
}
