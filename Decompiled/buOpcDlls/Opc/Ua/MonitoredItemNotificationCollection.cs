using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfMonitoredItemNotification", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemNotification")]
[ComVisible(true)]
public class MonitoredItemNotificationCollection : List<MonitoredItemNotification>, ICloneable
{
	public MonitoredItemNotificationCollection()
	{
	}

	public MonitoredItemNotificationCollection(int capacity)
		: base(capacity)
	{
	}

	public MonitoredItemNotificationCollection(IEnumerable<MonitoredItemNotification> collection)
		: base(collection)
	{
	}

	public static implicit operator MonitoredItemNotificationCollection(MonitoredItemNotification[] values)
	{
		if (values != null)
		{
			return new MonitoredItemNotificationCollection(values);
		}
		return new MonitoredItemNotificationCollection();
	}

	public static explicit operator MonitoredItemNotification[](MonitoredItemNotificationCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (MonitoredItemNotificationCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemNotificationCollection monitoredItemNotificationCollection = new MonitoredItemNotificationCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			monitoredItemNotificationCollection.Add((MonitoredItemNotification)Utils.Clone(base[i]));
		}
		return monitoredItemNotificationCollection;
	}
}
