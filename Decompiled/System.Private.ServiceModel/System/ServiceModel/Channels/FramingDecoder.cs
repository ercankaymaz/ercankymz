using System.IO;

namespace System.ServiceModel.Channels;

internal abstract class FramingDecoder
{
	protected abstract string CurrentStateAsString { get; }

	public long StreamPosition { get; set; }

	protected FramingDecoder()
	{
	}

	protected FramingDecoder(long streamPosition)
	{
		StreamPosition = streamPosition;
	}

	protected void ValidateFramingMode(FramingMode mode)
	{
		if ((uint)(mode - 1) > 3u)
		{
			Exception exception = CreateException(new InvalidDataException(System.SR.Format(System.SR.FramingModeNotSupported, mode.ToString())), "http://schemas.microsoft.com/ws/2006/05/framing/faults/UnsupportedMode");
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}

	protected void ValidateRecordType(FramingRecordType expectedType, FramingRecordType foundType)
	{
		if (foundType != expectedType)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateInvalidRecordTypeException(expectedType, foundType));
		}
	}

	protected void ValidatePreambleAck(FramingRecordType foundType)
	{
		if (foundType != FramingRecordType.PreambleAck)
		{
			Exception innerException = CreateInvalidRecordTypeException(FramingRecordType.PreambleAck, foundType);
			string message = (((byte)foundType != 104 && (byte)foundType != 72) ? System.SR.PreambleAckIncorrect : System.SR.PreambleAckIncorrectMaybeHttp);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(message, innerException));
		}
	}

	private Exception CreateInvalidRecordTypeException(FramingRecordType expectedType, FramingRecordType foundType)
	{
		return new InvalidDataException(System.SR.Format(System.SR.FramingRecordTypeMismatch, expectedType.ToString(), foundType.ToString()));
	}

	protected void ValidateMajorVersion(int majorVersion)
	{
		if (majorVersion != 1)
		{
			Exception exception = CreateException(new InvalidDataException(System.SR.Format(System.SR.FramingVersionNotSupported, majorVersion)), "http://schemas.microsoft.com/ws/2006/05/framing/faults/UnsupportedVersion");
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		}
	}

	public Exception CreatePrematureEOFException()
	{
		return CreateException(new InvalidDataException(System.SR.FramingPrematureEOF));
	}

	protected Exception CreateException(InvalidDataException innerException, string framingFault)
	{
		Exception ex = CreateException(innerException);
		FramingEncodingString.AddFaultString(ex, framingFault);
		return ex;
	}

	protected Exception CreateException(InvalidDataException innerException)
	{
		return new ProtocolException(System.SR.Format(System.SR.FramingError, StreamPosition, CurrentStateAsString), innerException);
	}
}
