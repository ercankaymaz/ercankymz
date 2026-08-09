using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfHistoryReadValueId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "HistoryReadValueId")]
[ComVisible(true)]
public class HistoryReadValueIdCollection : List<HistoryReadValueId>, ICloneable
{
	public HistoryReadValueIdCollection()
	{
	}

	public HistoryReadValueIdCollection(int capacity)
		: base(capacity)
	{
	}

	public HistoryReadValueIdCollection(IEnumerable<HistoryReadValueId> collection)
		: base(collection)
	{
	}

	public static implicit operator HistoryReadValueIdCollection(HistoryReadValueId[] values)
	{
		if (values != null)
		{
			return new HistoryReadValueIdCollection(values);
		}
		return new HistoryReadValueIdCollection();
	}

	public static explicit operator HistoryReadValueId[](HistoryReadValueIdCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (HistoryReadValueIdCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryReadValueIdCollection historyReadValueIdCollection = new HistoryReadValueIdCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			historyReadValueIdCollection.Add((HistoryReadValueId)Utils.Clone(base[i]));
		}
		return historyReadValueIdCollection;
	}
}
