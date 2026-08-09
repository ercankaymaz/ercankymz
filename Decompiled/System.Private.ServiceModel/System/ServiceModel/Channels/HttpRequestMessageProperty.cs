using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace System.ServiceModel.Channels;

public sealed class HttpRequestMessageProperty : IMessageProperty, IMergeEnabledMessageProperty
{
	private class TraditionalHttpRequestMessageProperty
	{
		public const string DefaultMethod = "POST";

		public const string DefaultQueryString = "";

		private string _method;

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

		public string Method
		{
			get
			{
				return _method;
			}
			set
			{
				_method = value;
				HasMethodBeenSet = true;
			}
		}

		public bool HasMethodBeenSet { get; private set; }

		public string QueryString { get; set; }

		public bool SuppressEntityBody { get; set; }

		public TraditionalHttpRequestMessageProperty()
		{
			_method = "POST";
			QueryString = "";
		}

		public TraditionalHttpRequestMessageProperty(WebHeaderCollection originalHeaders)
			: this()
		{
			_originalHeaders = originalHeaders;
		}
	}

	private class HttpRequestMessageBackedProperty
	{
		private WebHeaderCollection _headers;

		public HttpRequestMessage HttpRequestMessage { get; private set; }

		public WebHeaderCollection Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = HttpRequestMessage.ToWebHeaderCollection();
				}
				return _headers;
			}
		}

		public string Method
		{
			get
			{
				return HttpRequestMessage.Method.Method;
			}
			set
			{
				HttpRequestMessage.Method = new HttpMethod(value);
			}
		}

		public string QueryString
		{
			get
			{
				string query = HttpRequestMessage.RequestUri.Query;
				if (query.Length <= 0)
				{
					return string.Empty;
				}
				return query.Substring(1);
			}
			set
			{
				UriBuilder uriBuilder = new UriBuilder(HttpRequestMessage.RequestUri);
				uriBuilder.Query = value;
				HttpRequestMessage.RequestUri = uriBuilder.Uri;
			}
		}

		public bool SuppressEntityBody
		{
			get
			{
				HttpContent content = HttpRequestMessage.Content;
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
				HttpContent content = HttpRequestMessage.Content;
				if (value && content != null && (!content.Headers.ContentLength.HasValue || content.Headers.ContentLength.Value > 0))
				{
					HttpContent httpContent = new ByteArrayContent(Array.Empty<byte>());
					foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
					{
						httpContent.Headers.AddHeaderWithoutValidation(header);
					}
					HttpRequestMessage.Content = httpContent;
					content.Dispose();
				}
				else if (!value && content == null)
				{
					HttpRequestMessage.Content = new ByteArrayContent(Array.Empty<byte>());
				}
			}
		}

		public HttpRequestMessageBackedProperty(HttpRequestMessage httpRequestMessage)
		{
			HttpRequestMessage = httpRequestMessage;
		}

		public HttpRequestMessageProperty CreateTraditionalRequestMessageProperty()
		{
			HttpRequestMessageProperty httpRequestMessageProperty = new HttpRequestMessageProperty();
			string[] allKeys = Headers.AllKeys;
			foreach (string name in allKeys)
			{
				httpRequestMessageProperty.Headers[name] = Headers[name];
			}
			if (Method != "POST")
			{
				httpRequestMessageProperty.Method = Method;
			}
			httpRequestMessageProperty.QueryString = QueryString;
			httpRequestMessageProperty.SuppressEntityBody = SuppressEntityBody;
			return httpRequestMessageProperty;
		}

		public void MergeWithTraditionalProperty(TraditionalHttpRequestMessageProperty propertyToMerge)
		{
			if (propertyToMerge.HasMethodBeenSet)
			{
				Method = propertyToMerge.Method;
			}
			if (propertyToMerge.QueryString != "")
			{
				QueryString = propertyToMerge.QueryString;
			}
			SuppressEntityBody = propertyToMerge.SuppressEntityBody;
			HttpRequestMessage.MergeWebHeaderCollection(propertyToMerge.Headers);
		}
	}

	private TraditionalHttpRequestMessageProperty _traditionalProperty;

	private HttpRequestMessageBackedProperty _httpBackedProperty;

	private bool _initialCopyPerformed;

	private bool _useHttpBackedProperty;

	public static string Name => "httpRequest";

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

	public string Method
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.Method;
			}
			return _httpBackedProperty.Method;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (_useHttpBackedProperty)
			{
				_httpBackedProperty.Method = value;
			}
			else
			{
				_traditionalProperty.Method = value;
			}
		}
	}

	public string QueryString
	{
		get
		{
			if (!_useHttpBackedProperty)
			{
				return _traditionalProperty.QueryString;
			}
			return _httpBackedProperty.QueryString;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (_useHttpBackedProperty)
			{
				_httpBackedProperty.QueryString = value;
			}
			else
			{
				_traditionalProperty.QueryString = value;
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

	public HttpRequestMessage HttpRequestMessage
	{
		get
		{
			if (_useHttpBackedProperty)
			{
				return _httpBackedProperty.HttpRequestMessage;
			}
			return null;
		}
	}

	public HttpRequestMessageProperty()
	{
		_traditionalProperty = new TraditionalHttpRequestMessageProperty();
		_useHttpBackedProperty = false;
	}

	internal HttpRequestMessageProperty(WebHeaderCollection originalHeaders)
	{
		_traditionalProperty = new TraditionalHttpRequestMessageProperty(originalHeaders);
		_useHttpBackedProperty = false;
	}

	internal HttpRequestMessageProperty(HttpRequestMessage httpRequestMessage)
	{
		_httpBackedProperty = new HttpRequestMessageBackedProperty(httpRequestMessage);
		_useHttpBackedProperty = true;
	}

	internal static HttpRequestMessage GetHttpRequestMessageFromMessage(Message message)
	{
		HttpRequestMessage httpRequestMessage = null;
		HttpRequestMessageProperty value = message.Properties.GetValue<HttpRequestMessageProperty>(Name);
		if (value != null)
		{
			httpRequestMessage = value.HttpRequestMessage;
			if (httpRequestMessage != null)
			{
				httpRequestMessage.CopyPropertiesFromMessage(message);
				message.EnsureReadMessageState();
			}
		}
		return httpRequestMessage;
	}

	IMessageProperty IMessageProperty.CreateCopy()
	{
		if (!_useHttpBackedProperty || !_initialCopyPerformed)
		{
			_initialCopyPerformed = true;
			return this;
		}
		return _httpBackedProperty.CreateTraditionalRequestMessageProperty();
	}

	bool IMergeEnabledMessageProperty.TryMergeWithProperty(object propertyToMerge)
	{
		if (_useHttpBackedProperty && propertyToMerge is HttpRequestMessageProperty httpRequestMessageProperty)
		{
			if (!httpRequestMessageProperty._useHttpBackedProperty)
			{
				_httpBackedProperty.MergeWithTraditionalProperty(httpRequestMessageProperty._traditionalProperty);
				httpRequestMessageProperty._traditionalProperty = null;
				httpRequestMessageProperty._httpBackedProperty = _httpBackedProperty;
				httpRequestMessageProperty._useHttpBackedProperty = true;
			}
			return true;
		}
		return false;
	}
}
