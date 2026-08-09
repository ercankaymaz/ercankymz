using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Opc.Ua.Client;

[ComVisible(true)]
public static class CoreClientUtils
{
	public static readonly int DefaultDiscoverTimeout = 15000;

	internal static OpcUaClientEventSource EventLog { get; } = new OpcUaClientEventSource();

	public static IList<string> DiscoverServers(ApplicationConfiguration configuration)
	{
		return DiscoverServers(configuration, DefaultDiscoverTimeout);
	}

	public static IList<string> DiscoverServers(ApplicationConfiguration configuration, int discoverTimeout)
	{
		List<string> list = new List<string>();
		EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
		endpointConfiguration.OperationTimeout = discoverTimeout;
		using DiscoveryClient discoveryClient = DiscoveryClient.Create(new Uri(string.Format(Utils.DiscoveryUrls[0], "localhost")), endpointConfiguration);
		ApplicationDescriptionCollection applicationDescriptionCollection = discoveryClient.FindServers(null);
		for (int i = 0; i < applicationDescriptionCollection.Count; i++)
		{
			if (applicationDescriptionCollection[i].ApplicationType == ApplicationType.DiscoveryServer)
			{
				continue;
			}
			for (int j = 0; j < applicationDescriptionCollection[i].DiscoveryUrls.Count; j++)
			{
				string text = applicationDescriptionCollection[i].DiscoveryUrls[j];
				if (text.EndsWith("/discovery"))
				{
					text = text.Substring(0, text.Length - "/discovery".Length);
				}
				if (!list.Contains(text))
				{
					list.Add(text);
				}
			}
		}
		return list;
	}

	public static EndpointDescription SelectEndpoint(string discoveryUrl, bool useSecurity)
	{
		return SelectEndpoint(discoveryUrl, useSecurity, DefaultDiscoverTimeout);
	}

	public static EndpointDescription SelectEndpoint(string discoveryUrl, bool useSecurity, int discoverTimeout)
	{
		Uri discoveryUrl2 = GetDiscoveryUrl(discoveryUrl);
		EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create();
		endpointConfiguration.OperationTimeout = discoverTimeout;
		using DiscoveryClient discoveryClient = DiscoveryClient.Create(discoveryUrl2, endpointConfiguration);
		EndpointDescriptionCollection endpoints = discoveryClient.GetEndpoints(null);
		return SelectEndpoint(discoveryUrl2, endpoints, useSecurity);
	}

	public static EndpointDescription SelectEndpoint(ApplicationConfiguration application, ITransportWaitingConnection connection, bool useSecurity)
	{
		return SelectEndpoint(application, connection, useSecurity, DefaultDiscoverTimeout);
	}

	public static EndpointDescription SelectEndpoint(ApplicationConfiguration application, ITransportWaitingConnection connection, bool useSecurity, int discoverTimeout)
	{
		EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create();
		endpointConfiguration.OperationTimeout = ((discoverTimeout > 0) ? discoverTimeout : DefaultDiscoverTimeout);
		using DiscoveryClient discoveryClient = DiscoveryClient.Create(application, connection, endpointConfiguration);
		Uri url = new Uri(discoveryClient.Endpoint.EndpointUrl);
		EndpointDescriptionCollection endpoints = discoveryClient.GetEndpoints(null);
		return SelectEndpoint(url, endpoints, useSecurity);
	}

	public static EndpointDescription SelectEndpoint(ApplicationConfiguration application, string discoveryUrl, bool useSecurity)
	{
		return SelectEndpoint(application, discoveryUrl, useSecurity, DefaultDiscoverTimeout);
	}

	public static EndpointDescription SelectEndpoint(ApplicationConfiguration application, string discoveryUrl, bool useSecurity, int discoverTimeout)
	{
		Uri discoveryUrl2 = GetDiscoveryUrl(discoveryUrl);
		EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create();
		endpointConfiguration.OperationTimeout = discoverTimeout;
		using DiscoveryClient discoveryClient = DiscoveryClient.Create(application, discoveryUrl2, endpointConfiguration);
		Uri url = new Uri(discoveryClient.Endpoint.EndpointUrl);
		EndpointDescriptionCollection endpoints = discoveryClient.GetEndpoints(null);
		EndpointDescription endpointDescription = SelectEndpoint(url, endpoints, useSecurity);
		Uri uri = Utils.ParseUri(endpointDescription.EndpointUrl);
		if (uri != null && uri.Scheme == discoveryUrl2.Scheme)
		{
			UriBuilder uriBuilder = new UriBuilder(uri);
			uriBuilder.Host = discoveryUrl2.DnsSafeHost;
			uriBuilder.Port = discoveryUrl2.Port;
			endpointDescription.EndpointUrl = uriBuilder.ToString();
		}
		return endpointDescription;
	}

	public static EndpointDescription SelectEndpoint(Uri url, EndpointDescriptionCollection endpoints, bool useSecurity)
	{
		EndpointDescription endpointDescription = null;
		for (int i = 0; i < endpoints.Count; i++)
		{
			EndpointDescription endpointDescription2 = endpoints[i];
			if (!endpointDescription2.EndpointUrl.StartsWith(url.Scheme))
			{
				continue;
			}
			if (useSecurity)
			{
				if (endpointDescription2.SecurityMode == MessageSecurityMode.None || SecurityPolicies.GetDisplayName(endpointDescription2.SecurityPolicyUri) == null)
				{
					continue;
				}
			}
			else if (endpointDescription2.SecurityMode != MessageSecurityMode.None)
			{
				continue;
			}
			if (endpointDescription == null)
			{
				endpointDescription = endpointDescription2;
			}
			if (endpointDescription2.SecurityMode > endpointDescription.SecurityMode || (endpointDescription2.SecurityMode == endpointDescription.SecurityMode && endpointDescription2.SecurityLevel > endpointDescription.SecurityLevel))
			{
				endpointDescription = endpointDescription2;
			}
		}
		if (endpointDescription == null && endpoints.Count > 0)
		{
			endpointDescription = endpoints.FirstOrDefault((EndpointDescription e) => e.EndpointUrl?.StartsWith(url.Scheme) ?? false);
		}
		return endpointDescription;
	}

	public static Uri GetDiscoveryUrl(string discoveryUrl)
	{
		if (discoveryUrl.StartsWith("http", StringComparison.Ordinal) && !discoveryUrl.EndsWith("/discovery", StringComparison.OrdinalIgnoreCase))
		{
			discoveryUrl += "/discovery";
		}
		return new Uri(discoveryUrl);
	}
}
