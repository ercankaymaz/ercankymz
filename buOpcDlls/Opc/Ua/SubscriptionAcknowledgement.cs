// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SubscriptionAcknowledgement
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
public class SubscriptionAcknowledgement : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_subscriptionId;
  private uint m_sequenceNumber;

  public SubscriptionAcknowledgement() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_subscriptionId = 0U;
    this.m_sequenceNumber = 0U;
  }

  [DataMember(Name = "SubscriptionId", IsRequired = false, Order = 1)]
  public uint SubscriptionId
  {
    get => this.m_subscriptionId;
    set => this.m_subscriptionId = value;
  }

  [DataMember(Name = "SequenceNumber", IsRequired = false, Order = 2)]
  public uint SequenceNumber
  {
    get => this.m_sequenceNumber;
    set => this.m_sequenceNumber = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SubscriptionAcknowledgement;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscriptionAcknowledgement_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscriptionAcknowledgement_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SubscriptionAcknowledgement_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("SubscriptionId", this.SubscriptionId);
    encoder.WriteUInt32("SequenceNumber", this.SequenceNumber);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SubscriptionId = decoder.ReadUInt32("SubscriptionId");
    this.SequenceNumber = decoder.ReadUInt32("SequenceNumber");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SubscriptionAcknowledgement subscriptionAcknowledgement && Utils.IsEqual((object) this.m_subscriptionId, (object) subscriptionAcknowledgement.m_subscriptionId) && Utils.IsEqual((object) this.m_sequenceNumber, (object) subscriptionAcknowledgement.m_sequenceNumber);
  }

  public virtual object Clone() => (object) (SubscriptionAcknowledgement) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SubscriptionAcknowledgement subscriptionAcknowledgement = (SubscriptionAcknowledgement) base.MemberwiseClone();
    subscriptionAcknowledgement.m_subscriptionId = (uint) Utils.Clone((object) this.m_subscriptionId);
    subscriptionAcknowledgement.m_sequenceNumber = (uint) Utils.Clone((object) this.m_sequenceNumber);
    return (object) subscriptionAcknowledgement;
  }
}
