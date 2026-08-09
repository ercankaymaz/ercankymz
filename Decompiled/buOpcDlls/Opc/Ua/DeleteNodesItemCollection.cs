using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDeleteNodesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DeleteNodesItem")]
[ComVisible(true)]
public class DeleteNodesItemCollection : List<DeleteNodesItem>, ICloneable
{
	public DeleteNodesItemCollection()
	{
	}

	public DeleteNodesItemCollection(int capacity)
		: base(capacity)
	{
	}

	public DeleteNodesItemCollection(IEnumerable<DeleteNodesItem> collection)
		: base(collection)
	{
	}

	public static implicit operator DeleteNodesItemCollection(DeleteNodesItem[] values)
	{
		if (values != null)
		{
			return new DeleteNodesItemCollection(values);
		}
		return new DeleteNodesItemCollection();
	}

	public static explicit operator DeleteNodesItem[](DeleteNodesItemCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DeleteNodesItemCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteNodesItemCollection deleteNodesItemCollection = new DeleteNodesItemCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			deleteNodesItemCollection.Add((DeleteNodesItem)Utils.Clone(base[i]));
		}
		return deleteNodesItemCollection;
	}
}
