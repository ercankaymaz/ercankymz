// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ClientConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ClientConfiguration
{
  private StringCollection m_wellKnownDiscoveryUrls;
  private EndpointDescriptionCollection m_discoveryServers;
  private int m_defaultSessionTimeout;
  private string m_endpointCacheFilePath;
  private int m_minSubscriptionLifetime;
  private ReverseConnectClientConfiguration m_reverseConnect;
  private OperationLimits m_operationLimits;

  public ClientConfiguration() => this.Initialize();

  private void Initialize()
  {
    this.m_defaultSessionTimeout = 60000;
    this.m_minSubscriptionLifetime = 10000;
    this.m_wellKnownDiscoveryUrls = new StringCollection();
    this.m_discoveryServers = new EndpointDescriptionCollection();
    this.m_operationLimits = new OperationLimits();
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [DataMember(IsRequired = false, Order = 0)]
  public int DefaultSessionTimeout
  {
    get => this.m_defaultSessionTimeout;
    set => this.m_defaultSessionTimeout = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 1)]
  public StringCollection WellKnownDiscoveryUrls
  {
    get => this.m_wellKnownDiscoveryUrls;
    set
    {
      this.m_wellKnownDiscoveryUrls = value;
      if (this.m_wellKnownDiscoveryUrls != null)
        return;
      this.m_wellKnownDiscoveryUrls = new StringCollection();
    }
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 2)]
  public EndpointDescriptionCollection DiscoveryServers
  {
    get => this.m_discoveryServers;
    set
    {
      this.m_discoveryServers = value;
      if (this.m_discoveryServers != null)
        return;
      this.m_discoveryServers = new EndpointDescriptionCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 3)]
  public string EndpointCacheFilePath
  {
    get => this.m_endpointCacheFilePath;
    set => this.m_endpointCacheFilePath = value;
  }

  [DataMember(IsRequired = false, Order = 4)]
  public int MinSubscriptionLifetime
  {
    get => this.m_minSubscriptionLifetime;
    set => this.m_minSubscriptionLifetime = value;
  }

  [DataMember(IsRequired = false, Order = 5)]
  public ReverseConnectClientConfiguration ReverseConnect
  {
    get => this.m_reverseConnect;
    set => this.m_reverseConnect = value;
  }

  [DataMember(IsRequired = false, Order = 6)]
  public OperationLimits OperationLimits
  {
    get => this.m_operationLimits;
    set => this.m_operationLimits = value;
  }

  public void Validate()
  {
    if (this.WellKnownDiscoveryUrls.Count != 0)
      return;
    this.WellKnownDiscoveryUrls.AddRange((IEnumerable<string>) Utils.DiscoveryUrls);
  }
}
