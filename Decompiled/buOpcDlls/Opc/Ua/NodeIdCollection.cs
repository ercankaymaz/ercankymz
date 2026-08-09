using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfNodeId", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NodeId")]
[ComVisible(true)]
public class NodeIdCollection : List<NodeId>, ICloneable
{
	public NodeIdCollection()
	{
	}

	public NodeIdCollection(IEnumerable<NodeId> collection)
		: base(collection)
	{
	}

	public NodeIdCollection(int capacity)
		: base(capacity)
	{
	}

	public static NodeIdCollection ToNodeIdCollection(NodeId[] values)
	{
		if (values != null)
		{
			return new NodeIdCollection(values);
		}
		return new NodeIdCollection();
	}

	public static implicit operator NodeIdCollection(NodeId[] values)
	{
		return ToNodeIdCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeIdCollection nodeIdCollection = new NodeIdCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			NodeId current = enumerator.Current;
			nodeIdCollection.Add((NodeId)Utils.Clone(current));
		}
		return nodeIdCollection;
	}
}
