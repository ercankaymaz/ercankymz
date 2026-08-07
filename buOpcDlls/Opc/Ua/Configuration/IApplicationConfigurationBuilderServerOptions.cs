// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Configuration.IApplicationConfigurationBuilderServerOptions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderServerOptions : 
  IApplicationConfigurationBuilderClient,
  IApplicationConfigurationBuilderSecurity
{
  IApplicationConfigurationBuilderServerOptions SetMinRequestThreadCount(int minRequestThreadCount);

  IApplicationConfigurationBuilderServerOptions SetMaxRequestThreadCount(int maxRequestThreadCount);

  IApplicationConfigurationBuilderServerOptions SetMaxQueuedRequestCount(int maxQueuedRequestCount);

  IApplicationConfigurationBuilderServerOptions SetDiagnosticsEnabled(bool diagnosticsEnabled);

  IApplicationConfigurationBuilderServerOptions SetMaxSessionCount(int maxSessionCount);

  IApplicationConfigurationBuilderServerOptions SetMinSessionTimeout(int minSessionTimeout);

  IApplicationConfigurationBuilderServerOptions SetMaxSessionTimeout(int maxSessionTimeout);

  IApplicationConfigurationBuilderServerOptions SetMaxBrowseContinuationPoints(
    int maxBrowseContinuationPoints);

  IApplicationConfigurationBuilderServerOptions SetMaxQueryContinuationPoints(
    int maxQueryContinuationPoints);

  IApplicationConfigurationBuilderServerOptions SetMaxHistoryContinuationPoints(
    int maxHistoryContinuationPoints);

  IApplicationConfigurationBuilderServerOptions SetMaxRequestAge(int maxRequestAge);

  IApplicationConfigurationBuilderServerOptions SetMinPublishingInterval(int minPublishingInterval);

  IApplicationConfigurationBuilderServerOptions SetMaxPublishingInterval(int maxPublishingInterval);

  IApplicationConfigurationBuilderServerOptions SetPublishingResolution(int publishingResolution);

  IApplicationConfigurationBuilderServerOptions SetMaxSubscriptionLifetime(
    int maxSubscriptionLifetime);

  IApplicationConfigurationBuilderServerOptions SetMaxMessageQueueSize(int maxMessageQueueSize);

  IApplicationConfigurationBuilderServerOptions SetMaxNotificationQueueSize(
    int maxNotificationQueueSize);

  IApplicationConfigurationBuilderServerOptions SetMaxNotificationsPerPublish(
    int maxNotificationsPerPublish);

  IApplicationConfigurationBuilderServerOptions SetMinMetadataSamplingInterval(
    int minMetadataSamplingInterval);

  IApplicationConfigurationBuilderServerOptions SetAvailableSamplingRates(
    SamplingRateGroupCollection availableSampleRates);

  IApplicationConfigurationBuilderServerOptions SetRegistrationEndpoint(
    EndpointDescription registrationEndpoint);

  IApplicationConfigurationBuilderServerOptions SetMaxRegistrationInterval(
    int maxRegistrationInterval);

  IApplicationConfigurationBuilderServerOptions SetNodeManagerSaveFile(string nodeManagerSaveFile);

  IApplicationConfigurationBuilderServerOptions SetMinSubscriptionLifetime(
    int minSubscriptionLifetime);

  IApplicationConfigurationBuilderServerOptions SetMaxPublishRequestCount(int maxPublishRequestCount);

  IApplicationConfigurationBuilderServerOptions SetMaxSubscriptionCount(int maxSubscriptionCount);

  IApplicationConfigurationBuilderServerOptions SetMaxEventQueueSize(int setMaxEventQueueSize);

  IApplicationConfigurationBuilderServerOptions AddServerProfile(string serverProfile);

  IApplicationConfigurationBuilderServerOptions SetShutdownDelay(int shutdownDelay);

  IApplicationConfigurationBuilderServerOptions AddServerCapabilities(string serverCapability);

  IApplicationConfigurationBuilderServerOptions SetSupportedPrivateKeyFormats(
    StringCollection supportedPrivateKeyFormats);

  IApplicationConfigurationBuilderServerOptions SetMaxTrustListSize(int maxTrustListSize);

  IApplicationConfigurationBuilderServerOptions SetMultiCastDnsEnabled(bool multiCastDnsEnabled);

  IApplicationConfigurationBuilderServerOptions SetReverseConnect(
    ReverseConnectServerConfiguration reverseConnectConfiguration);

  IApplicationConfigurationBuilderServerOptions SetOperationLimits(OperationLimits operationLimits);

  IApplicationConfigurationBuilderServerOptions SetAuditingEnabled(bool auditingEnabled);
}
