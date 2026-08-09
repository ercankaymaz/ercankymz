using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	[DataMember(Name = "SequenceNumber", IsRequired = false, Order = 1)]
	public uint SequenceNumber
	{
		get
		{
			return m_sequenceNumber;
		}
		set
		{
			m_sequenceNumber = value;
		}
	}

	[DataMember(Name = "PublishTime", IsRequired = false, Order = 2)]
	public DateTime PublishTime
	{
		get
		{
			return m_publishTime;
		}
		set
		{
			m_publishTime = value;
		}
	}

	[DataMember(Name = "NotificationData", IsRequired = false, Order = 3)]
	public ExtensionObjectCollection NotificationData
	{
		get
		{
			return m_notificationData;
		}
		set
		{
			m_notificationData = value;
			if (value == null)
			{
				m_notificationData = new ExtensionObjectCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.NotificationMessage;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NotificationMessage_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NotificationMessage_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NotificationMessage_Encoding_DefaultJson;

	public List<string> StringTable
	{
		get
		{
			return m_stringTable;
		}
		set
		{
			m_stringTable = value;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (SequenceNumber == 0 && PublishTime == DateTime.MinValue && NotificationData.Count == 0)
			{
				return true;
			}
			return false;
		}
	}

	public NotificationMessage()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_sequenceNumber = 0u;
		m_publishTime = DateTime.MinValue;
		m_notificationData = new ExtensionObjectCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("SequenceNumber", SequenceNumber);
		encoder.WriteDateTime("PublishTime", PublishTime);
		encoder.WriteExtensionObjectArray("NotificationData", NotificationData);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SequenceNumber = decoder.ReadUInt32("SequenceNumber");
		PublishTime = decoder.ReadDateTime("PublishTime");
		NotificationData = decoder.ReadExtensionObjectArray("NotificationData");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NotificationMessage notificationMessage))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sequenceNumber, notificationMessage.m_sequenceNumber))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishTime, notificationMessage.m_publishTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_notificationData, notificationMessage.m_notificationData))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NotificationMessage)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NotificationMessage obj = (NotificationMessage)base.MemberwiseClone();
		obj.m_sequenceNumber = (uint)Utils.Clone(m_sequenceNumber);
		obj.m_publishTime = (DateTime)Utils.Clone(m_publishTime);
		obj.m_notificationData = (ExtensionObjectCollection)Utils.Clone(m_notificationData);
		return obj;
	}

	public IList<MonitoredItemNotification> GetDataChanges(bool reverse)
	{
		List<MonitoredItemNotification> list = new List<MonitoredItemNotification>();
		for (int i = 0; i < m_notificationData.Count; i++)
		{
			ExtensionObject extensionObject = m_notificationData[i];
			if (ExtensionObject.IsNull(extensionObject) || !(extensionObject.Body is DataChangeNotification dataChangeNotification))
			{
				continue;
			}
			if (reverse)
			{
				for (int num = dataChangeNotification.MonitoredItems.Count - 1; num >= 0; num--)
				{
					MonitoredItemNotification monitoredItemNotification = dataChangeNotification.MonitoredItems[num];
					if (monitoredItemNotification != null)
					{
						monitoredItemNotification.Message = this;
						list.Add(monitoredItemNotification);
					}
				}
				continue;
			}
			for (int j = 0; j < dataChangeNotification.MonitoredItems.Count; j++)
			{
				MonitoredItemNotification monitoredItemNotification2 = dataChangeNotification.MonitoredItems[j];
				if (monitoredItemNotification2 != null)
				{
					monitoredItemNotification2.Message = this;
					list.Add(monitoredItemNotification2);
				}
			}
		}
		return list;
	}

	public IList<EventFieldList> GetEvents(bool reverse)
	{
		List<EventFieldList> list = new List<EventFieldList>();
		foreach (ExtensionObject notificationDatum in m_notificationData)
		{
			if (ExtensionObject.IsNull(notificationDatum) || !(notificationDatum.Body is EventNotificationList eventNotificationList))
			{
				continue;
			}
			if (reverse)
			{
				for (int num = eventNotificationList.Events.Count - 1; num >= 0; num--)
				{
					EventFieldList eventFieldList = eventNotificationList.Events[num];
					if (eventFieldList != null)
					{
						eventFieldList.Message = this;
						list.Add(eventFieldList);
					}
				}
				continue;
			}
			for (int i = 0; i < eventNotificationList.Events.Count; i++)
			{
				EventFieldList eventFieldList2 = eventNotificationList.Events[i];
				if (eventFieldList2 != null)
				{
					eventFieldList2.Message = this;
					list.Add(eventFieldList2);
				}
			}
		}
		return list;
	}
}
