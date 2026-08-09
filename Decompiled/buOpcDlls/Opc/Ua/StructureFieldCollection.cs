using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfStructureField", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StructureField")]
[ComVisible(true)]
public class StructureFieldCollection : List<StructureField>, ICloneable
{
	public StructureFieldCollection()
	{
	}

	public StructureFieldCollection(int capacity)
		: base(capacity)
	{
	}

	public StructureFieldCollection(IEnumerable<StructureField> collection)
		: base(collection)
	{
	}

	public static implicit operator StructureFieldCollection(StructureField[] values)
	{
		if (values != null)
		{
			return new StructureFieldCollection(values);
		}
		return new StructureFieldCollection();
	}

	public static explicit operator StructureField[](StructureFieldCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (StructureFieldCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StructureFieldCollection structureFieldCollection = new StructureFieldCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			structureFieldCollection.Add((StructureField)Utils.Clone(base[i]));
		}
		return structureFieldCollection;
	}
}
