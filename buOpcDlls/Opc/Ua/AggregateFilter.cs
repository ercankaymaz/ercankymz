// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AggregateFilter
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
public class AggregateFilter : MonitoringFilter
{
  private DateTime m_startTime;
  private NodeId m_aggregateType;
  private double m_processingInterval;
  private AggregateConfiguration m_aggregateConfiguration;

  public AggregateFilter() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_startTime = DateTime.MinValue;
    this.m_aggregateType = (NodeId) null;
    this.m_processingInterval = 0.0;
    this.m_aggregateConfiguration = new AggregateConfiguration();
  }

  [DataMember(Name = "StartTime", IsRequired = false, Order = 1)]
  public DateTime StartTime
  {
    get => this.m_startTime;
    set => this.m_startTime = value;
  }

  [DataMember(Name = "AggregateType", IsRequired = false, Order = 2)]
  public NodeId AggregateType
  {
    get => this.m_aggregateType;
    set => this.m_aggregateType = value;
  }

  [DataMember(Name = "ProcessingInterval", IsRequired = false, Order = 3)]
  public double ProcessingInterval
  {
    get => this.m_processingInterval;
    set => this.m_processingInterval = value;
  }

  [DataMember(Name = "AggregateConfiguration", IsRequired = false, Order = 4)]
  public AggregateConfiguration AggregateConfiguration
  {
    get => this.m_aggregateConfiguration;
    set
    {
      this.m_aggregateConfiguration = value;
      if (value != null)
        return;
      this.m_aggregateConfiguration = new AggregateConfiguration();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AggregateFilter;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateFilter_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateFilter_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AggregateFilter_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTime("StartTime", this.StartTime);
    encoder.WriteNodeId("AggregateType", this.AggregateType);
    encoder.WriteDouble("ProcessingInterval", this.ProcessingInterval);
    encoder.WriteEncodeable("AggregateConfiguration", (IEncodeable) this.AggregateConfiguration, typeof (AggregateConfiguration));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StartTime = decoder.ReadDateTime("StartTime");
    this.AggregateType = decoder.ReadNodeId("AggregateType");
    this.ProcessingInterval = decoder.ReadDouble("ProcessingInterval");
    this.AggregateConfiguration = (AggregateConfiguration) decoder.ReadEncodeable("AggregateConfiguration", typeof (AggregateConfiguration));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is AggregateFilter aggregateFilter && base.IsEqual(encodeable) && Utils.IsEqual(this.m_startTime, aggregateFilter.m_startTime) && Utils.IsEqual((object) this.m_aggregateType, (object) aggregateFilter.m_aggregateType) && Utils.IsEqual((object) this.m_processingInterval, (object) aggregateFilter.m_processingInterval) && Utils.IsEqual((object) this.m_aggregateConfiguration, (object) aggregateFilter.m_aggregateConfiguration) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (AggregateFilter) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AggregateFilter aggregateFilter = (AggregateFilter) base.MemberwiseClone();
    aggregateFilter.m_startTime = (DateTime) Utils.Clone((object) this.m_startTime);
    aggregateFilter.m_aggregateType = (NodeId) Utils.Clone((object) this.m_aggregateType);
    aggregateFilter.m_processingInterval = (double) Utils.Clone((object) this.m_processingInterval);
    aggregateFilter.m_aggregateConfiguration = (AggregateConfiguration) Utils.Clone((object) this.m_aggregateConfiguration);
    return (object) aggregateFilter;
  }
}
