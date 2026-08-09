using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEnumValueType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumValueType")]
[ComVisible(true)]
public class EnumValueTypeCollection : List<EnumValueType>, ICloneable
{
	public EnumValueTypeCollection()
	{
	}

	public EnumValueTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public EnumValueTypeCollection(IEnumerable<EnumValueType> collection)
		: base(collection)
	{
	}

	public static implicit operator EnumValueTypeCollection(EnumValueType[] values)
	{
		if (values != null)
		{
			return new EnumValueTypeCollection(values);
		}
		return new EnumValueTypeCollection();
	}

	public static explicit operator EnumValueType[](EnumValueTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EnumValueTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumValueTypeCollection enumValueTypeCollection = new EnumValueTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			enumValueTypeCollection.Add((EnumValueType)Utils.Clone(base[i]));
		}
		return enumValueTypeCollection;
	}
}
