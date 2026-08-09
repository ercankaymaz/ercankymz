using System.IO;

namespace System.ServiceModel.Channels;

internal class ClientSingletonDecoder : ClientFramingDecoder
{
	private FaultStringDecoder _faultDecoder;

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

	public ClientSingletonDecoder(long streamPosition)
		: base(streamPosition)
	{
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
					num = 0;
					base.CurrentState = ClientFramingDecoderState.ReadingFault;
					break;
				default:
					ValidateRecordType(FramingRecordType.UnsizedEnvelope, framingRecordType);
					num = 1;
					base.CurrentState = ClientFramingDecoderState.EnvelopeStart;
					break;
				}
				break;
			}
			case ClientFramingDecoderState.EnvelopeStart:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateException(new InvalidDataException(System.SR.FramingAtEnd)));
			case ClientFramingDecoderState.ReadingFault:
			{
				FramingRecordType framingRecordType = (FramingRecordType)bytes[offset];
				ValidateRecordType(FramingRecordType.Fault, framingRecordType);
				num = 1;
				_faultDecoder = new FaultStringDecoder();
				base.CurrentState = ClientFramingDecoderState.ReadingFaultString;
				break;
			}
			case ClientFramingDecoderState.ReadingFaultString:
				num = _faultDecoder.Decode(bytes, offset, size);
				if (_faultDecoder.IsValueDecoded)
				{
					base.CurrentState = ClientFramingDecoderState.Fault;
				}
				break;
			case ClientFramingDecoderState.Fault:
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
