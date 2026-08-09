using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class HttpResponseMessageHelper
{
	private readonly HttpChannelFactory<IRequestChannel> _factory;

	private readonly MessageEncoder _encoder;

	private readonly HttpRequestMessage _httpRequestMessage;

	private readonly HttpResponseMessage _httpResponseMessage;

	private string _contentType;

	private long _contentLength;

	public HttpResponseMessageHelper(HttpResponseMessage httpResponseMessage, HttpChannelFactory<IRequestChannel> factory)
	{
		_httpResponseMessage = httpResponseMessage;
		_httpRequestMessage = httpResponseMessage.RequestMessage;
		_factory = factory;
		_encoder = factory.MessageEncoderFactory.Encoder;
	}

	internal async Task<Message> ParseIncomingResponse(TimeoutHelper timeoutHelper)
	{
		ValidateAuthentication();
		ValidateResponseStatusCode();
		Message message;
		if (!(await ValidateContentTypeAsync(timeoutHelper)))
		{
			if (_encoder.MessageVersion != MessageVersion.None)
			{
				return null;
			}
			message = new NullMessage();
		}
		else
		{
			message = await ReadStreamAsMessageAsync(timeoutHelper);
		}
		ProcessHttpAddressing(message);
		return message;
	}

	private Exception ProcessHttpAddressing(Message message)
	{
		Exception result = null;
		AddProperties(message);
		if (message.Version.Addressing == AddressingVersion.None)
		{
			bool flag = false;
			try
			{
				flag = message.Headers.Action == null;
			}
			catch (XmlException)
			{
			}
			catch (CommunicationException)
			{
			}
			if (!flag)
			{
				result = new ProtocolException(System.SR.Format(System.SR.HttpAddressingNoneHeaderOnWire, XD.AddressingDictionary.Action.Value));
			}
			bool flag2 = false;
			try
			{
				flag2 = message.Headers.To == null;
			}
			catch (XmlException)
			{
			}
			catch (CommunicationException)
			{
			}
			if (!flag2)
			{
				result = new ProtocolException(System.SR.Format(System.SR.HttpAddressingNoneHeaderOnWire, XD.AddressingDictionary.To.Value));
			}
			message.Headers.To = message.Properties.Via;
		}
		return result;
	}

	private void AddProperties(Message message)
	{
		HttpResponseMessageProperty property = new HttpResponseMessageProperty(_httpResponseMessage);
		message.Properties.Add(HttpResponseMessageProperty.Name, property);
		message.Properties.Via = message.Version.Addressing.AnonymousUri;
	}

	private async Task<bool> ValidateContentTypeAsync(TimeoutHelper timeoutHelper)
	{
		HttpContent content = _httpResponseMessage.Content;
		if (content != null)
		{
			MediaTypeHeaderValue contentType = content.Headers.ContentType;
			_contentType = ((contentType == null) ? string.Empty : contentType.ToString());
			_contentLength = (content.Headers.ContentLength.HasValue ? content.Headers.ContentLength.Value : (-1));
		}
		if (string.IsNullOrEmpty(_contentType))
		{
			if (await GetStreamAsync(timeoutHelper) != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.HttpContentTypeHeaderRequired));
			}
			return false;
		}
		if (_contentLength != 0L && !_encoder.IsContentTypeSupported(_contentType))
		{
			int bytesToRead = (int)_contentLength;
			string responseStreamExcerptString = HttpChannelUtilities.GetResponseStreamExcerptString(await GetStreamAsync(timeoutHelper), ref bytesToRead);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(HttpChannelUtilities.TraceResponseException(new ProtocolException(System.SR.Format(System.SR.ResponseContentTypeMismatch, _contentType, _encoder.ContentType, bytesToRead, responseStreamExcerptString))));
		}
		return true;
	}

	private Task<Message> ReadStreamAsMessageAsync(TimeoutHelper timeoutHelper)
	{
		HttpContent content = _httpResponseMessage.Content;
		Task<Stream> streamAsync = GetStreamAsync(timeoutHelper);
		if (TransferModeHelper.IsResponseStreamed(_factory.TransferMode))
		{
			return ReadStreamedMessageAsync(streamAsync);
		}
		if (!content.Headers.ContentLength.HasValue)
		{
			return ReadChunkedBufferedMessageAsync(streamAsync, timeoutHelper);
		}
		return ReadBufferedMessageAsync(streamAsync, timeoutHelper);
	}

	private async Task<Message> ReadChunkedBufferedMessageAsync(Task<Stream> inputStreamTask, TimeoutHelper timeoutHelper)
	{
		_ = 2;
		try
		{
			MessageEncoder encoder = _encoder;
			Stream stream = await inputStreamTask;
			BufferManager bufferManager = _factory.BufferManager;
			int maxBufferSize = _factory.MaxBufferSize;
			string contentType = _contentType;
			return await encoder.ReadMessageAsync(stream, bufferManager, maxBufferSize, contentType, await timeoutHelper.GetCancellationTokenAsync());
		}
		catch (XmlException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.MessageXmlProtocolError, innerException));
		}
	}

	private async Task<Message> ReadBufferedMessageAsync(Task<Stream> inputStreamTask, TimeoutHelper timeoutHelper)
	{
		Stream inputStream = await inputStreamTask;
		if (_contentLength > _factory.MaxReceivedMessageSize)
		{
			ThrowMaxReceivedMessageSizeExceeded();
		}
		int num = (int)_contentLength;
		ArraySegment<byte> arraySegment = new ArraySegment<byte>(_factory.BufferManager.TakeBuffer(num), 0, num);
		byte[] buffer = arraySegment.Array;
		int offset = 0;
		int count = arraySegment.Count;
		CancellationToken ct = await timeoutHelper.GetCancellationTokenAsync();
		while (count > 0)
		{
			int num2 = await inputStream.ReadAsync(buffer, offset, count, ct);
			if (num2 == 0)
			{
				if (_contentLength == -1)
				{
					break;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.HttpContentLengthIncorrect));
			}
			count -= num2;
			offset += num2;
		}
		return await DecodeBufferedMessageAsync(new ArraySegment<byte>(buffer, 0, offset), inputStream, timeoutHelper);
	}

	private async Task<Message> ReadStreamedMessageAsync(Task<Stream> inputStreamTask)
	{
		Stream stream = await inputStreamTask;
		BufferedReadStream bufferedInputStream = stream as BufferedReadStream;
		MaxMessageSizeStream stream2 = new MaxMessageSizeStream(stream, _factory.MaxReceivedMessageSize);
		try
		{
			Message message = await _encoder.ReadMessageAsync(stream2, _factory.MaxBufferSize, _contentType);
			if (bufferedInputStream != null)
			{
				message.Properties["ServiceModelBufferedReadStreamProperty"] = bufferedInputStream;
			}
			return message;
		}
		catch (XmlException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.MessageXmlProtocolError, innerException));
		}
	}

	private void ThrowMaxReceivedMessageSizeExceeded()
	{
		if (WcfEventSource.Instance.MaxReceivedMessageSizeExceededIsEnabled())
		{
			WcfEventSource.Instance.MaxReceivedMessageSizeExceeded(System.SR.Format(System.SR.MaxReceivedMessageSizeExceeded, _factory.MaxReceivedMessageSize));
		}
		string message = System.SR.Format(System.SR.MaxReceivedMessageSizeExceeded, _factory.MaxReceivedMessageSize);
		Exception innerException = new QuotaExceededException(message);
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CommunicationException(message, innerException));
	}

	private async Task<Message> DecodeBufferedMessageAsync(ArraySegment<byte> buffer, Stream inputStream, TimeoutHelper timeoutHelper)
	{
		_ = 1;
		try
		{
			CancellationToken cancellationToken = await timeoutHelper.GetCancellationTokenAsync();
			if (_contentLength == -1 && buffer.Count == _factory.MaxReceivedMessageSize)
			{
				byte[] buffer2 = new byte[1];
				if (await inputStream.ReadAsync(buffer2, 0, 1, cancellationToken) > 0)
				{
					ThrowMaxReceivedMessageSizeExceeded();
				}
			}
			try
			{
				return _encoder.ReadMessage(buffer, _factory.BufferManager, _contentType);
			}
			catch (XmlException innerException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.MessageXmlProtocolError, innerException));
			}
		}
		finally
		{
			inputStream.Dispose();
		}
	}

	private async Task<Stream> GetStreamAsync(TimeoutHelper timeoutHelper)
	{
		HttpContent content = _httpResponseMessage.Content;
		Stream contentStream = null;
		_contentLength = -1L;
		if (content != null)
		{
			contentStream = await content.ReadAsStreamAsync();
			_contentLength = (content.Headers.ContentLength.HasValue ? content.Headers.ContentLength.Value : (-1));
			CancellationToken cancellationToken = await timeoutHelper.GetCancellationTokenAsync();
			if (_contentLength <= 0)
			{
				byte[] preReadBuffer = new byte[1];
				if (await contentStream.ReadAsync(preReadBuffer, 0, 1, cancellationToken) == 0)
				{
					contentStream.Dispose();
					contentStream = null;
				}
				else
				{
					BufferedReadStream bufferedStream = new BufferedReadStream(contentStream, _factory.BufferManager);
					await bufferedStream.PreReadBufferAsync(preReadBuffer[0], cancellationToken);
					contentStream = bufferedStream;
				}
			}
			else if (TransferModeHelper.IsResponseStreamed(_factory.TransferMode))
			{
				BufferedReadStream bufferedStream = new BufferedReadStream(contentStream, _factory.BufferManager);
				await bufferedStream.PreReadBufferAsync(cancellationToken);
				contentStream = bufferedStream;
			}
		}
		return contentStream;
	}

	private void ValidateResponseStatusCode()
	{
		if ((_httpResponseMessage.StatusCode >= HttpStatusCode.OK && _httpResponseMessage.StatusCode < HttpStatusCode.MultipleChoices) || _httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
		{
			return;
		}
		if (_httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.EndpointNotFound, _httpRequestMessage.RequestUri.AbsoluteUri)));
		}
		if (_httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ServerTooBusyException(System.SR.Format(System.SR.HttpServerTooBusy, _httpRequestMessage.RequestUri.AbsoluteUri)));
		}
		if (_httpResponseMessage.StatusCode == HttpStatusCode.UnsupportedMediaType)
		{
			string reasonPhrase = _httpResponseMessage.ReasonPhrase;
			if (!string.IsNullOrEmpty(reasonPhrase) && string.Compare(reasonPhrase, "Missing Content Type", StringComparison.OrdinalIgnoreCase) == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.MissingContentType, _httpRequestMessage.RequestUri)));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ProtocolException(System.SR.Format(System.SR.FramingContentTypeMismatch, _httpRequestMessage.Content.Headers.ContentType.ToString(), _httpRequestMessage.RequestUri)));
		}
		if (_httpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(_httpResponseMessage.StatusCode.ToString() + " " + _httpResponseMessage.ReasonPhrase));
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(HttpChannelUtilities.CreateUnexpectedResponseException(_httpResponseMessage));
	}

	private void ValidateAuthentication()
	{
		if (_httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
		{
			string message = System.SR.Format(System.SR.HttpAuthorizationFailed, _factory.AuthenticationScheme, _httpResponseMessage.Headers.WwwAuthenticate.ToString());
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(HttpChannelUtilities.TraceResponseException(new MessageSecurityException(message)));
		}
		if (_httpResponseMessage.StatusCode == HttpStatusCode.Forbidden)
		{
			string message2 = System.SR.Format(System.SR.HttpAuthorizationForbidden, _factory.AuthenticationScheme);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(HttpChannelUtilities.TraceResponseException(new MessageSecurityException(message2)));
		}
	}
}
