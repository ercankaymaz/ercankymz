using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfHistoryReadResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryReadResult")]
[ComVisible(true)]
public class HistoryReadResultCollection : List<HistoryReadResult>, ICloneable
{
	public HistoryReadResultCollection()
	{
	}

	public HistoryReadResultCollection(int capacity)
		: base(capacity)
	{
	}

	public HistoryReadResultCollection(IEnumerable<HistoryReadResult> collection)
		: base(collection)
	{
	}

	public static implicit operator HistoryReadResultCollection(HistoryReadResult[] values)
	{
		if (values != null)
		{
			return new HistoryReadResultCollection(values);
		}
		return new HistoryReadResultCollection();
	}

	public static explicit operator HistoryReadResult[](HistoryReadResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (HistoryReadResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryReadResultCollection historyReadResultCollection = new HistoryReadResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			historyReadResultCollection.Add((HistoryReadResult)Utils.Clone(base[i]));
		}
		return historyReadResultCollection;
	}
}
