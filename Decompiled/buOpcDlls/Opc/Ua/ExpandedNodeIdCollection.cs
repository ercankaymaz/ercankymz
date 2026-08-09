using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfExpandedNodeId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ExpandedNodeId")]
[ComVisible(true)]
public class ExpandedNodeIdCollection : List<ExpandedNodeId>, ICloneable
{
	public ExpandedNodeIdCollection()
	{
	}

	public ExpandedNodeIdCollection(IEnumerable<ExpandedNodeId> collection)
		: base(collection)
	{
	}

	public ExpandedNodeIdCollection(int capacity)
		: base(capacity)
	{
	}

	public static ExpandedNodeIdCollection ToExpandedNodeIdCollection(ExpandedNodeId[] values)
	{
		if (values != null)
		{
			return new ExpandedNodeIdCollection(values);
		}
		return new ExpandedNodeIdCollection();
	}

	public static implicit operator ExpandedNodeIdCollection(ExpandedNodeId[] values)
	{
		return ToExpandedNodeIdCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ExpandedNodeIdCollection expandedNodeIdCollection = new ExpandedNodeIdCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ExpandedNodeId current = enumerator.Current;
			expandedNodeIdCollection.Add((ExpandedNodeId)Utils.Clone(current));
		}
		return expandedNodeIdCollection;
	}
}
