using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfAddReferencesItem", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "AddReferencesItem")]
[ComVisible(true)]
public class AddReferencesItemCollection : List<AddReferencesItem>, ICloneable
{
	public AddReferencesItemCollection()
	{
	}

	public AddReferencesItemCollection(int capacity)
		: base(capacity)
	{
	}

	public AddReferencesItemCollection(IEnumerable<AddReferencesItem> collection)
		: base(collection)
	{
	}

	public static implicit operator AddReferencesItemCollection(AddReferencesItem[] values)
	{
		if (values != null)
		{
			return new AddReferencesItemCollection(values);
		}
		return new AddReferencesItemCollection();
	}

	public static explicit operator AddReferencesItem[](AddReferencesItemCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (AddReferencesItemCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddReferencesItemCollection addReferencesItemCollection = new AddReferencesItemCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			addReferencesItemCollection.Add((AddReferencesItem)Utils.Clone(base[i]));
		}
		return addReferencesItemCollection;
	}
}
