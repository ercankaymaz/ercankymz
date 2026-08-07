// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemCreateResult
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
public class MonitoredItemCreateResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private uint m_monitoredItemId;
  private double m_revisedSamplingInterval;
  private uint m_revisedQueueSize;
  private ExtensionObject m_filterResult;

  public MonitoredItemCreateResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_monitoredItemId = 0U;
    this.m_revisedSamplingInterval = 0.0;
    this.m_revisedQueueSize = 0U;
    this.m_filterResult = (ExtensionObject) null;
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "MonitoredItemId", IsRequired = false, Order = 2)]
  public uint MonitoredItemId
  {
    get => this.m_monitoredItemId;
    set => this.m_monitoredItemId = value;
  }

  [DataMember(Name = "RevisedSamplingInterval", IsRequired = false, Order = 3)]
  public double RevisedSamplingInterval
  {
    get => this.m_revisedSamplingInterval;
    set => this.m_revisedSamplingInterval = value;
  }

  [DataMember(Name = "RevisedQueueSize", IsRequired = false, Order = 4)]
  public uint RevisedQueueSize
  {
    get => this.m_revisedQueueSize;
    set => this.m_revisedQueueSize = value;
  }

  [DataMember(Name = "FilterResult", IsRequired = false, Order = 5)]
  public ExtensionObject FilterResult
  {
    get => this.m_filterResult;
    set => this.m_filterResult = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MonitoredItemCreateResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemCreateResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemCreateResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemCreateResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteUInt32("MonitoredItemId", this.MonitoredItemId);
    encoder.WriteDouble("RevisedSamplingInterval", this.RevisedSamplingInterval);
    encoder.WriteUInt32("RevisedQueueSize", this.RevisedQueueSize);
    encoder.WriteExtensionObject("FilterResult", this.FilterResult);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.MonitoredItemId = decoder.ReadUInt32("MonitoredItemId");
    this.RevisedSamplingInterval = decoder.ReadDouble("RevisedSamplingInterval");
    this.RevisedQueueSize = decoder.ReadUInt32("RevisedQueueSize");
    this.FilterResult = decoder.ReadExtensionObject("FilterResult");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is MonitoredItemCreateResult itemCreateResult && Utils.IsEqual((object) this.m_statusCode, (object) itemCreateResult.m_statusCode) && Utils.IsEqual((object) this.m_monitoredItemId, (object) itemCreateResult.m_monitoredItemId) && Utils.IsEqual((object) this.m_revisedSamplingInterval, (object) itemCreateResult.m_revisedSamplingInterval) && Utils.IsEqual((object) this.m_revisedQueueSize, (object) itemCreateResult.m_revisedQueueSize) && Utils.IsEqual((object) this.m_filterResult, (object) itemCreateResult.m_filterResult);
  }

  public virtual object Clone() => (object) (MonitoredItemCreateResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemCreateResult itemCreateResult = (MonitoredItemCreateResult) base.MemberwiseClone();
    itemCreateResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    itemCreateResult.m_monitoredItemId = (uint) Utils.Clone((object) this.m_monitoredItemId);
    itemCreateResult.m_revisedSamplingInterval = (double) Utils.Clone((object) this.m_revisedSamplingInterval);
    itemCreateResult.m_revisedQueueSize = (uint) Utils.Clone((object) this.m_revisedQueueSize);
    itemCreateResult.m_filterResult = (ExtensionObject) Utils.Clone((object) this.m_filterResult);
    return (object) itemCreateResult;
  }

  public MonitoredItemCreateResult(uint statusCode)
  {
    this.Initialize();
    this.m_statusCode = (StatusCode) statusCode;
  }
}
