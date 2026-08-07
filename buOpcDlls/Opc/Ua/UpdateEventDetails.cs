// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UpdateEventDetails
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
public class UpdateEventDetails : HistoryUpdateDetails
{
  private PerformUpdateType m_performInsertReplace;
  private EventFilter m_filter;
  private HistoryEventFieldListCollection m_eventData;

  public UpdateEventDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_performInsertReplace = PerformUpdateType.Insert;
    this.m_filter = new EventFilter();
    this.m_eventData = new HistoryEventFieldListCollection();
  }

  [DataMember(Name = "PerformInsertReplace", IsRequired = false, Order = 1)]
  public PerformUpdateType PerformInsertReplace
  {
    get => this.m_performInsertReplace;
    set => this.m_performInsertReplace = value;
  }

  [DataMember(Name = "Filter", IsRequired = false, Order = 2)]
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

  [DataMember(Name = "EventData", IsRequired = false, Order = 3)]
  public HistoryEventFieldListCollection EventData
  {
    get => this.m_eventData;
    set
    {
      this.m_eventData = value;
      if (value != null)
        return;
      this.m_eventData = new HistoryEventFieldListCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UpdateEventDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UpdateEventDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UpdateEventDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UpdateEventDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEnumerated("PerformInsertReplace", (Enum) this.PerformInsertReplace);
    encoder.WriteEncodeable("Filter", (IEncodeable) this.Filter, typeof (EventFilter));
    encoder.WriteEncodeableArray("EventData", (IList<IEncodeable>) this.EventData.ToArray(), typeof (HistoryEventFieldList));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PerformInsertReplace = (PerformUpdateType) decoder.ReadEnumerated("PerformInsertReplace", typeof (PerformUpdateType));
    this.Filter = (EventFilter) decoder.ReadEncodeable("Filter", typeof (EventFilter));
    this.EventData = (HistoryEventFieldListCollection) (HistoryEventFieldList[]) decoder.ReadEncodeableArray("EventData", typeof (HistoryEventFieldList));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UpdateEventDetails updateEventDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_performInsertReplace, (object) updateEventDetails.m_performInsertReplace) && Utils.IsEqual((object) this.m_filter, (object) updateEventDetails.m_filter) && Utils.IsEqual((object) this.m_eventData, (object) updateEventDetails.m_eventData) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (UpdateEventDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UpdateEventDetails updateEventDetails = (UpdateEventDetails) base.MemberwiseClone();
    updateEventDetails.m_performInsertReplace = (PerformUpdateType) Utils.Clone((object) this.m_performInsertReplace);
    updateEventDetails.m_filter = (EventFilter) Utils.Clone((object) this.m_filter);
    updateEventDetails.m_eventData = (HistoryEventFieldListCollection) Utils.Clone((object) this.m_eventData);
    return (object) updateEventDetails;
  }
}
