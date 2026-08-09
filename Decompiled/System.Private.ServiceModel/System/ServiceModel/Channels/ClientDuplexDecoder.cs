using System.IO;

namespace System.ServiceModel.Channels;

internal class ClientDuplexDecoder : ClientFramingDecoder
{
	private IntDecoder _sizeDecoder;

	private FaultStringDecoder _faultDecoder;

	private int _envelopeBytesNeeded;

	private int _envelopeSize;

	public int EnvelopeSize
	{
		get
		{
			if (base.CurrentState < ClientFramingDecoderState.EnvelopeStart)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
			}
			return _envelopeSize;
		}
	}

	public override string Fault
	{
		get
		{
			if (base.CurrentState < ClientFramingDecoderState.Fault)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
			}
			return _faultDecoder.Value;
		}
	}

	public ClientDuplexDecoder(long streamPosition)
		: base(streamPosition)
	{
		_sizeDecoder = default(IntDecoder);
	}

	public override int Decode(byte[] bytes, int offset, int size)
	{
		DecoderHelper.ValidateSize(size);
		try
		{
			int num;
			switch (base.CurrentState)
			{
			case ClientFramingDecoderState.ReadingUpgradeRecord:
			{
				FramingRecordType framingRecordType = (FramingRecordType)bytes[offset];
				if (framingRecordType == FramingRecordType.UpgradeResponse)
				{
					num = 1;
					base.CurrentState = ClientFramingDecoderState.UpgradeResponse;
				}
				else
				{
					num = 0;
					base.CurrentState = ClientFramingDecoderState.ReadingAckRecord;
				}
				break;
			}
			case ClientFramingDecoderState.UpgradeResponse:
				num = 0;
				base.CurrentState = ClientFramingDecoderState.ReadingUpgradeRecord;
				break;
			case ClientFramingDecoderState.ReadingAckRecord:
			{
				FramingRecordType framingRecordType = (FramingRecordType)bytes[offset];
				if (framingRecordType == FramingRecordType.Fault)
				{
					num = 1;
					_faultDecoder = new FaultStringDecoder();
					base.CurrentState = ClientFramingDecoderState.ReadingFaultString;
				}
				else
				{
					ValidatePreambleAck(framingRecordType);
					num = 1;
					base.CurrentState = ClientFramingDecoderState.Start;
				}
				break;
			}
			case ClientFramingDecoderState.Start:
				num = 0;
				base.CurrentState = ClientFramingDecoderState.ReadingEnvelopeRecord;
				break;
			case ClientFramingDecoderState.ReadingEnvelopeRecord:
			{
				FramingRecordType framingRecordType = (FramingRecordType)bytes[offset];
				switch (framingRecordType)
				{
				case FramingRecordType.End:
					num = 1;
					base.CurrentState = ClientFramingDecoderState.End;
					break;
				case FramingRecordType.Fault:
					num = 1;
					_faultDecoder = new FaultStringDecoder();
					base.CurrentState = ClientFramingDecoderState.ReadingFaultString;
					break;
				default:
					ValidateRecordType(FramingRecordType.SizedEnvelope, framingRecordType);
					num = 1;
					base.CurrentState = ClientFramingDecoderState.ReadingEnvelopeSize;
					_sizeDecoder.Reset();
					break;
				}
				break;
			}
			case ClientFramingDecoderState.ReadingEnvelopeSize:
				num = _sizeDecoder.Decode(bytes, offset, size);
				if (_sizeDecoder.IsValueDecoded)
				{
					base.CurrentState = ClientFramingDecoderState.EnvelopeStart;
					_envelopeSize = _sizeDecoder.Value;
					_envelopeBytesNeeded = _envelopeSize;
				}
				break;
			case ClientFramingDecoderState.EnvelopeStart:
				num = 0;
				base.CurrentState = ClientFramingDecoderState.ReadingEnvelopeBytes;
				break;
			case ClientFramingDecoderState.ReadingEnvelopeBytes:
				num = size;
				if (num > _envelopeBytesNeeded)
				{
					num = _envelopeBytesNeeded;
				}
				_envelopeBytesNeeded -= num;
				if (_envelopeBytesNeeded == 0)
				{
					base.CurrentState = ClientFramingDecoderState.EnvelopeEnd;
				}
				break;
			case ClientFramingDecoderState.EnvelopeEnd:
				num = 0;
				base.CurrentState = ClientFramingDecoderState.ReadingEnvelopeRecord;
				break;
			case ClientFramingDecoderState.ReadingFaultString:
				num = _faultDecoder.Decode(bytes, offset, size);
				if (_faultDecoder.IsValueDecoded)
				{
					base.CurrentState = ClientFramingDecoderState.Fault;
				}
				break;
			case ClientFramingDecoderState.Fault:
				num = 0;
				base.CurrentState = ClientFramingDecoderState.ReadingEndRecord;
				break;
			case ClientFramingDecoderState.ReadingEndRecord:
				ValidateRecordType(FramingRecordType.End, (FramingRecordType)bytes[offset]);
				num = 1;
				base.CurrentState = ClientFramingDecoderState.End;
				break;
			case ClientFramingDecoderState.End:
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
