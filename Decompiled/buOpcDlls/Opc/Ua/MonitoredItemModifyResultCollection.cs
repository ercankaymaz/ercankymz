using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfMonitoredItemModifyResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "MonitoredItemModifyResult")]
[ComVisible(true)]
public class MonitoredItemModifyResultCollection : List<MonitoredItemModifyResult>, ICloneable
{
	public MonitoredItemModifyResultCollection()
	{
	}

	public MonitoredItemModifyResultCollection(int capacity)
		: base(capacity)
	{
	}

	public MonitoredItemModifyResultCollection(IEnumerable<MonitoredItemModifyResult> collection)
		: base(collection)
	{
	}

	public static implicit operator MonitoredItemModifyResultCollection(MonitoredItemModifyResult[] values)
	{
		if (values != null)
		{
			return new MonitoredItemModifyResultCollection(values);
		}
		return new MonitoredItemModifyResultCollection();
	}

	public static explicit operator MonitoredItemModifyResult[](MonitoredItemModifyResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (MonitoredItemModifyResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MonitoredItemModifyResultCollection monitoredItemModifyResultCollection = new MonitoredItemModifyResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			monitoredItemModifyResultCollection.Add((MonitoredItemModifyResult)Utils.Clone(base[i]));
		}
		return monitoredItemModifyResultCollection;
	}
}
