// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventNotificationList
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
public class EventNotificationList : NotificationData
{
  private EventFieldListCollection m_events;

  public EventNotificationList() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_events = new EventFieldListCollection();

  [DataMember(Name = "Events", IsRequired = false, Order = 1)]
  public EventFieldListCollection Events
  {
    get => this.m_events;
    set
    {
      this.m_events = value;
      if (value != null)
        return;
      this.m_events = new EventFieldListCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EventNotificationList;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventNotificationList_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventNotificationList_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EventNotificationList_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("Events", (IList<IEncodeable>) this.Events.ToArray(), typeof (EventFieldList));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Events = (EventFieldListCollection) (EventFieldList[]) decoder.ReadEncodeableArray("Events", typeof (EventFieldList));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is EventNotificationList notificationList && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_events, (object) notificationList.m_events) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (EventNotificationList) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EventNotificationList notificationList = (EventNotificationList) base.MemberwiseClone();
    notificationList.m_events = (EventFieldListCollection) Utils.Clone((object) this.m_events);
    return (object) notificationList;
  }
}
