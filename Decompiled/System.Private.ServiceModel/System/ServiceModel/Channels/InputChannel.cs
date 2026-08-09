using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class InputChannel
{
	internal static async Task<Message> HelpReceiveAsync(IAsyncInputChannel channel, TimeSpan timeout)
	{
		var (flag, result) = await channel.TryReceiveAsync(timeout);
		if (flag)
		{
			return result;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateReceiveTimedOutException(channel, timeout));
	}

	private static Exception CreateReceiveTimedOutException(IInputChannel channel, TimeSpan timeout)
	{
		if (channel.LocalAddress != null)
		{
			return new TimeoutException(System.SR.Format(System.SR.ReceiveTimedOut, channel.LocalAddress.Uri.AbsoluteUri, timeout));
		}
		return new TimeoutException(System.SR.Format(System.SR.ReceiveTimedOutNoLocalAddress, timeout));
	}
}
