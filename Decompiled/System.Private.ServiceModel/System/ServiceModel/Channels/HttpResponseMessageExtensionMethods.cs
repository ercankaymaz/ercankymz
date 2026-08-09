using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace System.ServiceModel.Channels;

internal static class HttpResponseMessageExtensionMethods
{
	internal static void CopyPropertiesFromMessage(this HttpResponseMessage httpResponseMessage, Message message)
	{
		httpResponseMessage.RequestMessage?.CopyPropertiesFromMessage(message);
	}

	internal static bool CreateContentIfNull(this HttpResponseMessage httpResponseMessage)
	{
		if (httpResponseMessage.Content == null)
		{
			httpResponseMessage.Content = new ByteArrayContent(Array.Empty<byte>());
			return true;
		}
		return false;
	}

	internal static void MergeWebHeaderCollection(this HttpResponseMessage responseMessage, WebHeaderCollection headersToMerge)
	{
		responseMessage.CreateContentIfNull();
		HttpRequestMessageExtensionMethods.MergeWebHeaderCollectionWithHttpHeaders(headersToMerge, responseMessage.Headers, responseMessage.Content.Headers);
	}

	internal static WebHeaderCollection ToWebHeaderCollection(this HttpResponseMessage httpResponse)
	{
		IEnumerable<KeyValuePair<string, IEnumerable<string>>> enumerable = httpResponse.Headers;
		if (httpResponse.Content != null)
		{
			enumerable = enumerable.Concat<KeyValuePair<string, IEnumerable<string>>>(httpResponse.Content.Headers);
		}
		return enumerable.ToWebHeaderCollection();
	}
}
