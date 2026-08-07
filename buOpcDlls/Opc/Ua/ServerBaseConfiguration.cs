// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerBaseConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerBaseConfiguration
{
  private StringCollection m_baseAddresses;
  private StringCollection m_alternateBaseAddresses;
  private ServerSecurityPolicyCollection m_securityPolicies;
  private int m_minRequestThreadCount;
  private int m_maxRequestThreadCount;
  private int m_maxQueuedRequestCount;

  public ServerBaseConfiguration() => this.Initialize();

  private void Initialize()
  {
    this.m_baseAddresses = new StringCollection();
    this.m_alternateBaseAddresses = new StringCollection();
    this.m_securityPolicies = new ServerSecurityPolicyCollection();
    this.m_minRequestThreadCount = 10;
    this.m_maxRequestThreadCount = 100;
    this.m_maxQueuedRequestCount = 200;
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  [OnDeserialized]
  private void ValidateSecurityPolicyCollection(StreamingContext context)
  {
    string[] displayNames = Opc.Ua.SecurityPolicies.GetDisplayNames();
    ServerSecurityPolicyCollection policyCollection = new ServerSecurityPolicyCollection();
    foreach (ServerSecurityPolicy securityPolicy1 in (List<ServerSecurityPolicy>) this.m_securityPolicies)
    {
      ServerSecurityPolicy securityPolicy = securityPolicy1;
      if (string.IsNullOrWhiteSpace(securityPolicy.SecurityPolicyUri))
      {
        foreach (string defaultUri in Opc.Ua.SecurityPolicies.GetDefaultUris())
        {
          ServerSecurityPolicy newPolicy = new ServerSecurityPolicy()
          {
            SecurityMode = securityPolicy.SecurityMode,
            SecurityPolicyUri = defaultUri
          };
          if (policyCollection.Find((Predicate<ServerSecurityPolicy>) (s => s.SecurityMode == newPolicy.SecurityMode && string.Equals(s.SecurityPolicyUri, newPolicy.SecurityPolicyUri, StringComparison.Ordinal))) == null)
            policyCollection.Add(newPolicy);
        }
      }
      else
      {
        for (int index = 0; index < displayNames.Length; ++index)
        {
          if (securityPolicy.SecurityPolicyUri.Contains(displayNames[index]))
          {
            if (policyCollection.Find((Predicate<ServerSecurityPolicy>) (s => s.SecurityMode == securityPolicy.SecurityMode && string.Equals(s.SecurityPolicyUri, securityPolicy.SecurityPolicyUri, StringComparison.Ordinal))) == null)
            {
              policyCollection.Add(securityPolicy);
              break;
            }
            break;
          }
        }
      }
    }
    this.m_securityPolicies = policyCollection;
  }

  [DataMember(IsRequired = false, Order = 0)]
  public StringCollection BaseAddresses
  {
    get => this.m_baseAddresses;
    set
    {
      this.m_baseAddresses = value;
      if (this.m_baseAddresses != null)
        return;
      this.m_baseAddresses = new StringCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 1)]
  public StringCollection AlternateBaseAddresses
  {
    get => this.m_alternateBaseAddresses;
    set
    {
      this.m_alternateBaseAddresses = value;
      if (this.m_alternateBaseAddresses != null)
        return;
      this.m_alternateBaseAddresses = new StringCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 2)]
  public ServerSecurityPolicyCollection SecurityPolicies
  {
    get => this.m_securityPolicies;
    set
    {
      this.m_securityPolicies = value;
      if (this.m_securityPolicies != null)
        return;
      this.m_securityPolicies = new ServerSecurityPolicyCollection();
    }
  }

  [DataMember(IsRequired = false, Order = 3)]
  public int MinRequestThreadCount
  {
    get => this.m_minRequestThreadCount;
    set => this.m_minRequestThreadCount = value;
  }

  [DataMember(IsRequired = false, Order = 4)]
  public int MaxRequestThreadCount
  {
    get => this.m_maxRequestThreadCount;
    set => this.m_maxRequestThreadCount = value;
  }

  [DataMember(IsRequired = false, Order = 5)]
  public int MaxQueuedRequestCount
  {
    get => this.m_maxQueuedRequestCount;
    set => this.m_maxQueuedRequestCount = value;
  }

  public virtual void Validate()
  {
    if (this.m_securityPolicies.Count != 0)
      return;
    this.m_securityPolicies.Add(new ServerSecurityPolicy());
  }
}
