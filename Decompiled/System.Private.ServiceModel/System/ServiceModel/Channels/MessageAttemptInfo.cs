using System.Runtime;

namespace System.ServiceModel.Channels;

internal struct MessageAttemptInfo(Message message, long sequenceNumber, int retryCount, object state)
{
	private readonly long _sequenceNumber = sequenceNumber;

	public Message Message { get; } = message;

	public int RetryCount { get; } = retryCount;

	public object State { get; } = state;

	public long GetSequenceNumber()
	{
		if (_sequenceNumber <= 0)
		{
			throw Fx.AssertAndThrow("The caller is not allowed to get an invalid SequenceNumber.");
		}
		return _sequenceNumber;
	}
}
