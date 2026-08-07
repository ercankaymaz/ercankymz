// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerConfiguration : ServerBaseConfiguration
{
  private UserTokenPolicyCollection m_userTokenPolicies;
  private bool m_diagnosticsEnabled;
  private int m_maxSessionCount;
  private int m_minSessionTimeout;
  private int m_maxSessionTimeout;
  private int m_maxBrowseContinuationPoints;
  private int m_maxQueryContinuationPoints;
  private int m_maxHistoryContinuationPoints;
  private int m_maxRequestAge;
  private int m_minPublishingInterval;
  private int m_maxPublishingInterval;
  private int m_publishingResolution;
  private int m_minSubscriptionLifetime;
  private int m_maxSubscriptionLifetime;
  private int m_maxMessageQueueSize;
  private int m_maxNotificationQueueSize;
  private int m_maxNotificationsPerPublish;
  private int m_minMetadataSamplingInterval;
  private SamplingRateGroupCollection m_availableSamplingRates;
  private EndpointDescription m_registrationEndpoint;
  private int m_maxRegistrationInterval;
  private string m_nodeManagerSaveFile;
  private int m_maxPublishRequestCount;
  private int m_maxSubscriptionCount;
  private int m_maxEventQueueSize;
  private StringCollection m_serverProfileArray;
  private int m_shutdownDelay;
  private StringCollection m_serverCapabilities;
  private StringCollection m_supportedPrivateKeyFormats;
  private int m_maxTrustListSize;
  private bool m_multicastDnsEnabled;
  private ReverseConnectServerConfiguration m_reverseConnect;
  private OperationLimits m_operationLimits;
  private bool m_auditingEnabled;

  public ServerConfiguration() => this.Initialize();

  private void Initialize()
  {
    this.m_userTokenPolicies = new UserTokenPolicyCollection();
    this.m_diagnosticsEnabled = false;
    this.m_maxSessionCount = 100;
    this.m_maxSessionTimeout = 3600000;
    this.m_minSessionTimeout = 10000;
    this.m_maxBrowseContinuationPoints = 10;
    this.m_maxQueryContinuationPoints = 10;
    this.m_maxHistoryContinuationPoints = 100;
    this.m_maxRequestAge = 600000;
    this.m_minPublishingInterval = 100;
    this.m_maxPublishingInterval = 3600000;
    this.m_publishingResolution = 100;
    this.m_minSubscriptionLifetime = 10000;
    this.m_maxSubscriptionLifetime = 3600000;
    this.m_maxMessageQueueSize = 10;
    this.m_maxNotificationQueueSize = 100;
    this.m_maxNotificationsPerPublish = 100;
    this.m_minMetadataSamplingInterval = 1000;
    this.m_availableSamplingRates = new SamplingRateGroupCollection();
    this.m_registrationEndpoint = (EndpointDescription) null;
    this.m_maxRegistrationInterval = 30000;
    this.m_maxPublishRequestCount = 20;
    this.m_maxSubscriptionCount = 100;
    this.m_maxEventQueueSize = 10000;
    this.m_serverProfileArray = (StringCollection) new string[1]
    {
      "http://opcfoundation.org/UA-Profile/Server/StandardUA2017"
    };
    this.m_shutdownDelay = 5;
    this.m_serverCapabilities = (StringCollection) new string[1]
    {
      "DA"
    };
    this.m_supportedPrivateKeyFormats = (StringCollection) new string[2]
    {
      "PFX",
      "PEM"
    };
    this.m_maxTrustListSize = 0;
    this.m_multicastDnsEnabled = false;
    this.m_auditingEnabled = false;
  }

  [OnDeserializing]
  public new void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
  public UserTokenPolicyCollection UserTokenPolicies
  {
    get => this.m_userTokenPolicies;
    set
    {
      this.m_userTokenPolicies = value;
      if (this.m_userTokenPolicies != null)
        return;
      this.m_userTokenPolicies = new UserTokenPolicyCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 4)]
  public bool DiagnosticsEnabled
  {
    get => this.m_diagnosticsEnabled;
    set => this.m_diagnosticsEnabled = value;
  }

  [DataMember(IsRequired = false, Order = 5)]
  public int MaxSessionCount
  {
    get => this.m_maxSessionCount;
    set => this.m_maxSessionCount = value;
  }

  [DataMember(IsRequired = false, Order = 6)]
  public int MinSessionTimeout
  {
    get => this.m_minSessionTimeout;
    set => this.m_minSessionTimeout = value;
  }

  [DataMember(IsRequired = false, Order = 7)]
  public int MaxSessionTimeout
  {
    get => this.m_maxSessionTimeout;
    set => this.m_maxSessionTimeout = value;
  }

  [DataMember(IsRequired = false, Order = 8)]
  public int MaxBrowseContinuationPoints
  {
    get => this.m_maxBrowseContinuationPoints;
    set => this.m_maxBrowseContinuationPoints = value;
  }

  [DataMember(IsRequired = false, Order = 9)]
  public int MaxQueryContinuationPoints
  {
    get => this.m_maxQueryContinuationPoints;
    set => this.m_maxQueryContinuationPoints = value;
  }

  [DataMember(IsRequired = false, Order = 10)]
  public int MaxHistoryContinuationPoints
  {
    get => this.m_maxHistoryContinuationPoints;
    set => this.m_maxHistoryContinuationPoints = value;
  }

  [DataMember(IsRequired = false, Order = 11)]
  public int MaxRequestAge
  {
    get => this.m_maxRequestAge;
    set => this.m_maxRequestAge = value;
  }

  [DataMember(IsRequired = false, Order = 12)]
  public int MinPublishingInterval
  {
    get => this.m_minPublishingInterval;
    set => this.m_minPublishingInterval = value;
  }

  [DataMember(IsRequired = false, Order = 13)]
  public int MaxPublishingInterval
  {
    get => this.m_maxPublishingInterval;
    set => this.m_maxPublishingInterval = value;
  }

  [DataMember(IsRequired = false, Order = 14)]
  public int PublishingResolution
  {
    get => this.m_publishingResolution;
    set => this.m_publishingResolution = value;
  }

  [DataMember(IsRequired = false, Order = 15)]
  public int MaxSubscriptionLifetime
  {
    get => this.m_maxSubscriptionLifetime;
    set => this.m_maxSubscriptionLifetime = value;
  }

  [DataMember(IsRequired = false, Order = 16 /*0x10*/)]
  public int MaxMessageQueueSize
  {
    get => this.m_maxMessageQueueSize;
    set => this.m_maxMessageQueueSize = value;
  }

  [DataMember(IsRequired = false, Order = 17)]
  public int MaxNotificationQueueSize
  {
    get => this.m_maxNotificationQueueSize;
    set => this.m_maxNotificationQueueSize = value;
  }

  [DataMember(IsRequired = false, Order = 18)]
  public int MaxNotificationsPerPublish
  {
    get => this.m_maxNotificationsPerPublish;
    set => this.m_maxNotificationsPerPublish = value;
  }

  [DataMember(IsRequired = false, Order = 19)]
  public int MinMetadataSamplingInterval
  {
    get => this.m_minMetadataSamplingInterval;
    set => this.m_minMetadataSamplingInterval = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 20)]
  public SamplingRateGroupCollection AvailableSamplingRates
  {
    get => this.m_availableSamplingRates;
    set => this.m_availableSamplingRates = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 21)]
  public EndpointDescription RegistrationEndpoint
  {
    get => this.m_registrationEndpoint;
    set => this.m_registrationEndpoint = value;
  }

  [DataMember(IsRequired = false, Order = 22)]
  public int MaxRegistrationInterval
  {
    get => this.m_maxRegistrationInterval;
    set => this.m_maxRegistrationInterval = value;
  }

  [DataMember(IsRequired = false, Order = 23)]
  public string NodeManagerSaveFile
  {
    get => this.m_nodeManagerSaveFile;
    set => this.m_nodeManagerSaveFile = value;
  }

  [DataMember(IsRequired = false, Order = 24)]
  public int MinSubscriptionLifetime
  {
    get => this.m_minSubscriptionLifetime;
    set => this.m_minSubscriptionLifetime = value;
  }

  [DataMember(IsRequired = false, Order = 25)]
  public int MaxPublishRequestCount
  {
    get => this.m_maxPublishRequestCount;
    set => this.m_maxPublishRequestCount = value;
  }

  [DataMember(IsRequired = false, Order = 26)]
  public int MaxSubscriptionCount
  {
    get => this.m_maxSubscriptionCount;
    set => this.m_maxSubscriptionCount = value;
  }

  [DataMember(IsRequired = false, Order = 27)]
  public int MaxEventQueueSize
  {
    get => this.m_maxEventQueueSize;
    set => this.m_maxEventQueueSize = value;
  }

  [DataMember(IsRequired = false, Order = 28)]
  public StringCollection ServerProfileArray
  {
    get => this.m_serverProfileArray;
    set
    {
      this.m_serverProfileArray = value;
      if (this.m_serverProfileArray != null)
        return;
      this.m_serverProfileArray = new StringCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 29)]
  public int ShutdownDelay
  {
    get => this.m_shutdownDelay;
    set => this.m_shutdownDelay = value;
  }

  [DataMember(IsRequired = false, Order = 30)]
  public StringCollection ServerCapabilities
  {
    get => this.m_serverCapabilities;
    set
    {
      this.m_serverCapabilities = value;
      if (this.m_serverCapabilities != null)
        return;
      this.m_serverCapabilities = new StringCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 31 /*0x1F*/)]
  public StringCollection SupportedPrivateKeyFormats
  {
    get => this.m_supportedPrivateKeyFormats;
    set
    {
      this.m_supportedPrivateKeyFormats = value;
      if (this.m_supportedPrivateKeyFormats != null)
        return;
      this.m_supportedPrivateKeyFormats = new StringCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 32 /*0x20*/)]
  public int MaxTrustListSize
  {
    get => this.m_maxTrustListSize;
    set => this.m_maxTrustListSize = value;
  }

  [DataMember(IsRequired = false, Order = 33)]
  public bool MultiCastDnsEnabled
  {
    get => this.m_multicastDnsEnabled;
    set => this.m_multicastDnsEnabled = value;
  }

  [DataMember(IsRequired = false, Order = 34)]
  public ReverseConnectServerConfiguration ReverseConnect
  {
    get => this.m_reverseConnect;
    set => this.m_reverseConnect = value;
  }

  [DataMember(IsRequired = false, Order = 35)]
  public OperationLimits OperationLimits
  {
    get => this.m_operationLimits;
    set => this.m_operationLimits = value;
  }

  [DataMember(IsRequired = false, Order = 36)]
  public bool AuditingEnabled
  {
    get => this.m_auditingEnabled;
    set => this.m_auditingEnabled = value;
  }

  public override void Validate()
  {
    base.Validate();
    if (this.m_userTokenPolicies.Count != 0)
      return;
    this.m_userTokenPolicies.Add(new UserTokenPolicy());
  }
}
