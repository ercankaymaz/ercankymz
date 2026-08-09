using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfHistoryUpdateResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryUpdateResult")]
[ComVisible(true)]
public class HistoryUpdateResultCollection : List<HistoryUpdateResult>, ICloneable
{
	public HistoryUpdateResultCollection()
	{
	}

	public HistoryUpdateResultCollection(int capacity)
		: base(capacity)
	{
	}

	public HistoryUpdateResultCollection(IEnumerable<HistoryUpdateResult> collection)
		: base(collection)
	{
	}

	public static implicit operator HistoryUpdateResultCollection(HistoryUpdateResult[] values)
	{
		if (values != null)
		{
			return new HistoryUpdateResultCollection(values);
		}
		return new HistoryUpdateResultCollection();
	}

	public static explicit operator HistoryUpdateResult[](HistoryUpdateResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (HistoryUpdateResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryUpdateResultCollection historyUpdateResultCollection = new HistoryUpdateResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			historyUpdateResultCollection.Add((HistoryUpdateResult)Utils.Clone(base[i]));
		}
		return historyUpdateResultCollection;
	}
}
