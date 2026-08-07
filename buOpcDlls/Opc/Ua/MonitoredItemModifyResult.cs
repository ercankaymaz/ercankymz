// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemModifyResult
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
public class MonitoredItemModifyResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private double m_revisedSamplingInterval;
  private uint m_revisedQueueSize;
  private ExtensionObject m_filterResult;

  public MonitoredItemModifyResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
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

  [DataMember(Name = "RevisedSamplingInterval", IsRequired = false, Order = 2)]
  public double RevisedSamplingInterval
  {
    get => this.m_revisedSamplingInterval;
    set => this.m_revisedSamplingInterval = value;
  }

  [DataMember(Name = "RevisedQueueSize", IsRequired = false, Order = 3)]
  public uint RevisedQueueSize
  {
    get => this.m_revisedQueueSize;
    set => this.m_revisedQueueSize = value;
  }

  [DataMember(Name = "FilterResult", IsRequired = false, Order = 4)]
  public ExtensionObject FilterResult
  {
    get => this.m_filterResult;
    set => this.m_filterResult = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MonitoredItemModifyResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemModifyResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemModifyResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemModifyResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteDouble("RevisedSamplingInterval", this.RevisedSamplingInterval);
    encoder.WriteUInt32("RevisedQueueSize", this.RevisedQueueSize);
    encoder.WriteExtensionObject("FilterResult", this.FilterResult);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.RevisedSamplingInterval = decoder.ReadDouble("RevisedSamplingInterval");
    this.RevisedQueueSize = decoder.ReadUInt32("RevisedQueueSize");
    this.FilterResult = decoder.ReadExtensionObject("FilterResult");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is MonitoredItemModifyResult itemModifyResult && Utils.IsEqual((object) this.m_statusCode, (object) itemModifyResult.m_statusCode) && Utils.IsEqual((object) this.m_revisedSamplingInterval, (object) itemModifyResult.m_revisedSamplingInterval) && Utils.IsEqual((object) this.m_revisedQueueSize, (object) itemModifyResult.m_revisedQueueSize) && Utils.IsEqual((object) this.m_filterResult, (object) itemModifyResult.m_filterResult);
  }

  public virtual object Clone() => (object) (MonitoredItemModifyResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemModifyResult itemModifyResult = (MonitoredItemModifyResult) base.MemberwiseClone();
    itemModifyResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    itemModifyResult.m_revisedSamplingInterval = (double) Utils.Clone((object) this.m_revisedSamplingInterval);
    itemModifyResult.m_revisedQueueSize = (uint) Utils.Clone((object) this.m_revisedQueueSize);
    itemModifyResult.m_filterResult = (ExtensionObject) Utils.Clone((object) this.m_filterResult);
    return (object) itemModifyResult;
  }
}
