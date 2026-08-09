using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Node")]
[ComVisible(true)]
public class NodeCollection : List<Node>, ICloneable
{
	public NodeCollection()
	{
	}

	public NodeCollection(int capacity)
		: base(capacity)
	{
	}

	public NodeCollection(IEnumerable<Node> collection)
		: base(collection)
	{
	}

	public static implicit operator NodeCollection(Node[] values)
	{
		if (values != null)
		{
			return new NodeCollection(values);
		}
		return new NodeCollection();
	}

	public static explicit operator Node[](NodeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NodeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeCollection nodeCollection = new NodeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			nodeCollection.Add((Node)Utils.Clone(base[i]));
		}
		return nodeCollection;
	}
}
