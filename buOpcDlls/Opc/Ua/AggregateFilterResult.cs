// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AggregateFilterResult
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
public class AggregateFilterResult : MonitoringFilterResult
{
  private DateTime m_revisedStartTime;
  private double m_revisedProcessingInterval;
  private AggregateConfiguration m_revisedAggregateConfiguration;

  public AggregateFilterResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_revisedStartTime = DateTime.MinValue;
    this.m_revisedProcessingInterval = 0.0;
    this.m_revisedAggregateConfiguration = new AggregateConfiguration();
  }

  [DataMember(Name = "RevisedStartTime", IsRequired = false, Order = 1)]
  public DateTime RevisedStartTime
  {
    get => this.m_revisedStartTime;
    set => this.m_revisedStartTime = value;
  }

  [DataMember(Name = "RevisedProcessingInterval", IsRequired = false, Order = 2)]
  public double RevisedProcessingInterval
  {
    get => this.m_revisedProcessingInterval;
    set => this.m_revisedProcessingInterval = value;
  }

  [DataMember(Name = "RevisedAggregateConfiguration", IsRequired = false, Order = 3)]
  public AggregateConfiguration RevisedAggregateConfiguration
  {
    get => this.m_revisedAggregateConfiguration;
    set
    {
      this.m_revisedAggregateConfiguration = value;
      if (value != null)
        return;
      this.m_revisedAggregateConfiguration = new AggregateConfiguration();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AggregateFilterResult;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateFilterResult_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateFilterResult_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateFilterResult_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTime("RevisedStartTime", this.RevisedStartTime);
    encoder.WriteDouble("RevisedProcessingInterval", this.RevisedProcessingInterval);
    encoder.WriteEncodeable("RevisedAggregateConfiguration", (IEncodeable) this.RevisedAggregateConfiguration, typeof (AggregateConfiguration));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.RevisedStartTime = decoder.ReadDateTime("RevisedStartTime");
    this.RevisedProcessingInterval = decoder.ReadDouble("RevisedProcessingInterval");
    this.RevisedAggregateConfiguration = (AggregateConfiguration) decoder.ReadEncodeable("RevisedAggregateConfiguration", typeof (AggregateConfiguration));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is AggregateFilterResult aggregateFilterResult && base.IsEqual(encodeable) && Utils.IsEqual(this.m_revisedStartTime, aggregateFilterResult.m_revisedStartTime) && Utils.IsEqual((object) this.m_revisedProcessingInterval, (object) aggregateFilterResult.m_revisedProcessingInterval) && Utils.IsEqual((object) this.m_revisedAggregateConfiguration, (object) aggregateFilterResult.m_revisedAggregateConfiguration) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (AggregateFilterResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AggregateFilterResult aggregateFilterResult = (AggregateFilterResult) base.MemberwiseClone();
    aggregateFilterResult.m_revisedStartTime = (DateTime) Utils.Clone((object) this.m_revisedStartTime);
    aggregateFilterResult.m_revisedProcessingInterval = (double) Utils.Clone((object) this.m_revisedProcessingInterval);
    aggregateFilterResult.m_revisedAggregateConfiguration = (AggregateConfiguration) Utils.Clone((object) this.m_revisedAggregateConfiguration);
    return (object) aggregateFilterResult;
  }
}
