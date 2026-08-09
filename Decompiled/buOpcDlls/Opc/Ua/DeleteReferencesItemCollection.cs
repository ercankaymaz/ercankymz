using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDeleteReferencesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DeleteReferencesItem")]
[ComVisible(true)]
public class DeleteReferencesItemCollection : List<DeleteReferencesItem>, ICloneable
{
	public DeleteReferencesItemCollection()
	{
	}

	public DeleteReferencesItemCollection(int capacity)
		: base(capacity)
	{
	}

	public DeleteReferencesItemCollection(IEnumerable<DeleteReferencesItem> collection)
		: base(collection)
	{
	}

	public static implicit operator DeleteReferencesItemCollection(DeleteReferencesItem[] values)
	{
		if (values != null)
		{
			return new DeleteReferencesItemCollection(values);
		}
		return new DeleteReferencesItemCollection();
	}

	public static explicit operator DeleteReferencesItem[](DeleteReferencesItemCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DeleteReferencesItemCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteReferencesItemCollection deleteReferencesItemCollection = new DeleteReferencesItemCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			deleteReferencesItemCollection.Add((DeleteReferencesItem)Utils.Clone(base[i]));
		}
		return deleteReferencesItemCollection;
	}
}
