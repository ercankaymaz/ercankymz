using System.IO;

namespace System.ServiceModel.Channels;

internal class FaultStringDecoder : StringDecoder
{
	internal const int FaultSizeQuota = 256;

	public FaultStringDecoder()
		: base(256)
	{
	}

	protected override Exception OnSizeQuotaExceeded(int size)
	{
		return new InvalidDataException(System.SR.Format(System.SR.FramingFaultTooLong, size));
	}

	public static Exception GetFaultException(string faultString, string via, string contentType)
	{
		switch (faultString)
		{
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/EndpointNotFound":
			return new EndpointNotFoundException(System.SR.Format(System.SR.EndpointNotFound, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/ContentTypeInvalid":
			return new ProtocolException(System.SR.Format(System.SR.FramingContentTypeMismatch, contentType, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/ServiceActivationFailed":
			return new ServiceActivationException(System.SR.Format(System.SR.Hosting_ServiceActivationFailed, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/ConnectionDispatchFailed":
			return new CommunicationException(System.SR.Format(System.SR.Sharing_ConnectionDispatchFailed, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/EndpointUnavailable":
			return new EndpointNotFoundException(System.SR.Format(System.SR.Sharing_EndpointUnavailable, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/MaxMessageSizeExceededFault":
		{
			Exception ex3 = new QuotaExceededException(System.SR.FramingMaxMessageSizeExceeded);
			return new CommunicationException(ex3.Message, ex3);
		}
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/UnsupportedMode":
			return new ProtocolException(System.SR.Format(System.SR.FramingModeNotSupportedFault, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/UnsupportedVersion":
			return new ProtocolException(System.SR.Format(System.SR.FramingVersionNotSupportedFault, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/ContentTypeTooLong":
		{
			Exception ex2 = new QuotaExceededException(System.SR.Format(System.SR.FramingContentTypeTooLongFault, contentType));
			return new CommunicationException(ex2.Message, ex2);
		}
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/ViaTooLong":
		{
			Exception ex = new QuotaExceededException(System.SR.Format(System.SR.FramingViaTooLongFault, via));
			return new CommunicationException(ex.Message, ex);
		}
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/ServerTooBusy":
			return new ServerTooBusyException(System.SR.Format(System.SR.ServerTooBusy, via));
		case "http://schemas.microsoft.com/ws/2006/05/framing/faults/UpgradeInvalid":
			return new ProtocolException(System.SR.Format(System.SR.FramingUpgradeInvalid, via));
		default:
			return new ProtocolException(System.SR.Format(System.SR.FramingFaultUnrecognized, faultString));
		}
	}
}
