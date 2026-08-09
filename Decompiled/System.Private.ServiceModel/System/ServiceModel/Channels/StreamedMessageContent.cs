using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal class StreamedMessageContent : MessageContent
{
	public StreamedMessageContent(Message message, MessageEncoder messageEncoder, BufferManager bufferManager)
		: base(message, messageEncoder, bufferManager)
	{
	}

	protected override Task<Stream> CreateContentReadStreamAsync()
	{
		ProducerConsumerStream producerConsumerStream = new ProducerConsumerStream();
		_stream = new BufferedWriteStream(producerConsumerStream, _bufferManager);
		Task.Factory.StartNew((Func<object?, Task>)async delegate(object content)
		{
			StreamedMessageContent thisPtr = content as StreamedMessageContent;
			try
			{
				await _messageEncoder.WriteMessageAsync(thisPtr._message, thisPtr._stream);
			}
			finally
			{
				thisPtr._stream.Dispose();
				thisPtr._writeCompletedTcs.TrySetResult(result: true);
			}
		}, (object?)this, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		return Task.FromResult((Stream)producerConsumerStream);
	}

	protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
	{
		try
		{
			await _messageEncoder.WriteMessageAsync(_message, new BufferedWriteStream(stream, _bufferManager));
		}
		finally
		{
			_writeCompletedTcs.TrySetResult(result: true);
		}
	}

	protected override bool TryComputeLength(out long length)
	{
		length = -1L;
		return false;
	}
}
