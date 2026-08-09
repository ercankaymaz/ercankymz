using System.ServiceModel.Channels;

namespace System.ServiceModel;

public sealed class UnknownMessageReceivedEventArgs : EventArgs
{
	public Message Message { get; }

	internal UnknownMessageReceivedEventArgs(Message message)
	{
		Message = message;
	}
}
