using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSimpleTypeDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SimpleTypeDescription")]
[ComVisible(true)]
public class SimpleTypeDescriptionCollection : List<SimpleTypeDescription>, ICloneable
{
	public SimpleTypeDescriptionCollection()
	{
	}

	public SimpleTypeDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public SimpleTypeDescriptionCollection(IEnumerable<SimpleTypeDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator SimpleTypeDescriptionCollection(SimpleTypeDescription[] values)
	{
		if (values != null)
		{
			return new SimpleTypeDescriptionCollection(values);
		}
		return new SimpleTypeDescriptionCollection();
	}

	public static explicit operator SimpleTypeDescription[](SimpleTypeDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SimpleTypeDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SimpleTypeDescriptionCollection simpleTypeDescriptionCollection = new SimpleTypeDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			simpleTypeDescriptionCollection.Add((SimpleTypeDescription)Utils.Clone(base[i]));
		}
		return simpleTypeDescriptionCollection;
	}
}
