using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfStructureDefinition", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StructureDefinition")]
[ComVisible(true)]
public class StructureDefinitionCollection : List<StructureDefinition>, ICloneable
{
	public StructureDefinitionCollection()
	{
	}

	public StructureDefinitionCollection(int capacity)
		: base(capacity)
	{
	}

	public StructureDefinitionCollection(IEnumerable<StructureDefinition> collection)
		: base(collection)
	{
	}

	public static implicit operator StructureDefinitionCollection(StructureDefinition[] values)
	{
		if (values != null)
		{
			return new StructureDefinitionCollection(values);
		}
		return new StructureDefinitionCollection();
	}

	public static explicit operator StructureDefinition[](StructureDefinitionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (StructureDefinitionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StructureDefinitionCollection structureDefinitionCollection = new StructureDefinitionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			structureDefinitionCollection.Add((StructureDefinition)Utils.Clone(base[i]));
		}
		return structureDefinitionCollection;
	}
}
