using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNodeTypeDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NodeTypeDescription")]
[ComVisible(true)]
public class NodeTypeDescriptionCollection : List<NodeTypeDescription>, ICloneable
{
	public NodeTypeDescriptionCollection()
	{
	}

	public NodeTypeDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public NodeTypeDescriptionCollection(IEnumerable<NodeTypeDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator NodeTypeDescriptionCollection(NodeTypeDescription[] values)
	{
		if (values != null)
		{
			return new NodeTypeDescriptionCollection(values);
		}
		return new NodeTypeDescriptionCollection();
	}

	public static explicit operator NodeTypeDescription[](NodeTypeDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NodeTypeDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeTypeDescriptionCollection nodeTypeDescriptionCollection = new NodeTypeDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			nodeTypeDescriptionCollection.Add((NodeTypeDescription)Utils.Clone(base[i]));
		}
		return nodeTypeDescriptionCollection;
	}
}
