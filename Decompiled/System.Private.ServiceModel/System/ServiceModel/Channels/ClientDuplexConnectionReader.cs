using System.Xml;

namespace System.ServiceModel.Channels;

internal class ClientDuplexConnectionReader : SessionConnectionReader
{
	private ClientDuplexDecoder _decoder;

	private int _maxBufferSize;

	private BufferManager _bufferManager;

	private MessageEncoder _messageEncoder;

	private ClientFramingDuplexSessionChannel _channel;

	public ClientDuplexConnectionReader(ClientFramingDuplexSessionChannel channel, IConnection connection, ClientDuplexDecoder decoder, IConnectionOrientedTransportFactorySettings settings, MessageEncoder messageEncoder)
		: base(connection, null, 0, 0, null)
	{
		_decoder = decoder;
		_maxBufferSize = settings.MaxBufferSize;
		_bufferManager = settings.BufferManager;
		_messageEncoder = messageEncoder;
		_channel = channel;
	}

	protected override void EnsureDecoderAtEof()
	{
		if (_decoder.CurrentState != ClientFramingDecoderState.End && _decoder.CurrentState != ClientFramingDecoderState.EnvelopeEnd && _decoder.CurrentState != ClientFramingDecoderState.ReadingUpgradeRecord && _decoder.CurrentState != ClientFramingDecoderState.UpgradeResponse)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(_decoder.CreatePrematureEOFException());
		}
	}

	private static IDisposable CreateProcessActionActivity()
	{
		return null;
	}

	protected override Message DecodeMessage(byte[] buffer, ref int offset, ref int size, ref bool isAtEOF, TimeSpan timeout)
	{
		while (size > 0)
		{
			int num = _decoder.Decode(buffer, offset, size);
			if (num > 0)
			{
				if (base.EnvelopeBuffer != null)
				{
					if (buffer != base.EnvelopeBuffer)
					{
						Buffer.BlockCopy(buffer, offset, base.EnvelopeBuffer, base.EnvelopeOffset, num);
					}
					base.EnvelopeOffset += num;
				}
				offset += num;
				size -= num;
			}
			switch (_decoder.CurrentState)
			{
			case ClientFramingDecoderState.Fault:
				_channel.Session.CloseOutputSession(_channel.GetInternalCloseTimeout());
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(FaultStringDecoder.GetFaultException(_decoder.Fault, _channel.RemoteAddress.Uri.ToString(), _messageEncoder.ContentType));
			case ClientFramingDecoderState.End:
				isAtEOF = true;
				return null;
			case ClientFramingDecoderState.EnvelopeStart:
			{
				int envelopeSize = _decoder.EnvelopeSize;
				if (envelopeSize > _maxBufferSize)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ExceptionHelper.CreateMaxReceivedMessageSizeExceededException(_maxBufferSize));
				}
				base.EnvelopeBuffer = _bufferManager.TakeBuffer(envelopeSize);
				base.EnvelopeOffset = 0;
				base.EnvelopeSize = envelopeSize;
				break;
			}
			case ClientFramingDecoderState.EnvelopeEnd:
			{
				if (base.EnvelopeBuffer == null)
				{
					break;
				}
				Message result = null;
				try
				{
					IDisposable disposable = CreateProcessActionActivity();
					using (disposable)
					{
						result = _messageEncoder.ReadMessage(new ArraySegment<byte>(base.EnvelopeBuffer, 0, base.EnvelopeSize), _bufferManager);
					}
				}
				catch (XmlException innerException)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.MessageXmlProtocolError, innerException));
				}
				base.EnvelopeBuffer = null;
				return result;
			}
			}
		}
		return null;
	}
}
