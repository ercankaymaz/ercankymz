using System.Net;
using System.Net.Security;
using System.Security.Authentication.ExtendedProtection;

namespace System.ServiceModel.Channels;

internal static class ChannelBindingUtility
{
	private static readonly ExtendedProtectionPolicy s_disabledPolicy = new ExtendedProtectionPolicy(PolicyEnforcement.Never);

	public static ExtendedProtectionPolicy DefaultPolicy { get; } = s_disabledPolicy;

	public static ChannelBinding GetToken(SslStream stream)
	{
		return GetToken(stream.TransportContext);
	}

	public static ChannelBinding GetToken(TransportContext context)
	{
		ChannelBinding result = null;
		if (context != null)
		{
			result = context.GetChannelBinding(ChannelBindingKind.Endpoint);
		}
		return result;
	}

	public static void TryAddToMessage(ChannelBinding channelBindingToken, Message message, bool messagePropertyOwnsCleanup)
	{
		if (channelBindingToken != null)
		{
			ChannelBindingMessageProperty channelBindingMessageProperty = new ChannelBindingMessageProperty(channelBindingToken, messagePropertyOwnsCleanup);
			channelBindingMessageProperty.AddTo(message);
			channelBindingMessageProperty.Dispose();
		}
	}

	public static void Dispose(ref ChannelBinding channelBinding)
	{
		IDisposable disposable = channelBinding;
		channelBinding = null;
		disposable?.Dispose();
	}
}
