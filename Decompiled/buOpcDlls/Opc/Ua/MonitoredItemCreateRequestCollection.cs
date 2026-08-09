using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfMonitoredItemCreateRequest", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemCreateRequest")]
[ComVisible(true)]
public class MonitoredItemCreateRequestCollection : List<MonitoredItemCreateRequest>, ICloneable
{
	public MonitoredItemCreateRequestCollection()
	{
	}

	public MonitoredItemCreateRequestCollection(int capacity)
		: base(capacity)
	{
	}

	public MonitoredItemCreateRequestCollection(IEnumerable<MonitoredItemCreateRequest> collection)
		: base(collection)
	{
	}

	public static implicit operator MonitoredItemCreateRequestCollection(MonitoredItemCreateRequest[] values)
	{
		if (values != null)
		{
			return new MonitoredItemCreateRequestCollection(values);
		}
		return new MonitoredItemCreateRequestCollection();
	}

	public static explicit operator MonitoredItemCreateRequest[](MonitoredItemCreateRequestCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (MonitoredItemCreateRequestCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemCreateRequestCollection monitoredItemCreateRequestCollection = new MonitoredItemCreateRequestCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			monitoredItemCreateRequestCollection.Add((MonitoredItemCreateRequest)Utils.Clone(base[i]));
		}
		return monitoredItemCreateRequestCollection;
	}
}
