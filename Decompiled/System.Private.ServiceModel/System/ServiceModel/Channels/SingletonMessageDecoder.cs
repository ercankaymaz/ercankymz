using System.IO;

namespace System.ServiceModel.Channels;

internal class SingletonMessageDecoder : FramingDecoder
{
	public enum State
	{
		ReadingEnvelopeChunkSize,
		ChunkStart,
		ReadingEnvelopeBytes,
		ChunkEnd,
		EnvelopeEnd,
		End
	}

	private IntDecoder _sizeDecoder;

	private int _chunkBytesNeeded;

	private int _chunkSize;

	public State CurrentState { get; private set; }

	protected override string CurrentStateAsString => CurrentState.ToString();

	public int ChunkSize
	{
		get
		{
			if (CurrentState < State.ChunkStart)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
			}
			return _chunkSize;
		}
	}

	public SingletonMessageDecoder(long streamPosition)
		: base(streamPosition)
	{
		_sizeDecoder = default(IntDecoder);
		CurrentState = State.ChunkStart;
	}

	public void Reset()
	{
		CurrentState = State.ChunkStart;
	}

	public int Decode(byte[] bytes, int offset, int size)
	{
		DecoderHelper.ValidateSize(size);
		try
		{
			int num;
			switch (CurrentState)
			{
			case State.ReadingEnvelopeChunkSize:
				num = _sizeDecoder.Decode(bytes, offset, size);
				if (_sizeDecoder.IsValueDecoded)
				{
					_chunkSize = _sizeDecoder.Value;
					_sizeDecoder.Reset();
					if (_chunkSize == 0)
					{
						CurrentState = State.EnvelopeEnd;
						break;
					}
					CurrentState = State.ChunkStart;
					_chunkBytesNeeded = _chunkSize;
				}
				break;
			case State.ChunkStart:
				num = 0;
				CurrentState = State.ReadingEnvelopeBytes;
				break;
			case State.ReadingEnvelopeBytes:
				num = size;
				if (num > _chunkBytesNeeded)
				{
					num = _chunkBytesNeeded;
				}
				_chunkBytesNeeded -= num;
				if (_chunkBytesNeeded == 0)
				{
					CurrentState = State.ChunkEnd;
				}
				break;
			case State.ChunkEnd:
				num = 0;
				CurrentState = State.ReadingEnvelopeChunkSize;
				break;
			case State.EnvelopeEnd:
				ValidateRecordType(FramingRecordType.End, (FramingRecordType)bytes[offset]);
				num = 1;
				CurrentState = State.End;
				break;
			case State.End:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateException(new InvalidDataException(System.SR.FramingAtEnd)));
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateException(new InvalidDataException(System.SR.InvalidDecoderStateMachine)));
			}
			base.StreamPosition += num;
			return num;
		}
		catch (InvalidDataException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateException(innerException));
		}
	}
}
