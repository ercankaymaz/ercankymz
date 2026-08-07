// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventFieldList
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
public class EventFieldList : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_clientHandle;
  private VariantCollection m_eventFields;
  private object m_handle;

  public EventFieldList() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_clientHandle = 0U;
    this.m_eventFields = new VariantCollection();
  }

  [DataMember(Name = "ClientHandle", IsRequired = false, Order = 1)]
  public uint ClientHandle
  {
    get => this.m_clientHandle;
    set => this.m_clientHandle = value;
  }

  [DataMember(Name = "EventFields", IsRequired = false, Order = 2)]
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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EventFieldList;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFieldList_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFieldList_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventFieldList_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("ClientHandle", this.ClientHandle);
    encoder.WriteVariantArray("EventFields", (IList<Variant>) this.EventFields);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ClientHandle = decoder.ReadUInt32("ClientHandle");
    this.EventFields = decoder.ReadVariantArray("EventFields");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EventFieldList eventFieldList && Utils.IsEqual((object) this.m_clientHandle, (object) eventFieldList.m_clientHandle) && Utils.IsEqual((object) this.m_eventFields, (object) eventFieldList.m_eventFields);
  }

  public virtual object Clone() => (object) (EventFieldList) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EventFieldList eventFieldList = (EventFieldList) base.MemberwiseClone();
    eventFieldList.m_clientHandle = (uint) Utils.Clone((object) this.m_clientHandle);
    eventFieldList.m_eventFields = (VariantCollection) Utils.Clone((object) this.m_eventFields);
    return (object) eventFieldList;
  }

  public NotificationMessage Message
  {
    get => this.m_handle as NotificationMessage;
    set => this.m_handle = (object) value;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }
}
