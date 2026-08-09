using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class FaultHelper
{
	protected object ThisLock { get; } = new object();

	public abstract void Abort();

	public static bool AddressReply(Message message, Message faultMessage)
	{
		try
		{
			RequestReplyCorrelator.PrepareReply(faultMessage, message);
		}
		catch (MessageHeaderException exception)
		{
			if (DiagnosticUtility.ShouldTraceInformation)
			{
				DiagnosticUtility.TraceHandledException(exception, TraceEventType.Information);
			}
		}
		bool result = true;
		try
		{
			result = RequestReplyCorrelator.AddressReply(faultMessage, message);
		}
		catch (MessageHeaderException exception2)
		{
			if (DiagnosticUtility.ShouldTraceInformation)
			{
				DiagnosticUtility.TraceHandledException(exception2, TraceEventType.Information);
			}
		}
		return result;
	}

	public abstract Task CloseAsync(TimeSpan timeout);

	public abstract Task SendFaultAsync(IReliableChannelBinder binder, RequestContext requestContext, Message faultMessage);
}
