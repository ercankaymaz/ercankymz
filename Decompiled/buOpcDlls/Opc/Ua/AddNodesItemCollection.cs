using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfAddNodesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AddNodesItem")]
[ComVisible(true)]
public class AddNodesItemCollection : List<AddNodesItem>, ICloneable
{
	public AddNodesItemCollection()
	{
	}

	public AddNodesItemCollection(int capacity)
		: base(capacity)
	{
	}

	public AddNodesItemCollection(IEnumerable<AddNodesItem> collection)
		: base(collection)
	{
	}

	public static implicit operator AddNodesItemCollection(AddNodesItem[] values)
	{
		if (values != null)
		{
			return new AddNodesItemCollection(values);
		}
		return new AddNodesItemCollection();
	}

	public static explicit operator AddNodesItem[](AddNodesItemCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (AddNodesItemCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddNodesItemCollection addNodesItemCollection = new AddNodesItemCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			addNodesItemCollection.Add((AddNodesItem)Utils.Clone(base[i]));
		}
		return addNodesItemCollection;
	}
}
