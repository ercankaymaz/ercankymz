using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace System.ServiceModel.Channels;

public sealed class HttpResponseMessageProperty : IMessageProperty, IMergeEnabledMessageProperty
{
	private class TraditionalHttpResponseMessageProperty
	{
		public const HttpStatusCode DefaultStatusCode = HttpStatusCode.OK;

		public const string DefaultStatusDescription = null;

		private HttpStatusCode _statusCode;

		private WebHeaderCollection _headers;

		private WebHeaderCollection _originalHeaders;

		public WebHeaderCollection Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = new WebHeaderCollection();
					if (_originalHeaders != null)
					{
						string[] allKeys = _originalHeaders.AllKeys;
						foreach (string name in allKeys)
						{
							_headers[name] = _originalHeaders[name];
						}
						_originalHeaders = null;
					}
				}
				return _headers;
			}
		}

		public HttpStatusCode StatusCode
		{
			get
			{
				return _statusCode;
			}
			set
			{
				_statusCode = value;
				HasStatusCodeBeenSet = true;
			}
		}

		public bool HasStatusCodeBeenSet { get; private set; }

		public string StatusDescription { get; set; }

		public bool SuppressEntityBody { get; set; }

		public bool SuppressPreamble { get; set; }

		public TraditionalHttpResponseMessageProperty()
		{
			_statusCode = HttpStatusCode.OK;
			StatusDescription = null;
		}

		public TraditionalHttpResponseMessageProperty(WebHeaderCollection originalHeaders)
			: this()
		{
			_originalHeaders = originalHeaders;
		}
	}

	private class HttpResponseMessageBackedProperty
	{
		private WebHeaderCollection _headers;

		public HttpResponseMessage HttpResponseMessage { get; private set; }

		public WebHeaderCollection Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = HttpResponseMessage.ToWebHeaderCollection();
				}
				return _headers;
			}
		}

		public HttpStatusCode StatusCode
		{
			get
			{
				return HttpResponseMessage.StatusCode;
			}
			set
			{
				HttpResponseMessage.StatusCode = value;
			}
		}

		public string StatusDescription
		{
			get
			{
				return HttpResponseMessage.ReasonPhrase;
			}
			set
			{
				HttpResponseMessage.ReasonPhrase = value;
			}
		}

		public bool SuppressEntityBody
		{
			get
			{
				HttpContent content = HttpResponseMessage.Content;
				if (content != null)
				{
					long? contentLength = content.Headers.ContentLength;
					if (!contentLength.HasValue || (contentLength.HasValue && contentLength.Value > 0))
					{
						return false;
					}
				}
				return true;
			}
			set
			{
				HttpContent content = HttpResponseMessage.Content;
				if (value && content != null && (!content.Headers.ContentLength.HasValue || content.Headers.ContentLength.Value > 0))
				{
					HttpContent httpContent = new ByteArrayContent(Array.Empty<byte>());
					foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
					{
						httpContent.Headers.AddHeaderWithoutValidation(header);
					}
					HttpResponseMessage.Content = httpContent;
					content.Dispose();
				}
				else if (!value && content == null)
				{
					HttpResponseMessage.Content = new ByteArrayContent(Array.Empty<byte>());
				}
			}
		}

		public HttpResponseMessageBackedProperty(HttpResponseMessage httpResponseMessage)
		{
			HttpResponseMessage = httpResponseMessage;
		}

		public HttpResponseMessageProperty CreateTraditionalResponseMessageProperty()
		{
			HttpResponseMessageProperty httpResponseMessageProperty = new HttpResponseMessageProperty();
			string[] allKeys = Headers.AllKeys;
			foreach (string name in allKeys)
			{
				httpResponseMessageProperty.Headers[name] = Headers[name];
			}
			if (StatusCode != HttpStatusCode.OK)
			{
				httpResponseMessageProperty.StatusCode = StatusCode;
			}
			httpResponseMessageProperty.StatusDescription = StatusDescription;
			httpResponseMessageProperty.SuppressEntityBody = SuppressEntityBody;
			return httpResponseMessageProperty;
		}

		public void MergeWithTraditionalProperty(TraditionalHttpResponseMessageProperty propertyToMerge)
		{
			if (propertyToMerge.HasStatusCodeBeenSet)
			{
				StatusCode = propertyToMerge.StatusCode;
			}
			if (propertyToMerge.StatusDescription != null)
			{
				StatusDescription = propertyToMerge.StatusDescription;
			}
			SuppressEntityBody = propertyToMerge.SuppressEntityBody;
			HttpResponseMessage.MergeWebHeaderCollection(propertyToMerge.Headers);
		}
	}

	private TraditionalHttpResponseMessageProperty _traditionalProperty;

	private HttpResponseMessageBackedProperty _httpBackedProperty;

	private bool _useHttpBackedProperty;

	private bool _initialCopyPerformed;

	public static string Name => "httpResponse";

	public WebHeaderCollection Headers
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.Headers;
			}
			return _httpBackedProperty.Headers;
		}
	}

	public HttpStatusCode StatusCode
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.StatusCode;
			}
			return _httpBackedProperty.StatusCode;
		}
		set
		{
			if (value < HttpStatusCode.Continue || value > (HttpStatusCode)599)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.ValueMustBeInRange, 100, 599)));
			}
			if (_useHttpBackedProperty)
			{
				_httpBackedProperty.StatusCode = value;
			}
			else
			{
				_traditionalProperty.StatusCode = value;
			}
		}
	}

	internal bool HasStatusCodeBeenSet
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.HasStatusCodeBeenSet;
			}
			return true;
		}
	}

	public string StatusDescription
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.StatusDescription;
			}
			return _httpBackedProperty.StatusDescription;
		}
		set
		{
			if (_useHttpBackedProperty)
			{
				_httpBackedProperty.StatusDescription = value;
			}
			else
			{
				_traditionalProperty.StatusDescription = value;
			}
		}
	}

	public bool SuppressEntityBody
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.SuppressEntityBody;
			}
			return _httpBackedProperty.SuppressEntityBody;
		}
		set
		{
			if (_useHttpBackedProperty)
			{
				_httpBackedProperty.SuppressEntityBody = value;
			}
			else
			{
				_traditionalProperty.SuppressEntityBody = value;
			}
		}
	}

	public bool SuppressPreamble
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.SuppressPreamble;
			}
			return false;
		}
		set
		{
			if (!_useHttpBackedProperty)
			{
				_traditionalProperty.SuppressPreamble = value;
			}
		}
	}

	public HttpResponseMessage HttpResponseMessage
	{
		get
		{
			if (_useHttpBackedProperty)
			{
				return _httpBackedProperty.HttpResponseMessage;
			}
			return null;
		}
	}

	public HttpResponseMessageProperty()
	{
		_traditionalProperty = new TraditionalHttpResponseMessageProperty();
		_useHttpBackedProperty = false;
	}

	internal HttpResponseMessageProperty(WebHeaderCollection originalHeaders)
	{
		_traditionalProperty = new TraditionalHttpResponseMessageProperty(originalHeaders);
		_useHttpBackedProperty = false;
	}

	internal HttpResponseMessageProperty(HttpResponseMessage httpResponseMessage)
	{
		_httpBackedProperty = new HttpResponseMessageBackedProperty(httpResponseMessage);
		_useHttpBackedProperty = true;
	}

	internal static HttpResponseMessage GetHttpResponseMessageFromMessage(Message message)
	{
		HttpResponseMessage httpResponseMessage = null;
		HttpResponseMessageProperty value = message.Properties.GetValue<HttpResponseMessageProperty>(Name);
		if (value != null)
		{
			httpResponseMessage = value.HttpResponseMessage;
			if (httpResponseMessage != null)
			{
				httpResponseMessage.CopyPropertiesFromMessage(message);
				message.EnsureReadMessageState();
			}
		}
		return httpResponseMessage;
	}

	IMessageProperty IMessageProperty.CreateCopy()
	{
		if (!_useHttpBackedProperty || !_initialCopyPerformed)
		{
			_initialCopyPerformed = true;
			return this;
		}
		return _httpBackedProperty.CreateTraditionalResponseMessageProperty();
	}

	bool IMergeEnabledMessageProperty.TryMergeWithProperty(object propertyToMerge)
	{
		if (_useHttpBackedProperty && propertyToMerge is HttpResponseMessageProperty httpResponseMessageProperty)
		{
			if (!httpResponseMessageProperty._useHttpBackedProperty)
			{
				_httpBackedProperty.MergeWithTraditionalProperty(httpResponseMessageProperty._traditionalProperty);
				httpResponseMessageProperty._traditionalProperty = null;
				httpResponseMessageProperty._httpBackedProperty = _httpBackedProperty;
				httpResponseMessageProperty._useHttpBackedProperty = true;
			}
			return true;
		}
		return false;
	}
}
