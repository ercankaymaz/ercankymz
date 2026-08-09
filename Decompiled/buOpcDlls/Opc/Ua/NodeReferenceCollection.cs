using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNodeReference", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NodeReference")]
[ComVisible(true)]
public class NodeReferenceCollection : List<NodeReference>, ICloneable
{
	public NodeReferenceCollection()
	{
	}

	public NodeReferenceCollection(int capacity)
		: base(capacity)
	{
	}

	public NodeReferenceCollection(IEnumerable<NodeReference> collection)
		: base(collection)
	{
	}

	public static implicit operator NodeReferenceCollection(NodeReference[] values)
	{
		if (values != null)
		{
			return new NodeReferenceCollection(values);
		}
		return new NodeReferenceCollection();
	}

	public static explicit operator NodeReference[](NodeReferenceCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NodeReferenceCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeReferenceCollection nodeReferenceCollection = new NodeReferenceCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			nodeReferenceCollection.Add((NodeReference)Utils.Clone(base[i]));
		}
		return nodeReferenceCollection;
	}
}
