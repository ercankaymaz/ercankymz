using System.Collections.Generic;

namespace System.ServiceModel.Channels;

internal class BodyWriterMessageBuffer : MessageBuffer
{
	private object _thisLock = new object();

	protected object ThisLock => _thisLock;

	public override int BufferSize => 0;

	protected BodyWriter BodyWriter { get; private set; }

	protected MessageHeaders Headers { get; private set; }

	protected KeyValuePair<string, object>[] Properties { get; private set; }

	protected bool Closed { get; private set; }

	public BodyWriterMessageBuffer(MessageHeaders headers, KeyValuePair<string, object>[] properties, BodyWriter bodyWriter)
	{
		BodyWriter = bodyWriter;
		Headers = new MessageHeaders(headers);
		Properties = properties;
	}

	public override void Close()
	{
		lock (ThisLock)
		{
			if (!Closed)
			{
				Closed = true;
				BodyWriter = null;
				Headers = null;
				Properties = null;
			}
		}
	}

	public override Message CreateMessage()
	{
		lock (ThisLock)
		{
			if (Closed)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBufferDisposedException());
			}
			return new BodyWriterMessage(Headers, Properties, BodyWriter);
		}
	}
}
