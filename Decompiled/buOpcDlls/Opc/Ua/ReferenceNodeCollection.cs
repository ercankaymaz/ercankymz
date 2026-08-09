using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfReferenceNode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReferenceNode")]
[ComVisible(true)]
public class ReferenceNodeCollection : List<ReferenceNode>, ICloneable
{
	public ReferenceNodeCollection()
	{
	}

	public ReferenceNodeCollection(int capacity)
		: base(capacity)
	{
	}

	public ReferenceNodeCollection(IEnumerable<ReferenceNode> collection)
		: base(collection)
	{
	}

	public static implicit operator ReferenceNodeCollection(ReferenceNode[] values)
	{
		if (values != null)
		{
			return new ReferenceNodeCollection(values);
		}
		return new ReferenceNodeCollection();
	}

	public static explicit operator ReferenceNode[](ReferenceNodeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ReferenceNodeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReferenceNodeCollection referenceNodeCollection = new ReferenceNodeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			referenceNodeCollection.Add((ReferenceNode)Utils.Clone(base[i]));
		}
		return referenceNodeCollection;
	}
}
