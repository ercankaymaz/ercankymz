using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEnumField", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumField")]
[ComVisible(true)]
public class EnumFieldCollection : List<EnumField>, ICloneable
{
	public EnumFieldCollection()
	{
	}

	public EnumFieldCollection(int capacity)
		: base(capacity)
	{
	}

	public EnumFieldCollection(IEnumerable<EnumField> collection)
		: base(collection)
	{
	}

	public static implicit operator EnumFieldCollection(EnumField[] values)
	{
		if (values != null)
		{
			return new EnumFieldCollection(values);
		}
		return new EnumFieldCollection();
	}

	public static explicit operator EnumField[](EnumFieldCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EnumFieldCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumFieldCollection enumFieldCollection = new EnumFieldCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			enumFieldCollection.Add((EnumField)Utils.Clone(base[i]));
		}
		return enumFieldCollection;
	}
}
