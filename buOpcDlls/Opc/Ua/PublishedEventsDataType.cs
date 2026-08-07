// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedEventsDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishedEventsDataType : PublishedDataSetSourceDataType
{
  private NodeId m_eventNotifier;
  private SimpleAttributeOperandCollection m_selectedFields;
  private ContentFilter m_filter;

  public PublishedEventsDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_eventNotifier = (NodeId) null;
    this.m_selectedFields = new SimpleAttributeOperandCollection();
    this.m_filter = new ContentFilter();
  }

  [DataMember(Name = "EventNotifier", IsRequired = false, Order = 1)]
  public NodeId EventNotifier
  {
    get => this.m_eventNotifier;
    set => this.m_eventNotifier = value;
  }

  [DataMember(Name = "SelectedFields", IsRequired = false, Order = 2)]
  public SimpleAttributeOperandCollection SelectedFields
  {
    get => this.m_selectedFields;
    set
    {
      this.m_selectedFields = value;
      if (value != null)
        return;
      this.m_selectedFields = new SimpleAttributeOperandCollection();
    }
  }

  [DataMember(Name = "Filter", IsRequired = false, Order = 3)]
  public ContentFilter Filter
  {
    get => this.m_filter;
    set
    {
      this.m_filter = value;
      if (value != null)
        return;
      this.m_filter = new ContentFilter();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PublishedEventsDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedEventsDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedEventsDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedEventsDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("EventNotifier", this.EventNotifier);
    encoder.WriteEncodeableArray("SelectedFields", (IList<IEncodeable>) this.SelectedFields.ToArray(), typeof (SimpleAttributeOperand));
    encoder.WriteEncodeable("Filter", (IEncodeable) this.Filter, typeof (ContentFilter));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EventNotifier = decoder.ReadNodeId("EventNotifier");
    this.SelectedFields = (SimpleAttributeOperandCollection) (SimpleAttributeOperand[]) decoder.ReadEncodeableArray("SelectedFields", typeof (SimpleAttributeOperand));
    this.Filter = (ContentFilter) decoder.ReadEncodeable("Filter", typeof (ContentFilter));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is PublishedEventsDataType publishedEventsDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_eventNotifier, (object) publishedEventsDataType.m_eventNotifier) && Utils.IsEqual((object) this.m_selectedFields, (object) publishedEventsDataType.m_selectedFields) && Utils.IsEqual((object) this.m_filter, (object) publishedEventsDataType.m_filter) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (PublishedEventsDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedEventsDataType publishedEventsDataType = (PublishedEventsDataType) base.MemberwiseClone();
    publishedEventsDataType.m_eventNotifier = (NodeId) Utils.Clone((object) this.m_eventNotifier);
    publishedEventsDataType.m_selectedFields = (SimpleAttributeOperandCollection) Utils.Clone((object) this.m_selectedFields);
    publishedEventsDataType.m_filter = (ContentFilter) Utils.Clone((object) this.m_filter);
    return (object) publishedEventsDataType;
  }
}
