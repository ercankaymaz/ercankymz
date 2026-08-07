// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private uint m_subscriptionId;
  private UInt32Collection m_availableSequenceNumbers;
  private bool m_moreNotifications;
  private NotificationMessage m_notificationMessage;
  private StatusCodeCollection m_results;
  private DiagnosticInfoCollection m_diagnosticInfos;

  public PublishResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_subscriptionId = 0U;
    this.m_availableSequenceNumbers = new UInt32Collection();
    this.m_moreNotifications = true;
    this.m_notificationMessage = new NotificationMessage();
    this.m_results = new StatusCodeCollection();
    this.m_diagnosticInfos = new DiagnosticInfoCollection();
  }

  [DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
  public ResponseHeader ResponseHeader
  {
    get => this.m_responseHeader;
    set
    {
      this.m_responseHeader = value;
      if (value != null)
        return;
      this.m_responseHeader = new ResponseHeader();
    }
  }

  [DataMember(Name = "SubscriptionId", IsRequired = false, Order = 2)]
  public uint SubscriptionId
  {
    get => this.m_subscriptionId;
    set => this.m_subscriptionId = value;
  }

  [DataMember(Name = "AvailableSequenceNumbers", IsRequired = false, Order = 3)]
  public UInt32Collection AvailableSequenceNumbers
  {
    get => this.m_availableSequenceNumbers;
    set
    {
      this.m_availableSequenceNumbers = value;
      if (value != null)
        return;
      this.m_availableSequenceNumbers = new UInt32Collection();
    }
  }

  [DataMember(Name = "MoreNotifications", IsRequired = false, Order = 4)]
  public bool MoreNotifications
  {
    get => this.m_moreNotifications;
    set => this.m_moreNotifications = value;
  }

  [DataMember(Name = "NotificationMessage", IsRequired = false, Order = 5)]
  public NotificationMessage NotificationMessage
  {
    get => this.m_notificationMessage;
    set
    {
      this.m_notificationMessage = value;
      if (value != null)
        return;
      this.m_notificationMessage = new NotificationMessage();
    }
  }

  [DataMember(Name = "Results", IsRequired = false, Order = 6)]
  public StatusCodeCollection Results
  {
    get => this.m_results;
    set
    {
      this.m_results = value;
      if (value != null)
        return;
      this.m_results = new StatusCodeCollection();
    }
  }

  [DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 7)]
  public DiagnosticInfoCollection DiagnosticInfos
  {
    get => this.m_diagnosticInfos;
    set
    {
      this.m_diagnosticInfos = value;
      if (value != null)
        return;
      this.m_diagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PublishResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteUInt32Array("AvailableSequenceNumbers", (IList<uint>) this.AvailableSequenceNumbers);
    encoder.WriteBoolean("MoreNotifications", this.MoreNotifications);
    encoder.WriteEncodeable("NotificationMessage", (IEncodeable) this.NotificationMessage, typeof (NotificationMessage));
    encoder.WriteStatusCodeArray("Results", (IList<StatusCode>) this.Results);
    encoder.WriteDiagnosticInfoArray("DiagnosticInfos", (IList<DiagnosticInfo>) this.DiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.AvailableSequenceNumbers = decoder.ReadUInt32Array("AvailableSequenceNumbers");
    this.MoreNotifications = decoder.ReadBoolean("MoreNotifications");
    this.NotificationMessage = (NotificationMessage) decoder.ReadEncodeable("NotificationMessage", typeof (NotificationMessage));
    this.Results = decoder.ReadStatusCodeArray("Results");
    this.DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is PublishResponse publishResponse && Utils.IsEqual((object) this.m_responseHeader, (object) publishResponse.m_responseHeader) && Utils.IsEqual((object) this.m_subscriptionId, (object) publishResponse.m_subscriptionId) && Utils.IsEqual((object) this.m_availableSequenceNumbers, (object) publishResponse.m_availableSequenceNumbers) && Utils.IsEqual((object) this.m_moreNotifications, (object) publishResponse.m_moreNotifications) && Utils.IsEqual((object) this.m_notificationMessage, (object) publishResponse.m_notificationMessage) && Utils.IsEqual((object) this.m_results, (object) publishResponse.m_results) && Utils.IsEqual((object) this.m_diagnosticInfos, (object) publishResponse.m_diagnosticInfos);
  }

  public virtual object Clone() => (object) (PublishResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishResponse publishResponse = (PublishResponse) base.MemberwiseClone();
    publishResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    publishResponse.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    publishResponse.m_availableSequenceNumbers = (UInt32Collection) Utils.Clone((object) this.m_availableSequenceNumbers);
    publishResponse.m_moreNotifications = (bool) Utils.Clone((object) this.m_moreNotifications);
    publishResponse.m_notificationMessage = (NotificationMessage) Utils.Clone((object) this.m_notificationMessage);
    publishResponse.m_results = (StatusCodeCollection) Utils.Clone((object) this.m_results);
    publishResponse.m_diagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_diagnosticInfos);
    return (object) publishResponse;
  }
}
