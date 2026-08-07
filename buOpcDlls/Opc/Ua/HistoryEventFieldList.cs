// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryEventFieldList
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
public class HistoryEventFieldList : IEncodeable, ICloneable, IJsonEncodeable
{
  private VariantCollection m_eventFields;

  public HistoryEventFieldList() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_eventFields = new VariantCollection();

  [DataMember(Name = "EventFields", IsRequired = false, Order = 1)]
  public VariantCollection EventFields
  {
    get => this.m_eventFields;
    set
    {
      this.m_eventFields = value;
      if (value != null)
        return;
      this.m_eventFields = new VariantCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryEventFieldList;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryEventFieldList_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryEventFieldList_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryEventFieldList_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteVariantArray("EventFields", (IList<Variant>) this.EventFields);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EventFields = decoder.ReadVariantArray("EventFields");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryEventFieldList historyEventFieldList && Utils.IsEqual((object) this.m_eventFields, (object) historyEventFieldList.m_eventFields);
  }

  public virtual object Clone() => (object) (HistoryEventFieldList) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryEventFieldList historyEventFieldList = (HistoryEventFieldList) base.MemberwiseClone();
    historyEventFieldList.m_eventFields = (VariantCollection) Utils.Clone((object) this.m_eventFields);
    return (object) historyEventFieldList;
  }
}
