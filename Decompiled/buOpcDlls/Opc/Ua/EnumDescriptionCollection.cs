using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEnumDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumDescription")]
[ComVisible(true)]
public class EnumDescriptionCollection : List<EnumDescription>, ICloneable
{
	public EnumDescriptionCollection()
	{
	}

	public EnumDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public EnumDescriptionCollection(IEnumerable<EnumDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator EnumDescriptionCollection(EnumDescription[] values)
	{
		if (values != null)
		{
			return new EnumDescriptionCollection(values);
		}
		return new EnumDescriptionCollection();
	}

	public static explicit operator EnumDescription[](EnumDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EnumDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumDescriptionCollection enumDescriptionCollection = new EnumDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			enumDescriptionCollection.Add((EnumDescription)Utils.Clone(base[i]));
		}
		return enumDescriptionCollection;
	}
}
