// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Configuration.IApplicationConfigurationBuilderClientOptions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderClientOptions : 
  IApplicationConfigurationBuilderSecurity
{
  IApplicationConfigurationBuilderClientOptions SetDefaultSessionTimeout(int defaultSessionTimeout);

  IApplicationConfigurationBuilderClientOptions AddWellKnownDiscoveryUrls(
    string wellKnownDiscoveryUrl);

  IApplicationConfigurationBuilderClientOptions AddDiscoveryServer(
    EndpointDescription discoveryServer);

  IApplicationConfigurationBuilderClientOptions SetEndpointCacheFilePath(
    string endpointCacheFilePath);

  IApplicationConfigurationBuilderClientOptions SetMinSubscriptionLifetime(
    int minSubscriptionLifetime);

  IApplicationConfigurationBuilderClientOptions SetReverseConnect(
    ReverseConnectClientConfiguration reverseConnect);

  IApplicationConfigurationBuilderClientOptions SetClientOperationLimits(
    OperationLimits operationLimits);
}
