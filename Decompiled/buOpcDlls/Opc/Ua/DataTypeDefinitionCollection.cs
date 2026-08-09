using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataTypeDefinition", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataTypeDefinition")]
[ComVisible(true)]
public class DataTypeDefinitionCollection : List<DataTypeDefinition>, ICloneable
{
	public DataTypeDefinitionCollection()
	{
	}

	public DataTypeDefinitionCollection(int capacity)
		: base(capacity)
	{
	}

	public DataTypeDefinitionCollection(IEnumerable<DataTypeDefinition> collection)
		: base(collection)
	{
	}

	public static implicit operator DataTypeDefinitionCollection(DataTypeDefinition[] values)
	{
		if (values != null)
		{
			return new DataTypeDefinitionCollection(values);
		}
		return new DataTypeDefinitionCollection();
	}

	public static explicit operator DataTypeDefinition[](DataTypeDefinitionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataTypeDefinitionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeDefinitionCollection dataTypeDefinitionCollection = new DataTypeDefinitionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataTypeDefinitionCollection.Add((DataTypeDefinition)Utils.Clone(base[i]));
		}
		return dataTypeDefinitionCollection;
	}
}
