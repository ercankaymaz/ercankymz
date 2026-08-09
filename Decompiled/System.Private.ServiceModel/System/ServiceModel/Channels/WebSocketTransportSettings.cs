using System.ComponentModel;
using System.Runtime;
using System.Threading;

namespace System.ServiceModel.Channels;

public sealed class WebSocketTransportSettings : IEquatable<WebSocketTransportSettings>
{
	public const string ConnectionOpenedAction = "http://schemas.microsoft.com/2011/02/session/onopen";

	public const string BinaryMessageReceivedAction = "http://schemas.microsoft.com/2011/02/websockets/onbinarymessage";

	public const string TextMessageReceivedAction = "http://schemas.microsoft.com/2011/02/websockets/ontextmessage";

	public const string SoapContentTypeHeader = "soap-content-type";

	public const string BinaryEncoderTransferModeHeader = "microsoft-binary-transfer-mode";

	internal const string WebSocketMethod = "WEBSOCKET";

	internal const string SoapSubProtocol = "soap";

	internal const string TransportUsageMethodName = "TransportUsage";

	private WebSocketTransportUsage _transportUsage;

	private TimeSpan _keepAliveInterval;

	private string _subProtocol;

	[DefaultValue(WebSocketTransportUsage.Never)]
	public WebSocketTransportUsage TransportUsage
	{
		get
		{
			return _transportUsage;
		}
		set
		{
			WebSocketTransportUsageHelper.Validate(value);
			_transportUsage = value;
		}
	}

	[DefaultValue(typeof(TimeSpan), "00:00:00")]
	public TimeSpan KeepAliveInterval
	{
		get
		{
			return _keepAliveInterval;
		}
		set
		{
			if (value < TimeSpan.Zero && value != Timeout.InfiniteTimeSpan)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_keepAliveInterval = value;
		}
	}

	[DefaultValue(null)]
	public string SubProtocol
	{
		get
		{
			return _subProtocol;
		}
		set
		{
			if (value != null)
			{
				if (value == string.Empty)
				{
					throw FxTrace.Exception.Argument("value", System.SR.WebSocketInvalidProtocolEmptySubprotocolString);
				}
				if (value.Split(WebSocketHelper.ProtocolSeparators).Length > 1)
				{
					throw FxTrace.Exception.Argument("value", System.SR.Format(System.SR.WebSocketInvalidProtocolContainsMultipleSubProtocolString, value));
				}
				if (WebSocketHelper.IsSubProtocolInvalid(value, out var invalidChar))
				{
					throw FxTrace.Exception.Argument("value", System.SR.Format(System.SR.WebSocketInvalidProtocolInvalidCharInProtocolString, value, invalidChar));
				}
			}
			_subProtocol = value;
		}
	}

	public bool DisablePayloadMasking
	{
		get
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		set
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	public WebSocketTransportSettings()
	{
		_transportUsage = WebSocketTransportUsage.Never;
		_keepAliveInterval = WebSocketDefaults.DefaultKeepAliveInterval;
		_subProtocol = null;
	}

	private WebSocketTransportSettings(WebSocketTransportSettings settings)
	{
		TransportUsage = settings.TransportUsage;
		SubProtocol = settings.SubProtocol;
		KeepAliveInterval = settings.KeepAliveInterval;
	}

	public bool Equals(WebSocketTransportSettings other)
	{
		if (other == null)
		{
			return false;
		}
		if (TransportUsage == other.TransportUsage && KeepAliveInterval == other.KeepAliveInterval)
		{
			return StringComparer.OrdinalIgnoreCase.Compare(SubProtocol, other.SubProtocol) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return base.Equals(obj);
		}
		WebSocketTransportSettings other = obj as WebSocketTransportSettings;
		return Equals(other);
	}

	public override int GetHashCode()
	{
		int num = TransportUsage.GetHashCode() ^ KeepAliveInterval.GetHashCode();
		if (SubProtocol != null)
		{
			num ^= SubProtocol.ToLowerInvariant().GetHashCode();
		}
		return num;
	}

	internal WebSocketTransportSettings Clone()
	{
		return new WebSocketTransportSettings(this);
	}
}
