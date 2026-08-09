using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfModelChangeStructureDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ModelChangeStructureDataType")]
[ComVisible(true)]
public class ModelChangeStructureDataTypeCollection : List<ModelChangeStructureDataType>, ICloneable
{
	public ModelChangeStructureDataTypeCollection()
	{
	}

	public ModelChangeStructureDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ModelChangeStructureDataTypeCollection(IEnumerable<ModelChangeStructureDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ModelChangeStructureDataTypeCollection(ModelChangeStructureDataType[] values)
	{
		if (values != null)
		{
			return new ModelChangeStructureDataTypeCollection(values);
		}
		return new ModelChangeStructureDataTypeCollection();
	}

	public static explicit operator ModelChangeStructureDataType[](ModelChangeStructureDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ModelChangeStructureDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ModelChangeStructureDataTypeCollection modelChangeStructureDataTypeCollection = new ModelChangeStructureDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			modelChangeStructureDataTypeCollection.Add((ModelChangeStructureDataType)Utils.Clone(base[i]));
		}
		return modelChangeStructureDataTypeCollection;
	}
}
