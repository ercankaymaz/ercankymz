using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataTypeDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataTypeDescription")]
[ComVisible(true)]
public class DataTypeDescriptionCollection : List<DataTypeDescription>, ICloneable
{
	public DataTypeDescriptionCollection()
	{
	}

	public DataTypeDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public DataTypeDescriptionCollection(IEnumerable<DataTypeDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator DataTypeDescriptionCollection(DataTypeDescription[] values)
	{
		if (values != null)
		{
			return new DataTypeDescriptionCollection(values);
		}
		return new DataTypeDescriptionCollection();
	}

	public static explicit operator DataTypeDescription[](DataTypeDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataTypeDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeDescriptionCollection dataTypeDescriptionCollection = new DataTypeDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataTypeDescriptionCollection.Add((DataTypeDescription)Utils.Clone(base[i]));
		}
		return dataTypeDescriptionCollection;
	}
}
