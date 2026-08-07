// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryEvent
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
public class HistoryEvent : IEncodeable, ICloneable, IJsonEncodeable
{
  private HistoryEventFieldListCollection m_events;

  public HistoryEvent() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_events = new HistoryEventFieldListCollection();

  [DataMember(Name = "Events", IsRequired = false, Order = 1)]
  public HistoryEventFieldListCollection Events
  {
    get => this.m_events;
    set
    {
      this.m_events = value;
      if (value != null)
        return;
      this.m_events = new HistoryEventFieldListCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryEvent;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryEvent_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryEvent_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryEvent_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("Events", (IList<IEncodeable>) this.Events.ToArray(), typeof (HistoryEventFieldList));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Events = (HistoryEventFieldListCollection) (HistoryEventFieldList[]) decoder.ReadEncodeableArray("Events", typeof (HistoryEventFieldList));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryEvent historyEvent && Utils.IsEqual((object) this.m_events, (object) historyEvent.m_events);
  }

  public virtual object Clone() => (object) (HistoryEvent) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryEvent historyEvent = (HistoryEvent) base.MemberwiseClone();
    historyEvent.m_events = (HistoryEventFieldListCollection) Utils.Clone((object) this.m_events);
    return (object) historyEvent;
  }
}
