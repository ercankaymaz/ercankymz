using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class MessageContent : HttpContent
{
	protected Message _message;

	protected MessageEncoder _messageEncoder;

	protected BufferManager _bufferManager;

	protected Stream _stream;

	private bool _disposed;

	protected TaskCompletionSource<bool> _writeCompletedTcs;

	public Message Message => _message;

	internal Task WriteCompletionTask => _writeCompletedTcs.Task;

	public MessageContent(Message message, MessageEncoder messageEncoder, BufferManager bufferManager)
	{
		_message = message;
		_messageEncoder = messageEncoder;
		_bufferManager = bufferManager;
		_writeCompletedTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
		SetContentType(_messageEncoder.ContentType);
		PrepareContentHeaders();
	}

	private void PrepareContentHeaders()
	{
		bool flag = false;
		string text = _message.Headers.Action;
		if (text != null)
		{
			text = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", UrlUtility.UrlPathEncode(text));
		}
		if (_message.Version.Addressing == AddressingVersion.None)
		{
			_message.Headers.Action = null;
			_message.Headers.To = null;
		}
		if (_message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out var value))
		{
			HttpRequestMessageProperty httpRequestMessageProperty = (HttpRequestMessageProperty)value;
			WebHeaderCollection headers = httpRequestMessageProperty.Headers;
			string[] allKeys = headers.AllKeys;
			foreach (string text2 in allKeys)
			{
				string text3 = headers[text2];
				if (string.Compare(text2, "SOAPAction", StringComparison.OrdinalIgnoreCase) == 0)
				{
					if (text == null)
					{
						text = text3;
					}
					else if (!string.IsNullOrEmpty(text3) && string.Compare(text3, text, StringComparison.Ordinal) != 0)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.HttpSoapActionMismatch, text, text3)));
					}
				}
				else if (string.Compare(text2, "content-type", StringComparison.OrdinalIgnoreCase) == 0 && SetContentType(text3))
				{
					flag = true;
				}
			}
		}
		if (text == null || _message.Version.Envelope != EnvelopeVersion.Soap12 || _message.Version.Addressing != AddressingVersion.None)
		{
			return;
		}
		bool flag2 = true;
		if (flag)
		{
			NameValueHeaderValue[] array = base.Headers.ContentType.Parameters.Where((NameValueHeaderValue p) => p.Name == "action").ToArray();
			if (array.Length != 0)
			{
				try
				{
					string text4 = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", array[0].Value);
					if (string.Compare(text4, text, StringComparison.Ordinal) != 0)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.HttpSoapActionMismatchContentType, text, text4)));
					}
					flag2 = false;
				}
				catch (FormatException ex)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.HttpContentTypeFormatException, ex.Message, base.Headers.ContentType.ToString()), ex));
				}
			}
		}
		if (flag2)
		{
			base.Headers.ContentType.Parameters.Add(new NameValueHeaderValue("action", text));
		}
	}

	private bool SetContentType(string contentType)
	{
		if (MediaTypeHeaderValue.TryParse(contentType, out MediaTypeHeaderValue parsedValue))
		{
			base.Headers.ContentType = parsedValue;
			return true;
		}
		return false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !_disposed)
		{
			_disposed = true;
			if (_stream != null)
			{
				Stream stream = _stream;
				_stream = null;
				stream.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	internal static HttpContent Create(HttpChannelFactory<IRequestChannel> factory, Message request, TimeoutHelper _timeoutHelper)
	{
		if (TransferModeHelper.IsRequestStreamed(factory.TransferMode))
		{
			return new StreamedMessageContent(request, factory.MessageEncoderFactory.Encoder, factory.BufferManager);
		}
		return new BufferedMessageContent(request, factory.MessageEncoderFactory.Encoder, factory.BufferManager);
	}
}
