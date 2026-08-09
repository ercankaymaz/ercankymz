using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal static class WebSocketHelper
{
	internal const int OperationNotStarted = 0;

	internal const int OperationFinished = 1;

	internal const string SecWebSocketKey = "Sec-WebSocket-Key";

	internal const string SecWebSocketVersion = "Sec-WebSocket-Version";

	internal const string SecWebSocketProtocol = "Sec-WebSocket-Protocol";

	internal const string SecWebSocketAccept = "Sec-WebSocket-Accept";

	internal const string MaxPendingConnectionsString = "MaxPendingConnections";

	internal const string WebSocketTransportSettingsString = "WebSocketTransportSettings";

	internal const string CloseOperation = "CloseOperation";

	internal const string SendOperation = "SendOperation";

	internal const string ReceiveOperation = "ReceiveOperation";

	internal static readonly char[] ProtocolSeparators = new char[1] { ',' };

	private const string SchemeWs = "ws";

	private const string SchemeWss = "wss";

	private static readonly HashSet<char> s_InvalidSeparatorSet = new HashSet<char>(new char[18]
	{
		'(', ')', '<', '>', '@', ',', ';', ':', '\\', '"',
		'/', '[', ']', '?', '=', '{', '}', ' '
	});

	internal static int GetReceiveBufferSize(long maxReceivedMessageSize)
	{
		int val = (int)((maxReceivedMessageSize <= 16384) ? maxReceivedMessageSize : 16384);
		return Math.Max(256, val);
	}

	internal static bool UseWebSocketTransport(WebSocketTransportUsage transportUsage, bool isContractDuplex)
	{
		if (transportUsage != WebSocketTransportUsage.Always)
		{
			return transportUsage == WebSocketTransportUsage.WhenDuplex && isContractDuplex;
		}
		return true;
	}

	internal static bool IsWebSocketUri(Uri uri)
	{
		if (uri != null)
		{
			if (!"ws".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
			{
				return "wss".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	internal static Uri NormalizeHttpSchemeWithWsScheme(Uri uri)
	{
		if (IsWebSocketUri(uri))
		{
			return uri;
		}
		UriBuilder uriBuilder = new UriBuilder(uri);
		string text = uri.Scheme.ToLowerInvariant();
		if (!(text == "http"))
		{
			if (text == "https")
			{
				uriBuilder.Scheme = "wss";
			}
		}
		else
		{
			uriBuilder.Scheme = "ws";
		}
		return uriBuilder.Uri;
	}

	internal static bool IsSubProtocolInvalid(string protocol, out string invalidChar)
	{
		char[] array = protocol.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			if (c < '!' || c > '~')
			{
				invalidChar = string.Format(CultureInfo.InvariantCulture, "[{0}]", (int)c);
				return true;
			}
			if (s_InvalidSeparatorSet.Contains(c))
			{
				invalidChar = c.ToString();
				return true;
			}
		}
		invalidChar = null;
		return false;
	}

	internal static WebSocketTransportSettings GetRuntimeWebSocketSettings(WebSocketTransportSettings settings)
	{
		return settings.Clone();
	}

	internal static void ThrowCorrectException(Exception ex)
	{
		throw ConvertAndTraceException(ex);
	}

	internal static void ThrowCorrectException(Exception ex, TimeSpan timeout, string operation)
	{
		throw ConvertAndTraceException(ex, timeout, operation);
	}

	internal static Exception ConvertAndTraceException(Exception ex)
	{
		return ConvertAndTraceException(ex, TimeSpan.MinValue, null);
	}

	internal static Exception ConvertAndTraceException(Exception ex, TimeSpan timeout, string operation)
	{
		if (ex is ObjectDisposedException)
		{
			CommunicationObjectAbortedException ex3 = new CommunicationObjectAbortedException(ex.Message, ex);
			FxTrace.Exception.AsWarning(ex3);
			return ex3;
		}
		if (ex is AggregateException ex4)
		{
			Exception ex5 = FxTrace.Exception.AsError<OperationCanceledException>(ex4);
			if (ex5 is OperationCanceledException)
			{
				TimeoutException timeoutException = GetTimeoutException(ex5, timeout, operation);
				FxTrace.Exception.AsWarning(timeoutException);
				return timeoutException;
			}
			Exception ex7 = ConvertAggregateExceptionToCommunicationException(ex4);
			if (ex7 is CommunicationObjectAbortedException)
			{
				FxTrace.Exception.AsWarning(ex7);
				return ex7;
			}
			return FxTrace.Exception.AsError(ex7);
		}
		return FxTrace.Exception.AsError(ex);
	}

	internal static Exception ConvertAggregateExceptionToCommunicationException(AggregateException ex)
	{
		Exception ex2 = FxTrace.Exception.AsError<Exception>(ex);
		if (ex2 is ObjectDisposedException)
		{
			return new CommunicationObjectAbortedException(ex2.Message, ex2);
		}
		return new CommunicationException(ex2.Message, ex2);
	}

	internal static void ThrowExceptionOnTaskFailure(Task task, TimeSpan timeout, string operation)
	{
		if (task.IsFaulted)
		{
			throw FxTrace.Exception.AsError<CommunicationException>(task.Exception);
		}
		if (task.IsCanceled)
		{
			throw FxTrace.Exception.AsError(GetTimeoutException(null, timeout, operation));
		}
	}

	internal static Exception CreateExceptionOnTaskFailure(Task task, TimeSpan timeout, string operation)
	{
		if (task.IsFaulted)
		{
			return FxTrace.Exception.AsError<CommunicationException>(task.Exception);
		}
		if (task.IsCanceled)
		{
			throw FxTrace.Exception.AsError(GetTimeoutException(null, timeout, operation));
		}
		return null;
	}

	internal static TimeoutException GetTimeoutException(Exception innerException, TimeSpan timeout, string operation)
	{
		string message = string.Empty;
		switch (operation)
		{
		case "CloseOperation":
			message = System.SR.Format(System.SR.CloseTimedOut, timeout);
			break;
		case "SendOperation":
			message = System.SR.Format(System.SR.WebSocketSendTimedOut, timeout);
			break;
		case "ReceiveOperation":
			message = System.SR.Format(System.SR.WebSocketReceiveTimedOut, timeout);
			break;
		default:
			message = System.SR.Format(System.SR.WebSocketOperationTimedOut, operation, timeout);
			break;
		case null:
			break;
		}
		if (innerException != null)
		{
			return new TimeoutException(message, innerException);
		}
		return new TimeoutException(message);
	}
}
