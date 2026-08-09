using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

[Serializable]
public class ProtocolException : CommunicationException
{
	public ProtocolException()
	{
	}

	public ProtocolException(string message)
		: base(message)
	{
	}

	public ProtocolException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected ProtocolException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal static ProtocolException ReceiveShutdownReturnedNonNull(Message message)
	{
		if (message.IsFault)
		{
			try
			{
				MessageFault messageFault = MessageFault.CreateFault(message, 65536);
				FaultReasonText matchingTranslation = messageFault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture);
				string message2 = System.SR.Format(System.SR.ReceiveShutdownReturnedFault, matchingTranslation.Text);
				return new ProtocolException(message2);
			}
			catch (QuotaExceededException)
			{
				string message3 = System.SR.Format(System.SR.ReceiveShutdownReturnedLargeFault, message.Headers.Action);
				return new ProtocolException(message3);
			}
		}
		string message4 = System.SR.Format(System.SR.ReceiveShutdownReturnedMessage, message.Headers.Action);
		return new ProtocolException(message4);
	}

	internal static ProtocolException OneWayOperationReturnedNonNull(Message message)
	{
		if (message.IsFault)
		{
			try
			{
				MessageFault messageFault = MessageFault.CreateFault(message, 65536);
				FaultReasonText matchingTranslation = messageFault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture);
				string message2 = System.SR.Format(System.SR.OneWayOperationReturnedFault, matchingTranslation.Text);
				return new ProtocolException(message2);
			}
			catch (QuotaExceededException)
			{
				string message3 = System.SR.Format(System.SR.OneWayOperationReturnedLargeFault, message.Headers.Action);
				return new ProtocolException(message3);
			}
		}
		string message4 = System.SR.Format(System.SR.OneWayOperationReturnedMessage, message.Headers.Action);
		return new ProtocolException(message4);
	}
}
