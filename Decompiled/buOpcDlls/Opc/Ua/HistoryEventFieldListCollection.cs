using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfHistoryEventFieldList", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryEventFieldList")]
[ComVisible(true)]
public class HistoryEventFieldListCollection : List<HistoryEventFieldList>, ICloneable
{
	public HistoryEventFieldListCollection()
	{
	}

	public HistoryEventFieldListCollection(int capacity)
		: base(capacity)
	{
	}

	public HistoryEventFieldListCollection(IEnumerable<HistoryEventFieldList> collection)
		: base(collection)
	{
	}

	public static implicit operator HistoryEventFieldListCollection(HistoryEventFieldList[] values)
	{
		if (values != null)
		{
			return new HistoryEventFieldListCollection(values);
		}
		return new HistoryEventFieldListCollection();
	}

	public static explicit operator HistoryEventFieldList[](HistoryEventFieldListCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (HistoryEventFieldListCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryEventFieldListCollection historyEventFieldListCollection = new HistoryEventFieldListCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			historyEventFieldListCollection.Add((HistoryEventFieldList)Utils.Clone(base[i]));
		}
		return historyEventFieldListCollection;
	}
}
