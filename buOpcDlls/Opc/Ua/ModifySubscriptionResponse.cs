// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModifySubscriptionResponse
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
public class ModifySubscriptionResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
  private ResponseHeader m_responseHeader;
  private double m_revisedPublishingInterval;
  private uint m_revisedLifetimeCount;
  private uint m_revisedMaxKeepAliveCount;

  public ModifySubscriptionResponse() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_responseHeader = new ResponseHeader();
    this.m_revisedPublishingInterval = 0.0;
    this.m_revisedLifetimeCount = 0U;
    this.m_revisedMaxKeepAliveCount = 0U;
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

  [DataMember(Name = "RevisedPublishingInterval", IsRequired = false, Order = 2)]
  public double RevisedPublishingInterval
  {
    get => this.m_revisedPublishingInterval;
    set => this.m_revisedPublishingInterval = value;
  }

  [DataMember(Name = "RevisedLifetimeCount", IsRequired = false, Order = 3)]
  public uint RevisedLifetimeCount
  {
    get => this.m_revisedLifetimeCount;
    set => this.m_revisedLifetimeCount = value;
  }

  [DataMember(Name = "RevisedMaxKeepAliveCount", IsRequired = false, Order = 4)]
  public uint RevisedMaxKeepAliveCount
  {
    get => this.m_revisedMaxKeepAliveCount;
    set => this.m_revisedMaxKeepAliveCount = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ModifySubscriptionResponse;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifySubscriptionResponse_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifySubscriptionResponse_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ModifySubscriptionResponse_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ResponseHeader", (IEncodeable) this.ResponseHeader, typeof (ResponseHeader));
    encoder.WriteDouble("RevisedPublishingInterval", this.RevisedPublishingInterval);
    encoder.WriteUInt32("RevisedLifetimeCount", this.RevisedLifetimeCount);
    encoder.WriteUInt32("RevisedMaxKeepAliveCount", this.RevisedMaxKeepAliveCount);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResponseHeader = (ResponseHeader) decoder.ReadEncodeable("ResponseHeader", typeof (ResponseHeader));
    this.RevisedPublishingInterval = decoder.ReadDouble("RevisedPublishingInterval");
    this.RevisedLifetimeCount = decoder.ReadUInt32("RevisedLifetimeCount");
    this.RevisedMaxKeepAliveCount = decoder.ReadUInt32("RevisedMaxKeepAliveCount");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ModifySubscriptionResponse subscriptionResponse && Utils.IsEqual((object) this.m_responseHeader, (object) subscriptionResponse.m_responseHeader) && Utils.IsEqual((object) this.m_revisedPublishingInterval, (object) subscriptionResponse.m_revisedPublishingInterval) && Utils.IsEqual((object) this.m_revisedLifetimeCount, (object) subscriptionResponse.m_revisedLifetimeCount) && Utils.IsEqual((object) this.m_revisedMaxKeepAliveCount, (object) subscriptionResponse.m_revisedMaxKeepAliveCount);
  }

  public virtual object Clone() => (object) (ModifySubscriptionResponse) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ModifySubscriptionResponse subscriptionResponse = (ModifySubscriptionResponse) base.MemberwiseClone();
    subscriptionResponse.m_responseHeader = (ResponseHeader) Utils.Clone((object) this.m_responseHeader);
    subscriptionResponse.m_revisedPublishingInterval = (double) Utils.Clone((object) this.m_revisedPublishingInterval);
    subscriptionResponse.m_revisedLifetimeCount = (uint) Utils.Clone((object) this.m_revisedLifetimeCount);
    subscriptionResponse.m_revisedMaxKeepAliveCount = (uint) Utils.Clone((object) this.m_revisedMaxKeepAliveCount);
    return (object) subscriptionResponse;
  }
}
