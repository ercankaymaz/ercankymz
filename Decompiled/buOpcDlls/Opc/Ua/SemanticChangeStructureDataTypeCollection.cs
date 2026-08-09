using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSemanticChangeStructureDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SemanticChangeStructureDataType")]
[ComVisible(true)]
public class SemanticChangeStructureDataTypeCollection : List<SemanticChangeStructureDataType>, ICloneable
{
	public SemanticChangeStructureDataTypeCollection()
	{
	}

	public SemanticChangeStructureDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SemanticChangeStructureDataTypeCollection(IEnumerable<SemanticChangeStructureDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SemanticChangeStructureDataTypeCollection(SemanticChangeStructureDataType[] values)
	{
		if (values != null)
		{
			return new SemanticChangeStructureDataTypeCollection(values);
		}
		return new SemanticChangeStructureDataTypeCollection();
	}

	public static explicit operator SemanticChangeStructureDataType[](SemanticChangeStructureDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SemanticChangeStructureDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SemanticChangeStructureDataTypeCollection semanticChangeStructureDataTypeCollection = new SemanticChangeStructureDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			semanticChangeStructureDataTypeCollection.Add((SemanticChangeStructureDataType)Utils.Clone(base[i]));
		}
		return semanticChangeStructureDataTypeCollection;
	}
}
