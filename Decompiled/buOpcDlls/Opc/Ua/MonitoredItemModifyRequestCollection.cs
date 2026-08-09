using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfMonitoredItemModifyRequest", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemModifyRequest")]
[ComVisible(true)]
public class MonitoredItemModifyRequestCollection : List<MonitoredItemModifyRequest>, ICloneable
{
	public MonitoredItemModifyRequestCollection()
	{
	}

	public MonitoredItemModifyRequestCollection(int capacity)
		: base(capacity)
	{
	}

	public MonitoredItemModifyRequestCollection(IEnumerable<MonitoredItemModifyRequest> collection)
		: base(collection)
	{
	}

	public static implicit operator MonitoredItemModifyRequestCollection(MonitoredItemModifyRequest[] values)
	{
		if (values != null)
		{
			return new MonitoredItemModifyRequestCollection(values);
		}
		return new MonitoredItemModifyRequestCollection();
	}

	public static explicit operator MonitoredItemModifyRequest[](MonitoredItemModifyRequestCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (MonitoredItemModifyRequestCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemModifyRequestCollection monitoredItemModifyRequestCollection = new MonitoredItemModifyRequestCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			monitoredItemModifyRequestCollection.Add((MonitoredItemModifyRequest)Utils.Clone(base[i]));
		}
		return monitoredItemModifyRequestCollection;
	}
}
