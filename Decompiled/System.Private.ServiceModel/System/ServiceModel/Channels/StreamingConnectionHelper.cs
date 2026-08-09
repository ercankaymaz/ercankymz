using System.IO;
using System.Runtime;
using System.ServiceModel.Channels.ConnectionHelpers;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal static class StreamingConnectionHelper
{
	private class StreamingOutputConnectionStream : ConnectionStream
	{
		private byte[] _encodedSize;

		public StreamingOutputConnectionStream(IConnection connection, IDefaultCommunicationTimeouts timeouts)
			: base(connection, timeouts)
		{
			_encodedSize = new byte[5];
		}

		private void WriteChunkSize(int size)
		{
			if (size > 0)
			{
				int size2 = IntEncoder.Encode(size, _encodedSize, 0);
				base.Connection.Write(_encodedSize, 0, size2, immediate: false, TimeSpan.FromMilliseconds(WriteTimeout));
			}
		}

		private Task WriteChunkSizeAsync(int size)
		{
			if (size > 0)
			{
				int size2 = IntEncoder.Encode(size, _encodedSize, 0);
				return base.Connection.WriteAsync(_encodedSize, 0, size2, immediate: false, TimeSpan.FromMilliseconds(WriteTimeout));
			}
			return TaskHelpers.CompletedTask();
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return base.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			await WriteChunkSizeAsync(count);
			await base.WriteAsync(buffer, offset, count, cancellationToken);
		}

		public override void WriteByte(byte value)
		{
			WriteChunkSize(1);
			base.WriteByte(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			WriteChunkSize(count);
			base.Write(buffer, offset, count);
		}
	}

	public static void WriteMessage(Message message, IConnection connection, bool isRequest, IConnectionOrientedTransportFactorySettings settings, ref TimeoutHelper timeoutHelper)
	{
		byte[] array = null;
		if (message != null)
		{
			MessageEncoder encoder = settings.MessageEncoderFactory.Encoder;
			byte[] envelopeStartBytes = SingletonEncoder.EnvelopeStartBytes;
			bool flag;
			if (isRequest)
			{
				array = SingletonEncoder.EnvelopeEndFramingEndBytes;
				flag = TransferModeHelper.IsRequestStreamed(settings.TransferMode);
			}
			else
			{
				array = SingletonEncoder.EnvelopeEndBytes;
				flag = TransferModeHelper.IsResponseStreamed(settings.TransferMode);
			}
			if (flag)
			{
				connection.Write(envelopeStartBytes, 0, envelopeStartBytes.Length, immediate: false, timeoutHelper.RemainingTime());
				Stream stream = new StreamingOutputConnectionStream(connection, settings);
				Stream stream2 = new TimeoutStream(stream, timeoutHelper.RemainingTime());
				encoder.WriteMessage(message, stream2);
			}
			else
			{
				ArraySegment<byte> messageFrame = encoder.WriteMessage(message, int.MaxValue, settings.BufferManager, envelopeStartBytes.Length + 5);
				messageFrame = SingletonEncoder.EncodeMessageFrame(messageFrame);
				Buffer.BlockCopy(envelopeStartBytes, 0, messageFrame.Array, messageFrame.Offset - envelopeStartBytes.Length, envelopeStartBytes.Length);
				connection.Write(messageFrame.Array, messageFrame.Offset - envelopeStartBytes.Length, messageFrame.Count + envelopeStartBytes.Length, immediate: true, timeoutHelper.RemainingTime(), settings.BufferManager);
			}
		}
		else if (isRequest)
		{
			array = SingletonEncoder.EndBytes;
		}
		if (array != null)
		{
			connection.Write(array, 0, array.Length, immediate: true, timeoutHelper.RemainingTime());
		}
	}

	public static async Task WriteMessageAsync(Message message, IConnection connection, bool isRequest, IConnectionOrientedTransportFactorySettings settings, TimeoutHelper timeoutHelper)
	{
		byte[] endBytes = null;
		if (message != null)
		{
			MessageEncoder messageEncoder = settings.MessageEncoderFactory.Encoder;
			byte[] envelopeStartBytes = SingletonEncoder.EnvelopeStartBytes;
			bool flag;
			if (isRequest)
			{
				endBytes = SingletonEncoder.EnvelopeEndFramingEndBytes;
				flag = TransferModeHelper.IsRequestStreamed(settings.TransferMode);
			}
			else
			{
				endBytes = SingletonEncoder.EnvelopeEndBytes;
				flag = TransferModeHelper.IsResponseStreamed(settings.TransferMode);
			}
			if (flag)
			{
				await connection.WriteAsync(envelopeStartBytes, 0, envelopeStartBytes.Length, immediate: false, timeoutHelper.RemainingTime());
				Stream stream = new StreamingOutputConnectionStream(connection, settings);
				Stream stream2 = new TimeoutStream(stream, timeoutHelper.RemainingTime());
				await messageEncoder.WriteMessageAsync(message, stream2);
			}
			else
			{
				ArraySegment<byte> arraySegment = SingletonEncoder.EncodeMessageFrame(await messageEncoder.WriteMessageAsync(message, int.MaxValue, settings.BufferManager, envelopeStartBytes.Length + 5));
				Buffer.BlockCopy(envelopeStartBytes, 0, arraySegment.Array, arraySegment.Offset - envelopeStartBytes.Length, envelopeStartBytes.Length);
				await connection.WriteAsync(arraySegment.Array, arraySegment.Offset - envelopeStartBytes.Length, arraySegment.Count + envelopeStartBytes.Length, immediate: true, timeoutHelper.RemainingTime());
			}
		}
		else if (isRequest)
		{
			endBytes = SingletonEncoder.EndBytes;
		}
		if (endBytes != null && endBytes.Length != 0)
		{
			await connection.WriteAsync(endBytes, 0, endBytes.Length, immediate: true, timeoutHelper.RemainingTime());
		}
	}
}
