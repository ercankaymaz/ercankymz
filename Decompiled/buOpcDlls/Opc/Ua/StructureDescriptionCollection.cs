using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfStructureDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StructureDescription")]
[ComVisible(true)]
public class StructureDescriptionCollection : List<StructureDescription>, ICloneable
{
	public StructureDescriptionCollection()
	{
	}

	public StructureDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public StructureDescriptionCollection(IEnumerable<StructureDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator StructureDescriptionCollection(StructureDescription[] values)
	{
		if (values != null)
		{
			return new StructureDescriptionCollection(values);
		}
		return new StructureDescriptionCollection();
	}

	public static explicit operator StructureDescription[](StructureDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (StructureDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StructureDescriptionCollection structureDescriptionCollection = new StructureDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			structureDescriptionCollection.Add((StructureDescription)Utils.Clone(base[i]));
		}
		return structureDescriptionCollection;
	}
}
