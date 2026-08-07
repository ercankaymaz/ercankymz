// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.CoreClientUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public static class CoreClientUtils
{
  public static readonly int DefaultDiscoverTimeout = 15000;

  public static IList<string> DiscoverServers(ApplicationConfiguration configuration)
  {
    return CoreClientUtils.DiscoverServers(configuration, CoreClientUtils.DefaultDiscoverTimeout);
  }

  public static IList<string> DiscoverServers(
    ApplicationConfiguration configuration,
    int discoverTimeout)
  {
    List<string> stringList = new List<string>();
    EndpointConfiguration configuration1 = EndpointConfiguration.Create(configuration);
    configuration1.OperationTimeout = discoverTimeout;
    using (DiscoveryClient discoveryClient = DiscoveryClient.Create(new Uri(string.Format(Utils.DiscoveryUrls[0], (object) "localhost")), configuration1))
    {
      ApplicationDescriptionCollection servers = discoveryClient.FindServers((StringCollection) null);
      for (int index1 = 0; index1 < servers.Count; ++index1)
      {
        if (servers[index1].ApplicationType != ApplicationType.DiscoveryServer)
        {
          for (int index2 = 0; index2 < servers[index1].DiscoveryUrls.Count; ++index2)
          {
            string str = servers[index1].DiscoveryUrls[index2];
            if (str.EndsWith("/discovery"))
              str = str.Substring(0, str.Length - "/discovery".Length);
            if (!stringList.Contains(str))
              stringList.Add(str);
          }
        }
      }
    }
    return (IList<string>) stringList;
  }

  public static EndpointDescription SelectEndpoint(string discoveryUrl, bool useSecurity)
  {
    return CoreClientUtils.SelectEndpoint(discoveryUrl, useSecurity, CoreClientUtils.DefaultDiscoverTimeout);
  }

  public static EndpointDescription SelectEndpoint(
    string discoveryUrl,
    bool useSecurity,
    int discoverTimeout)
  {
    Uri discoveryUrl1 = CoreClientUtils.GetDiscoveryUrl(discoveryUrl);
    EndpointConfiguration configuration = EndpointConfiguration.Create();
    configuration.OperationTimeout = discoverTimeout;
    using (DiscoveryClient discoveryClient = DiscoveryClient.Create(discoveryUrl1, configuration))
    {
      EndpointDescriptionCollection endpoints = discoveryClient.GetEndpoints((StringCollection) null);
      return CoreClientUtils.SelectEndpoint(discoveryUrl1, endpoints, useSecurity);
    }
  }

  public static EndpointDescription SelectEndpoint(
    ApplicationConfiguration application,
    ITransportWaitingConnection connection,
    bool useSecurity)
  {
    return CoreClientUtils.SelectEndpoint(application, connection, useSecurity, CoreClientUtils.DefaultDiscoverTimeout);
  }

  public static EndpointDescription SelectEndpoint(
    ApplicationConfiguration application,
    ITransportWaitingConnection connection,
    bool useSecurity,
    int discoverTimeout)
  {
    EndpointConfiguration configuration = EndpointConfiguration.Create();
    configuration.OperationTimeout = discoverTimeout > 0 ? discoverTimeout : CoreClientUtils.DefaultDiscoverTimeout;
    using (DiscoveryClient discoveryClient = DiscoveryClient.Create(application, connection, configuration))
      return CoreClientUtils.SelectEndpoint(new Uri(discoveryClient.Endpoint.EndpointUrl), discoveryClient.GetEndpoints((StringCollection) null), useSecurity);
  }

  public static EndpointDescription SelectEndpoint(
    ApplicationConfiguration application,
    string discoveryUrl,
    bool useSecurity)
  {
    return CoreClientUtils.SelectEndpoint(application, discoveryUrl, useSecurity, CoreClientUtils.DefaultDiscoverTimeout);
  }

  public static EndpointDescription SelectEndpoint(
    ApplicationConfiguration application,
    string discoveryUrl,
    bool useSecurity,
    int discoverTimeout)
  {
    Uri discoveryUrl1 = CoreClientUtils.GetDiscoveryUrl(discoveryUrl);
    EndpointConfiguration configuration = EndpointConfiguration.Create();
    configuration.OperationTimeout = discoverTimeout;
    using (DiscoveryClient discoveryClient = DiscoveryClient.Create(application, discoveryUrl1, configuration))
    {
      EndpointDescription endpointDescription = CoreClientUtils.SelectEndpoint(new Uri(discoveryClient.Endpoint.EndpointUrl), discoveryClient.GetEndpoints((StringCollection) null), useSecurity);
      Uri uri = Utils.ParseUri(endpointDescription.EndpointUrl);
      if (uri != (Uri) null && uri.Scheme == discoveryUrl1.Scheme)
        endpointDescription.EndpointUrl = new UriBuilder(uri)
        {
          Host = discoveryUrl1.DnsSafeHost,
          Port = discoveryUrl1.Port
        }.ToString();
      return endpointDescription;
    }
  }

  public static EndpointDescription SelectEndpoint(
    Uri url,
    EndpointDescriptionCollection endpoints,
    bool useSecurity)
  {
    EndpointDescription endpointDescription = (EndpointDescription) null;
    for (int index = 0; index < endpoints.Count; ++index)
    {
      EndpointDescription endpoint = endpoints[index];
      if (endpoint.EndpointUrl.StartsWith(url.Scheme))
      {
        if (useSecurity)
        {
          if (endpoint.SecurityMode == MessageSecurityMode.None || SecurityPolicies.GetDisplayName(endpoint.SecurityPolicyUri) == null)
            continue;
        }
        else if (endpoint.SecurityMode != MessageSecurityMode.None)
          continue;
        if (endpointDescription == null)
          endpointDescription = endpoint;
        if (endpoint.SecurityMode > endpointDescription.SecurityMode || endpoint.SecurityMode == endpointDescription.SecurityMode && (int) endpoint.SecurityLevel > (int) endpointDescription.SecurityLevel)
          endpointDescription = endpoint;
      }
    }
    if (endpointDescription == null && endpoints.Count > 0)
      endpointDescription = endpoints.FirstOrDefault<EndpointDescription>((Func<EndpointDescription, bool>) (e =>
      {
        string endpointUrl = e.EndpointUrl;
        return endpointUrl != null && endpointUrl.StartsWith(url.Scheme);
      }));
    return endpointDescription;
  }

  public static Uri GetDiscoveryUrl(string discoveryUrl)
  {
    if (discoveryUrl.StartsWith("http", StringComparison.Ordinal) && !discoveryUrl.EndsWith("/discovery", StringComparison.OrdinalIgnoreCase))
      discoveryUrl += "/discovery";
    return new Uri(discoveryUrl);
  }

  internal static OpcUaClientEventSource EventLog { get; } = new OpcUaClientEventSource();
}
