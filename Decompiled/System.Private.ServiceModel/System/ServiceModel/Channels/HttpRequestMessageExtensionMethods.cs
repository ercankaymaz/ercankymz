using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace System.ServiceModel.Channels;

public static class HttpRequestMessageExtensionMethods
{
	private const string MessageHeadersPropertyKey = "System.ServiceModel.Channels.MessageHeaders";

	internal static HashSet<string> WellKnownContentHeaders = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Content-Disposition", "Content-Encoding", "Content-Language", "Content-Length", "Content-Location", "Content-MD5", "Content-Range", "Content-Type", "Expires", "Last-Modified" };

	internal static void CopyPropertiesFromMessage(this HttpRequestMessage httpRequestMessage, Message message)
	{
		IDictionary<string, object> properties = httpRequestMessage.Properties;
		CopyProperties(message.Properties, properties);
		properties["System.ServiceModel.Channels.MessageHeaders"] = message.Headers;
	}

	internal static void AddHeaderWithoutValidation(this HttpHeaders httpHeaders, KeyValuePair<string, IEnumerable<string>> header)
	{
		if (!httpHeaders.TryAddWithoutValidation(header.Key, header.Value))
		{
			throw FxTrace.Exception.AsError(new InvalidOperationException(System.SR.Format(System.SR.CopyHttpHeaderFailed, header.Key, header.Value, httpHeaders.GetType().Name)));
		}
	}

	private static void CopyProperties(MessageProperties messageProperties, IDictionary<string, object> properties)
	{
		foreach (KeyValuePair<string, object> item in (IEnumerable<KeyValuePair<string, object>>)messageProperties)
		{
			object value = item.Value;
			string key = item.Key;
			if ((!(value is HttpRequestMessageProperty) || !string.Equals(key, HttpRequestMessageProperty.Name, StringComparison.OrdinalIgnoreCase)) && (!(value is HttpResponseMessageProperty) || !string.Equals(key, HttpResponseMessageProperty.Name, StringComparison.OrdinalIgnoreCase)))
			{
				properties[key] = value;
			}
		}
	}

	public static bool CreateContentIfNull(this HttpRequestMessage httpRequestMessage)
	{
		if (httpRequestMessage.Content == null)
		{
			httpRequestMessage.Content = new ByteArrayContent(Array.Empty<byte>());
			return true;
		}
		return false;
	}

	internal static void MergeWebHeaderCollection(this HttpRequestMessage requestMessage, WebHeaderCollection headersToMerge)
	{
		requestMessage.CreateContentIfNull();
		MergeWebHeaderCollectionWithHttpHeaders(headersToMerge, requestMessage.Headers, requestMessage.Content.Headers);
	}

	internal static void MergeWebHeaderCollectionWithHttpHeaders(WebHeaderCollection headersToMerge, HttpHeaders mainHeaders, HttpHeaders contentHeaders)
	{
		string[] allKeys = headersToMerge.AllKeys;
		foreach (string text in allKeys)
		{
			if (WellKnownContentHeaders.Contains(text))
			{
				contentHeaders.TryAddWithoutValidation(text, headersToMerge[text]);
			}
			else
			{
				mainHeaders.TryAddWithoutValidation(text, headersToMerge[text]);
			}
		}
	}

	internal static WebHeaderCollection ToWebHeaderCollection(this HttpRequestMessage httpRequest)
	{
		IEnumerable<KeyValuePair<string, IEnumerable<string>>> enumerable = httpRequest.Headers;
		if (httpRequest.Content != null)
		{
			enumerable = enumerable.Concat<KeyValuePair<string, IEnumerable<string>>>(httpRequest.Content.Headers);
		}
		return enumerable.ToWebHeaderCollection();
	}

	internal static WebHeaderCollection ToWebHeaderCollection(this IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers)
	{
		WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
		foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
		{
			webHeaderCollection[header.Key] = string.Join(",", header.Value);
		}
		return webHeaderCollection;
	}
}
