// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerDiagnosticsSummaryDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServerDiagnosticsSummaryDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_serverViewCount;
  private uint m_currentSessionCount;
  private uint m_cumulatedSessionCount;
  private uint m_securityRejectedSessionCount;
  private uint m_rejectedSessionCount;
  private uint m_sessionTimeoutCount;
  private uint m_sessionAbortCount;
  private uint m_currentSubscriptionCount;
  private uint m_cumulatedSubscriptionCount;
  private uint m_publishingIntervalCount;
  private uint m_securityRejectedRequestsCount;
  private uint m_rejectedRequestsCount;

  public ServerDiagnosticsSummaryDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_serverViewCount = 0U;
    this.m_currentSessionCount = 0U;
    this.m_cumulatedSessionCount = 0U;
    this.m_securityRejectedSessionCount = 0U;
    this.m_rejectedSessionCount = 0U;
    this.m_sessionTimeoutCount = 0U;
    this.m_sessionAbortCount = 0U;
    this.m_currentSubscriptionCount = 0U;
    this.m_cumulatedSubscriptionCount = 0U;
    this.m_publishingIntervalCount = 0U;
    this.m_securityRejectedRequestsCount = 0U;
    this.m_rejectedRequestsCount = 0U;
  }

  [DataMember(Name = "ServerViewCount", IsRequired = false, Order = 1)]
  public uint ServerViewCount
  {
    get => this.m_serverViewCount;
    set => this.m_serverViewCount = value;
  }

  [DataMember(Name = "CurrentSessionCount", IsRequired = false, Order = 2)]
  public uint CurrentSessionCount
  {
    get => this.m_currentSessionCount;
    set => this.m_currentSessionCount = value;
  }

  [DataMember(Name = "CumulatedSessionCount", IsRequired = false, Order = 3)]
  public uint CumulatedSessionCount
  {
    get => this.m_cumulatedSessionCount;
    set => this.m_cumulatedSessionCount = value;
  }

  [DataMember(Name = "SecurityRejectedSessionCount", IsRequired = false, Order = 4)]
  public uint SecurityRejectedSessionCount
  {
    get => this.m_securityRejectedSessionCount;
    set => this.m_securityRejectedSessionCount = value;
  }

  [DataMember(Name = "RejectedSessionCount", IsRequired = false, Order = 5)]
  public uint RejectedSessionCount
  {
    get => this.m_rejectedSessionCount;
    set => this.m_rejectedSessionCount = value;
  }

  [DataMember(Name = "SessionTimeoutCount", IsRequired = false, Order = 6)]
  public uint SessionTimeoutCount
  {
    get => this.m_sessionTimeoutCount;
    set => this.m_sessionTimeoutCount = value;
  }

  [DataMember(Name = "SessionAbortCount", IsRequired = false, Order = 7)]
  public uint SessionAbortCount
  {
    get => this.m_sessionAbortCount;
    set => this.m_sessionAbortCount = value;
  }

  [DataMember(Name = "CurrentSubscriptionCount", IsRequired = false, Order = 8)]
  public uint CurrentSubscriptionCount
  {
    get => this.m_currentSubscriptionCount;
    set => this.m_currentSubscriptionCount = value;
  }

  [DataMember(Name = "CumulatedSubscriptionCount", IsRequired = false, Order = 9)]
  public uint CumulatedSubscriptionCount
  {
    get => this.m_cumulatedSubscriptionCount;
    set => this.m_cumulatedSubscriptionCount = value;
  }

  [DataMember(Name = "PublishingIntervalCount", IsRequired = false, Order = 10)]
  public uint PublishingIntervalCount
  {
    get => this.m_publishingIntervalCount;
    set => this.m_publishingIntervalCount = value;
  }

  [DataMember(Name = "SecurityRejectedRequestsCount", IsRequired = false, Order = 11)]
  public uint SecurityRejectedRequestsCount
  {
    get => this.m_securityRejectedRequestsCount;
    set => this.m_securityRejectedRequestsCount = value;
  }

  [DataMember(Name = "RejectedRequestsCount", IsRequired = false, Order = 12)]
  public uint RejectedRequestsCount
  {
    get => this.m_rejectedRequestsCount;
    set => this.m_rejectedRequestsCount = value;
  }

  public virtual ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.ServerDiagnosticsSummaryDataType;
  }

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerDiagnosticsSummaryDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerDiagnosticsSummaryDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerDiagnosticsSummaryDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("ServerViewCount", this.ServerViewCount);
    encoder.WriteUInt32("CurrentSessionCount", this.CurrentSessionCount);
    encoder.WriteUInt32("CumulatedSessionCount", this.CumulatedSessionCount);
    encoder.WriteUInt32("SecurityRejectedSessionCount", this.SecurityRejectedSessionCount);
    encoder.WriteUInt32("RejectedSessionCount", this.RejectedSessionCount);
    encoder.WriteUInt32("SessionTimeoutCount", this.SessionTimeoutCount);
    encoder.WriteUInt32("SessionAbortCount", this.SessionAbortCount);
    encoder.WriteUInt32("CurrentSubscriptionCount", this.CurrentSubscriptionCount);
    encoder.WriteUInt32("CumulatedSubscriptionCount", this.CumulatedSubscriptionCount);
    encoder.WriteUInt32("PublishingIntervalCount", this.PublishingIntervalCount);
    encoder.WriteUInt32("SecurityRejectedRequestsCount", this.SecurityRejectedRequestsCount);
    encoder.WriteUInt32("RejectedRequestsCount", this.RejectedRequestsCount);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ServerViewCount = decoder.ReadUInt32("ServerViewCount");
    this.CurrentSessionCount = decoder.ReadUInt32("CurrentSessionCount");
    this.CumulatedSessionCount = decoder.ReadUInt32("CumulatedSessionCount");
    this.SecurityRejectedSessionCount = decoder.ReadUInt32("SecurityRejectedSessionCount");
    this.RejectedSessionCount = decoder.ReadUInt32("RejectedSessionCount");
    this.SessionTimeoutCount = decoder.ReadUInt32("SessionTimeoutCount");
    this.SessionAbortCount = decoder.ReadUInt32("SessionAbortCount");
    this.CurrentSubscriptionCount = decoder.ReadUInt32("CurrentSubscriptionCount");
    this.CumulatedSubscriptionCount = decoder.ReadUInt32("CumulatedSubscriptionCount");
    this.PublishingIntervalCount = decoder.ReadUInt32("PublishingIntervalCount");
    this.SecurityRejectedRequestsCount = decoder.ReadUInt32("SecurityRejectedRequestsCount");
    this.RejectedRequestsCount = decoder.ReadUInt32("RejectedRequestsCount");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ServerDiagnosticsSummaryDataType diagnosticsSummaryDataType && Utils.IsEqual((object) this.m_serverViewCount, (object) diagnosticsSummaryDataType.m_serverViewCount) && Utils.IsEqual((object) this.m_currentSessionCount, (object) diagnosticsSummaryDataType.m_currentSessionCount) && Utils.IsEqual((object) this.m_cumulatedSessionCount, (object) diagnosticsSummaryDataType.m_cumulatedSessionCount) && Utils.IsEqual((object) this.m_securityRejectedSessionCount, (object) diagnosticsSummaryDataType.m_securityRejectedSessionCount) && Utils.IsEqual((object) this.m_rejectedSessionCount, (object) diagnosticsSummaryDataType.m_rejectedSessionCount) && Utils.IsEqual((object) this.m_sessionTimeoutCount, (object) diagnosticsSummaryDataType.m_sessionTimeoutCount) && Utils.IsEqual((object) this.m_sessionAbortCount, (object) diagnosticsSummaryDataType.m_sessionAbortCount) && Utils.IsEqual((object) this.m_currentSubscriptionCount, (object) diagnosticsSummaryDataType.m_currentSubscriptionCount) && Utils.IsEqual((object) this.m_cumulatedSubscriptionCount, (object) diagnosticsSummaryDataType.m_cumulatedSubscriptionCount) && Utils.IsEqual((object) this.m_publishingIntervalCount, (object) diagnosticsSummaryDataType.m_publishingIntervalCount) && Utils.IsEqual((object) this.m_securityRejectedRequestsCount, (object) diagnosticsSummaryDataType.m_securityRejectedRequestsCount) && Utils.IsEqual((object) this.m_rejectedRequestsCount, (object) diagnosticsSummaryDataType.m_rejectedRequestsCount);
  }

  public virtual object Clone()
  {
    return (object) (ServerDiagnosticsSummaryDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    ServerDiagnosticsSummaryDataType diagnosticsSummaryDataType = (ServerDiagnosticsSummaryDataType) base.MemberwiseClone();
    diagnosticsSummaryDataType.m_serverViewCount = (uint) Utils.Clone((object) this.m_serverViewCount);
    diagnosticsSummaryDataType.m_currentSessionCount = (uint) Utils.Clone((object) this.m_currentSessionCount);
    diagnosticsSummaryDataType.m_cumulatedSessionCount = (uint) Utils.Clone((object) this.m_cumulatedSessionCount);
    diagnosticsSummaryDataType.m_securityRejectedSessionCount = (uint) Utils.Clone((object) this.m_securityRejectedSessionCount);
    diagnosticsSummaryDataType.m_rejectedSessionCount = (uint) Utils.Clone((object) this.m_rejectedSessionCount);
    diagnosticsSummaryDataType.m_sessionTimeoutCount = (uint) Utils.Clone((object) this.m_sessionTimeoutCount);
    diagnosticsSummaryDataType.m_sessionAbortCount = (uint) Utils.Clone((object) this.m_sessionAbortCount);
    diagnosticsSummaryDataType.m_currentSubscriptionCount = (uint) Utils.Clone((object) this.m_currentSubscriptionCount);
    diagnosticsSummaryDataType.m_cumulatedSubscriptionCount = (uint) Utils.Clone((object) this.m_cumulatedSubscriptionCount);
    diagnosticsSummaryDataType.m_publishingIntervalCount = (uint) Utils.Clone((object) this.m_publishingIntervalCount);
    diagnosticsSummaryDataType.m_securityRejectedRequestsCount = (uint) Utils.Clone((object) this.m_securityRejectedRequestsCount);
    diagnosticsSummaryDataType.m_rejectedRequestsCount = (uint) Utils.Clone((object) this.m_rejectedRequestsCount);
    return (object) diagnosticsSummaryDataType;
  }
}
