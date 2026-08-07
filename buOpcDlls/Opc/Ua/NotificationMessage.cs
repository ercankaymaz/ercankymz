// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NotificationMessage
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
public class NotificationMessage : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_sequenceNumber;
  private DateTime m_publishTime;
  private ExtensionObjectCollection m_notificationData;
  private List<string> m_stringTable;

  public NotificationMessage() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_sequenceNumber = 0U;
    this.m_publishTime = DateTime.MinValue;
    this.m_notificationData = new ExtensionObjectCollection();
  }

  [DataMember(Name = "SequenceNumber", IsRequired = false, Order = 1)]
  public uint SequenceNumber
  {
    get => this.m_sequenceNumber;
    set => this.m_sequenceNumber = value;
  }

  [DataMember(Name = "PublishTime", IsRequired = false, Order = 2)]
  public DateTime PublishTime
  {
    get => this.m_publishTime;
    set => this.m_publishTime = value;
  }

  [DataMember(Name = "NotificationData", IsRequired = false, Order = 3)]
  public ExtensionObjectCollection NotificationData
  {
    get => this.m_notificationData;
    set
    {
      this.m_notificationData = value;
      if (value != null)
        return;
      this.m_notificationData = new ExtensionObjectCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NotificationMessage;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NotificationMessage_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NotificationMessage_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NotificationMessage_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("SequenceNumber", this.SequenceNumber);
    encoder.WriteDateTime("PublishTime", this.PublishTime);
    encoder.WriteExtensionObjectArray("NotificationData", (IList<ExtensionObject>) this.NotificationData);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SequenceNumber = decoder.ReadUInt32("SequenceNumber");
    this.PublishTime = decoder.ReadDateTime("PublishTime");
    this.NotificationData = decoder.ReadExtensionObjectArray("NotificationData");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is NotificationMessage notificationMessage && Utils.IsEqual((object) this.m_sequenceNumber, (object) notificationMessage.m_sequenceNumber) && Utils.IsEqual(this.m_publishTime, notificationMessage.m_publishTime) && Utils.IsEqual((object) this.m_notificationData, (object) notificationMessage.m_notificationData);
  }

  public virtual object Clone() => (object) (NotificationMessage) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NotificationMessage notificationMessage = (NotificationMessage) base.MemberwiseClone();
    notificationMessage.m_sequenceNumber = (uint) Utils.Clone((object) this.m_sequenceNumber);
    notificationMessage.m_publishTime = (DateTime) Utils.Clone((object) this.m_publishTime);
    notificationMessage.m_notificationData = (ExtensionObjectCollection) Utils.Clone((object) this.m_notificationData);
    return (object) notificationMessage;
  }

  public List<string> StringTable
  {
    get => this.m_stringTable;
    set => this.m_stringTable = value;
  }

  public bool IsEmpty
  {
    get
    {
      return this.SequenceNumber == 0U && this.PublishTime == DateTime.MinValue && this.NotificationData.Count == 0;
    }
  }

  public IList<MonitoredItemNotification> GetDataChanges(bool reverse)
  {
    List<MonitoredItemNotification> dataChanges = new List<MonitoredItemNotification>();
    for (int index1 = 0; index1 < this.m_notificationData.Count; ++index1)
    {
      ExtensionObject extension = this.m_notificationData[index1];
      if (!ExtensionObject.IsNull(extension) && extension.Body is DataChangeNotification body)
      {
        if (reverse)
        {
          for (int index2 = body.MonitoredItems.Count - 1; index2 >= 0; --index2)
          {
            MonitoredItemNotification monitoredItem = body.MonitoredItems[index2];
            if (monitoredItem != null)
            {
              monitoredItem.Message = this;
              dataChanges.Add(monitoredItem);
            }
          }
        }
        else
        {
          for (int index3 = 0; index3 < body.MonitoredItems.Count; ++index3)
          {
            MonitoredItemNotification monitoredItem = body.MonitoredItems[index3];
            if (monitoredItem != null)
            {
              monitoredItem.Message = this;
              dataChanges.Add(monitoredItem);
            }
          }
        }
      }
    }
    return (IList<MonitoredItemNotification>) dataChanges;
  }

  public IList<EventFieldList> GetEvents(bool reverse)
  {
    List<EventFieldList> events = new List<EventFieldList>();
    foreach (ExtensionObject extension in (List<ExtensionObject>) this.m_notificationData)
    {
      if (!ExtensionObject.IsNull(extension) && extension.Body is EventNotificationList body)
      {
        if (reverse)
        {
          for (int index = body.Events.Count - 1; index >= 0; --index)
          {
            EventFieldList eventFieldList = body.Events[index];
            if (eventFieldList != null)
            {
              eventFieldList.Message = this;
              events.Add(eventFieldList);
            }
          }
        }
        else
        {
          for (int index = 0; index < body.Events.Count; ++index)
          {
            EventFieldList eventFieldList = body.Events[index];
            if (eventFieldList != null)
            {
              eventFieldList.Message = this;
              events.Add(eventFieldList);
            }
          }
        }
      }
    }
    return (IList<EventFieldList>) events;
  }
}
