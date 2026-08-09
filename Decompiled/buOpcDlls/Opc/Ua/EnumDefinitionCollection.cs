using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEnumDefinition", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "EnumDefinition")]
[ComVisible(true)]
public class EnumDefinitionCollection : List<EnumDefinition>, ICloneable
{
	public EnumDefinitionCollection()
	{
	}

	public EnumDefinitionCollection(int capacity)
		: base(capacity)
	{
	}

	public EnumDefinitionCollection(IEnumerable<EnumDefinition> collection)
		: base(collection)
	{
	}

	public static implicit operator EnumDefinitionCollection(EnumDefinition[] values)
	{
		if (values != null)
		{
			return new EnumDefinitionCollection(values);
		}
		return new EnumDefinitionCollection();
	}

	public static explicit operator EnumDefinition[](EnumDefinitionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EnumDefinitionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumDefinitionCollection enumDefinitionCollection = new EnumDefinitionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			enumDefinitionCollection.Add((EnumDefinition)Utils.Clone(base[i]));
		}
		return enumDefinitionCollection;
	}
}
