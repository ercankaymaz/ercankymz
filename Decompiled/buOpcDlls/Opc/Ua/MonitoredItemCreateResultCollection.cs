using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfMonitoredItemCreateResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemCreateResult")]
[ComVisible(true)]
public class MonitoredItemCreateResultCollection : List<MonitoredItemCreateResult>, ICloneable
{
	public MonitoredItemCreateResultCollection()
	{
	}

	public MonitoredItemCreateResultCollection(int capacity)
		: base(capacity)
	{
	}

	public MonitoredItemCreateResultCollection(IEnumerable<MonitoredItemCreateResult> collection)
		: base(collection)
	{
	}

	public static implicit operator MonitoredItemCreateResultCollection(MonitoredItemCreateResult[] values)
	{
		if (values != null)
		{
			return new MonitoredItemCreateResultCollection(values);
		}
		return new MonitoredItemCreateResultCollection();
	}

	public static explicit operator MonitoredItemCreateResult[](MonitoredItemCreateResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (MonitoredItemCreateResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemCreateResultCollection monitoredItemCreateResultCollection = new MonitoredItemCreateResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			monitoredItemCreateResultCollection.Add((MonitoredItemCreateResult)Utils.Clone(base[i]));
		}
		return monitoredItemCreateResultCollection;
	}
}
