// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadEventDetails
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
public class ReadEventDetails : HistoryReadDetails
{
  private uint m_numValuesPerNode;
  private DateTime m_startTime;
  private DateTime m_endTime;
  private EventFilter m_filter;

  public ReadEventDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_numValuesPerNode = 0U;
    this.m_startTime = DateTime.MinValue;
    this.m_endTime = DateTime.MinValue;
    this.m_filter = new EventFilter();
  }

  [DataMember(Name = "NumValuesPerNode", IsRequired = false, Order = 1)]
  public uint NumValuesPerNode
  {
    get => this.m_numValuesPerNode;
    set => this.m_numValuesPerNode = value;
  }

  [DataMember(Name = "StartTime", IsRequired = false, Order = 2)]
  public DateTime StartTime
  {
    get => this.m_startTime;
    set => this.m_startTime = value;
  }

  [DataMember(Name = "EndTime", IsRequired = false, Order = 3)]
  public DateTime EndTime
  {
    get => this.m_endTime;
    set => this.m_endTime = value;
  }

  [DataMember(Name = "Filter", IsRequired = false, Order = 4)]
  public EventFilter Filter
  {
    get => this.m_filter;
    set
    {
      this.m_filter = value;
      if (value != null)
        return;
      this.m_filter = new EventFilter();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadEventDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadEventDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadEventDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadEventDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("NumValuesPerNode", this.NumValuesPerNode);
    encoder.WriteDateTime("StartTime", this.StartTime);
    encoder.WriteDateTime("EndTime", this.EndTime);
    encoder.WriteEncodeable("Filter", (IEncodeable) this.Filter, typeof (EventFilter));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NumValuesPerNode = decoder.ReadUInt32("NumValuesPerNode");
    this.StartTime = decoder.ReadDateTime("StartTime");
    this.EndTime = decoder.ReadDateTime("EndTime");
    this.Filter = (EventFilter) decoder.ReadEncodeable("Filter", typeof (EventFilter));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReadEventDetails readEventDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_numValuesPerNode, (object) readEventDetails.m_numValuesPerNode) && Utils.IsEqual(this.m_startTime, readEventDetails.m_startTime) && Utils.IsEqual(this.m_endTime, readEventDetails.m_endTime) && Utils.IsEqual((object) this.m_filter, (object) readEventDetails.m_filter) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReadEventDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadEventDetails readEventDetails = (ReadEventDetails) base.MemberwiseClone();
    readEventDetails.m_numValuesPerNode = (uint) Utils.Clone((object) this.m_numValuesPerNode);
    readEventDetails.m_startTime = (DateTime) Utils.Clone((object) this.m_startTime);
    readEventDetails.m_endTime = (DateTime) Utils.Clone((object) this.m_endTime);
    readEventDetails.m_filter = (EventFilter) Utils.Clone((object) this.m_filter);
    return (object) readEventDetails;
  }
}
