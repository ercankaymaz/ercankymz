using System.Text;

namespace System.ServiceModel.Channels;

internal static class BasicHttpBindingDefaults
{
	public const BasicHttpMessageCredentialType MessageSecurityClientCredentialType = BasicHttpMessageCredentialType.UserName;

	public const WSMessageEncoding MessageEncoding = WSMessageEncoding.Text;

	public const TransferMode TransferMode = TransferMode.Buffered;

	public static Encoding TextEncoding => TextEncoderDefaults.Encoding;
}
